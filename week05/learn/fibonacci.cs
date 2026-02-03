using System;

public class FibonacciRecursion
{
    public static void Run()
    {
        List<(int input, long expected)> recursionFactorials = [
            (1, 1),
            (2, 1),
            (3, 2),
            (4, 3),
            (5, 5),
            (6, 8),
            (7, 13),
            (8, 21),
            (9, 34),
            (10, 55),
        ];

        EvaluateFibonacci(recursionFactorials, Fibonacci);
    }

    private static long Fibonacci(
        int number,
        Dictionary<int, long> remember = null
    )
    {
        remember ??= [];

        if (number <= 2)
            return 1;

        if (remember.TryGetValue(number, out long value))
            return value;

        long result = Fibonacci(number - 1) + Fibonacci(number - 2);

        remember[number] = result;
        return result;
    }

    private static void EvaluateFibonacci(
        List<(int input, long expected)> fibonacci,
        Func<int, Dictionary<int, long>, long> action,
        int times = 1_000_000
    )
    {
        Dictionary<int, long> remember = [];
        foreach ((int input, long expected) in fibonacci)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Fibonacci of {input} expected {expected} result");
            Console.ResetColor();

            (double executionTime, long result) = TimeHelper.Time<long>(() => action(input, remember), times);
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