using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; //позволяет использовать асинхронное программирование и задачи
using System.Collections.Concurrent; //включает коллекции, которые безопасны для использования в многопоточных средах.

namespace Lab2
{
    public static class ConcurrentProcessing
    {
        public static void RunConcurrentProcessing() //Запуск параллельной обработки
        {
            //пункт 6 ConcurrentBag - Это потокобезопасная коллекция, которая позволяет добавлять и извлекать элементы из разных потоков без необходимости в блокировках.
            var elements = new ConcurrentBag<int>(); //создаем экземпляр ConcurrentBag<int>() и заполняем его миллионом целых чисел от 0 до 999999
            for (int i = 0; i < 1000000; i++)
            {
                elements.Add(i);
            }

            //Параллельное выполнение запускаем 2 задачи с помощью метода Parallel.Invoke
            Parallel.Invoke(
                () => ProcessSmallBatch(elements, 10), //обрабатываем 10 элементов
                () => ProcessLargeBatch(elements, 1000000) //обрабатываем 1000000 элементов
            );
        }

        private static void ProcessLargeBatch(ConcurrentBag<int> elements, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (elements.TryTake(out int element))//Если элемент успешно извлечен, мы выводим его на консоль
                {
                    // Обработка элемента
                    Console.WriteLine($"Обработан элемент: {element}");
                }
            }
        }

        private static void ProcessSmallBatch(ConcurrentBag<int> elements, int count)
        {
            for (int i = 0; i < count; i++)
            {   //TryTake это метод, который пытается извлечь элемент из ConcurrentBag. Если элемент успешно извлечен, он возвращает true, и элемент становится доступным для обработки.
                if (elements.TryTake(out int element))//Если элемент успешно извлечен, мы выводим его на консоль
                {
                    // Обработка элемента
                    Console.WriteLine($"Обработан элемент: {element}");
                }
            }
        }
    }
}