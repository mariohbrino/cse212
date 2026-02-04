using System;

namespace Learn
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n======================\nFactorial Recursion\n======================");
            FactorialRecursion.Run();

            Console.WriteLine("\n======================\nFibonacci Recursion\n======================");
            FibonacciRecursion.Run();

            Console.WriteLine("\n======================\nPermutation Recursion\n======================");
            PermutationRecursion.Run();

            Console.WriteLine("\n======================\nBinarySearch Recursion\n======================");
            BinarySearchRecursion.Run();

            Console.WriteLine("\n======================\nSumRecursion Recursion\n======================");
            SumRecursion.Run();
        }
    }
}