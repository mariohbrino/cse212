using System;

namespace Learn
{
    public class BinarySearchRecursion
    {
        public static void Run()
        {
            List<(int[] input, int target, bool expected)> recursionBinarySearch = [
                ([1, 3, 6, 18, 20, 25, 34, 38, 89, 95, 99, 100], 89, true),
                ([1, 3, 6, 18, 20, 25, 34, 38, 89, 95, 99, 100], 1, true),
                ([1, 3, 6, 18, 20, 25, 34, 38, 89, 95, 99, 100], 17, false),
            ];

            EvaluateBinarySearch(recursionBinarySearch, BinarySearch);
        }

        public static bool BinarySearch(int[] sortedArray, int target)
        {
            if (sortedArray.Length == 1)
            {
                // Base case
                return target == sortedArray[0];
            }
            else
            {
                // Find the middle and compare
                var middle = sortedArray.Length / 2;

                if (target == sortedArray[middle])
                {
                    // We got lucky and the middle was the match
                    return true;
                }
                else if (target < sortedArray[middle])
                {
                    // Search the first half (index 0 to middle-1) and return the result
                    return BinarySearch(sortedArray[..middle], target);
                }
                else
                {
                    // Search the second half (index middle to end) and return the result
                    return BinarySearch(sortedArray[middle..], target);
                }
            }
        }

        private static void EvaluateBinarySearch(
            List<(int[] input, int target, bool expected)> factorial,
            Func<int[], int, bool> action,
            int times = 1_000_000
        )
        {
            foreach ((int[] input, int target, bool expected) in factorial)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Target of {target} expected {expected} result");
                Console.ResetColor();

                (double executionTime, bool result) = TimeHelper.Time(() => action(input, target), times);
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
}