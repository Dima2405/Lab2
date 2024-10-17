using System;


namespace Lab2
{
    public static class MathOperations
    {
        public static long Factorial(int n) // Факториал
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }

        public static long Fibonacci(int n) // Фибоначчи
        {
            if (n <= 1) return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}