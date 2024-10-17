using System;
using System.IO;
using System.Linq;

namespace Lab2
{
    public static class FileOperations
    {
        public static void GenerateNumbersFile(int N, string filePath) // Генерация файла от 1 до N
        {
            using (FileStream fileStream = File.Open(filePath, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                for (int i = 1; i <= N; i++)
                {
                    writer.WriteLine(i);
                }
            }
        }

        public static int[] ReadNumbersFromFile(string filePath) // Читает числа из указанного файла и возвращает их в виде массива
        {
            return File.ReadAllLines(filePath).Select(int.Parse).ToArray();
        }

        public static void WriteNumbersToFile(int[] numbers, string filePath) // Записывает массив чисел в указанный файл.
        {
            using (FileStream fileStream = File.Open(filePath, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                foreach (var number in numbers)
                {
                    writer.WriteLine(number);
                }
            }
        }
    }
}
