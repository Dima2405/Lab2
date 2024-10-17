using System;
using System.Threading.Tasks; //позволяет использовать асинхронное программирование и задачи
using System.Diagnostics; //предоставляет классы для работы с процессами

namespace Lab2
{
    public static class PerformanceTesting
    {
        public static void TestPerformance() // Тестирование производительности параллельных вычислений
        {
            long[] NValues = { 10, 100, 1000, 100000, 1000000, 10000000, 100000000, 1000000000 }; // Различные значения N
            int[] MValues = { 1, 2, 3, 4, 5, 10, 20, 30, 100 }; // М потоки

            Console.WriteLine("N\tM\tВремя (мс)");

            foreach (var N in NValues) //перебирает значения N
            {
                foreach (var M in MValues) // перебирает значения M
                {
                    var watch = Stopwatch.StartNew(); // запуск таймера
                    Parallel.For(0, N, new ParallelOptions { MaxDegreeOfParallelism = M }, i => //Метод  Parallel.For выполняет итерации от 0 до N параллельно, используя заданное количество потоков (M)
                    {
                        // Вычисление квадратного корня
                        var temp = Math.Sqrt(i);
                    });
                    watch.Stop(); // остановка таймера
                    Console.WriteLine($"{N}\t {M}\t{watch.ElapsedMilliseconds}"); // Вывод  время выполнения в миллисекундах
                }
            }
        }

        public static void TestMathOperations() //Измеряет время выполнения различных математических операций
        {
            int[] array = new int[10000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < array.Length; i++)
            {
                Math.Pow(array[i], 2); // Возведение в степень
            }
            stopwatch.Stop();
            Console.WriteLine($"Время возведения в степень: {stopwatch.ElapsedMilliseconds} мс");

            stopwatch.Restart();
            for (int i = 0; i < array.Length; i++)
            {
                MathOperations.Factorial(array[i]); // Факториал
            }
            stopwatch.Stop();
            Console.WriteLine($"Время вычисления факториала: {stopwatch.ElapsedMilliseconds} мс");

            stopwatch.Restart();
            for (int i = 0; i < array.Length; i++) // Операция с плавающей точкой
            {
                float result = (float)array[i] / 3.14f;
            }
            stopwatch.Stop();
            Console.WriteLine($"Время операции с плавающей точкой: {stopwatch.ElapsedMilliseconds} мс");

            stopwatch.Restart();
            for (int i = 0; i < array.Length; i++)
            {
                MathOperations.Fibonacci(array[i]); // Число Фиббоначи
            }
            stopwatch.Stop();
            Console.WriteLine($"Время вычисления числа Фиббоначи: {stopwatch.ElapsedMilliseconds} мс");
        }
    }
}