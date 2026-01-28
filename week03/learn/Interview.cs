using System;
using System.Diagnostics;

public class Interview
{
    public static void Run()
    {
        List<(HashSet<char>, HashSet<char>, string)> intersectionSets = [
            ([.. "abc"], [.. "abc"], "abc"),
            ([.. "cat"], [.."acs"], "ca"),
            ([.. "abc"], [.. "def"], "")
        ];

        Console.WriteLine("\n- Intersection\n");
        EvaluateSets(intersectionSets, Intersection);

        List<(HashSet<char>, HashSet<char>, string)> unionSets = [
            ([.. "abc"], [.. "abc"], "abc"),
            ([.. "cat"], [.."acs"], "cats"),
            ([.. "abc"], [.. "def"], "abcdef")
        ];

        Console.WriteLine("\n- Union\n");
        EvaluateSets(unionSets, Union);
    }

    private static void EvaluateSets(
        List<(HashSet<char>, HashSet<char>, string)> set,
        Func<HashSet<char>, HashSet<char>, string> action,
        int times = 1_000_000
    )
    {
        foreach (var (word1, word2, expected) in set)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Compare: {String.Join("", word1)} <=> {String.Join("", word2)}");
            Console.ResetColor();

            (double executionTime, string result) = Time(() => action(word1, word2), times);
            Console.WriteLine($"Execution Time: {executionTime} ms");

            if (result == expected)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"result: {result,6}, expected: {expected,6}");
            Console.ResetColor();
        }
    }

    public static string Intersection(HashSet<char> word1, HashSet<char> word2)
    {
        HashSet<char> resultSet = [];

        foreach (char letter in word1)      // O(n)
        {
            if (word2.Contains(letter))    // O(1)
                resultSet.Add(letter);      // O(1)
        }

        return String.Join("", resultSet);  // O(n)
    }

    public static string Union(HashSet<char> word1, HashSet<char> word2)
    {
        HashSet<char> resultSet = [.. word1, .. word2]; // O(n + m)
        return String.Join("", resultSet);
    }

    private static (double, string) Time(Func<string> executeAlgorithm, int times)
    {
        var sw = Stopwatch.StartNew();
        string result = "";
        for (var i = 0; i < times; ++i)
        {
            result = executeAlgorithm(); // Calls the action passed in to this method
        }

        sw.Stop();
        return ((sw.Elapsed.TotalMilliseconds / times), result);
    }
}