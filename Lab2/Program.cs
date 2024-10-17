using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число N: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Введите количество потоков М: ");
            int M = int.Parse(Console.ReadLine());

            string filePath = "C:/Users/Sutyagin/source/repos/Lab2/Lab2/output.txt";
            string filePath1 = "C:/Users/Sutyagin/source/repos/Lab2/Lab2/result.txt";

            FileOperations.GenerateNumbersFile(N, filePath); // Генерация файла с N числами
            var numbers = FileOperations.ReadNumbersFromFile(filePath); // Чтение чисел из файла

            ProcessNumbersInParallel(numbers, M); // Параллельная обработка чисел

            FileOperations.WriteNumbersToFile(numbers, filePath1); // Запись обработанных чисел в файл

            PerformanceTesting.TestPerformance(); // Тестирование производительности
            PerformanceTesting.TestMathOperations(); // Тестирование математических операций

            ConcurrentProcessing.RunConcurrentProcessing(); // Запуск параллельной обработки
        }

        static void ProcessNumbersInParallel(int[] numbers, int M) // метод, который выполняет параллельную обработку массива чисел
        {
            int chunkSize = (int)Math.Ceiling((double)numbers.Length / M);
            Task[] tasks = new Task[M];

            for (int i = 0; i < M; i++)
            {
                int start = i * chunkSize;
                int end = Math.Min(start + chunkSize, numbers.Length);
                tasks[i] = Task.Run(() =>
                {
                    for (int j = start; j < end; j++)
                    {
                        numbers[j] *= 2; // Умножение каждого числа на 2
                    }
                });
            }

            Task.WaitAll(tasks); // Ожидание завершения всех задач
        }
    }
}