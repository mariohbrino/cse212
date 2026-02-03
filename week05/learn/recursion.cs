using System;

public class FactorialRecursion
{
    public static void Run()
    {
        List<(int input, int expected)> recursionFactorials = [
            (2, 2),
            (3, 6),
            (4, 24),
            (5, 120),
        ];

        EvaluateFactorials(recursionFactorials, Factorial);
    }

    public static int Factorial(int number)
    {
        if (number <= 1)
        {
            return 1;
        }
        else
        {
            return number * Factorial(number - 1);
        }
    }

    private static void EvaluateFactorials(
        List<(int input, int expected)> factorial,
        Func<int, int> action,
        int times = 1_000_000
    )
    {
        foreach ((int input, int expected) in factorial)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Factorial of {input} expected {expected} result");
            Console.ResetColor();

            (double executionTime, int result) = TimeHelper.Time(() => action(input), times);
            Console.WriteLine($"Execution Time: {executionTime} ms");

            if (result == expected)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"result: {result,6}, expected: {expected,6}");
            Console.ResetColor();
        }
    }
}