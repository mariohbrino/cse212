using System;

namespace Learn
{
    public class SumRecursion
    {
        public static void Run()
        {
            List<(int input, int expected)> recursionFactorials = [
                (1, 1),     // 1 = 1
                (2, 3),     // 1 + 2 = 3
                (3, 6),     // 1 + 2 + 3 = 6
                (-1, 0),    // (-1) + 0 + 1 = 0
                (-2, -2),   // (-2) + (-1) + 0 + 1 = -3 + 1 = -2
                (-3, -5),   // (-3) + (-2) + (-1) + 0 + 1 = -6 + 1 = -5
            ];

            EvaluateSum(recursionFactorials, Sum);
        }

        public static int Sum(int number)
        {
            if (number == 1)
                return number;
            else if (number <= 0)
                return number + Sum(number + 1);
            return number + Sum(number - 1);
        }

        private static void EvaluateSum(
            List<(int input, int expected)> sum,
            Func<int, int> action,
            int times = 1_000_000
        )
        {
            foreach ((int input, int expected) in sum)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Sum of {input} expected {expected} result");
                Console.ResetColor();

                (double executionTime, int result) = TimeHelper.Time(() => action(input), times);
                Console.WriteLine($"Execution Time: {executionTime} ms");

                if (result == expected)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"result: {result,3}, expected: {expected,3}");
                Console.ResetColor();
            }
        }
    }
}