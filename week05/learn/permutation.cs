using System;

namespace Learn
{
    public class PermutationRecursion
    {
        public static void Run()
        {
            List<(string word, HashSet<string>)> recursionPermutations = [
                ("ABC", ["ABC", "ACB", "BAC", "BCA", "CAB", "CBA"]),
            ];

            EvaluatePermutations(recursionPermutations, Permutations);
        }

        private static HashSet<string> Permutations(string letters)
        {
            return Permutations(letters, "");
        }

        private static HashSet<string> Permutations(string letters, string word = "")
        {
            HashSet<string> result = [];

            // Try adding each of the available letters
            // to the 'word' and add up all the
            // resulting permutations.
            if (letters.Length == 0)
            {
                result.Add(word);
            }
            else
            {
                for (var index = 0; index < letters.Length; index++)
                {
                    // Make a copy of the letters to pass to the
                    // the next call to permutations. We need
                    // to remove the letter we just added before
                    // we call permutations again.
                    var lettersLeft = letters.Remove(index, 1);

                    // Add the new letter to the word we have so far
                    var permutations = Permutations(lettersLeft, word + letters[index]);
                    result.UnionWith(permutations);
                }
            }

            return result;
        }

        private static void EvaluatePermutations(
            List<(string word, HashSet<string> expected)> permutations,
            Func<string, HashSet<string>> action,
            int times = 1_000_000
        )
        {
            foreach ((string word, HashSet<string> expected) in permutations)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\nPermutations of '{word}'");
                Console.ResetColor();

                (double executionTime, HashSet<string> results) = TimeHelper.Time(() => action(word), times);
                Console.WriteLine($"Execution Time: {executionTime} ms");

                bool allMatch = results.SetEquals(expected);

                if (allMatch)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"Result count: {results.Count}, Expected count: {expected.Count}");
                Console.WriteLine($"All permutations match: {allMatch}");
                Console.ResetColor();

                var permList = results.ToList();
                string permutationsText = permList.Count > 1
                    ? string.Join(", ", permList.Take(permList.Count - 1)) + ", and " + permList.Last()
                    : permList.FirstOrDefault() ?? "";
                Console.WriteLine($"Permutations: {permutationsText}");
            }
        }
    }

}
