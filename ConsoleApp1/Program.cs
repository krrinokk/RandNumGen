using System;
using System.Collections.Generic;

namespace lab1
{
    class Program
    {
        static void Main()
        {// Инициализация параметров для линейного конгруэнтного метода
            int multiplier = 1;            // Множитель
            int increment = 5;              // Приращение
            int modulus = (int)Math.Pow(2, 8);  // Модуль (2 в степени 8)
            int initialTerm = 1;          // Начальный член последовательности

            // Генерация последовательности с использованием линейного конгруэнтного метода
            List<int> sequence = GenerateSequence(multiplier, increment, modulus, initialTerm);

            // Вывод сгенерированной последовательности на экран
            DisplaySequence("Последовательность:", sequence);

            // Вывод чисел, которые ни разу не были сгенерированы
            DisplayNotGeneratedNumbers("Ни разу не были сгенерированы:", sequence, modulus);

            // Вывод чисел, сгенерированных более одного раза
            DisplayRepeatingNumbers("Сгенерированные более одного раза:", sequence);

            // Генерация случайной последовательности
            List<int> randomSequence = GenerateRandomSequence(modulus);

            // Вывод сгенерированной случайной последовательности на экран
            DisplaySequence("Random последовательность:", randomSequence);

            // Вывод чисел, которые ни разу не были сгенерированы в случайной последовательности
            DisplayNotGeneratedNumbers("Ни разу не были сгенерированы:", randomSequence, modulus);

            // Вывод чисел, сгенерированных более одного раза в случайной последовательности
            DisplayRepeatingNumbers("Сгенерированные более одного раза:", randomSequence);

        }

        static List<int> GenerateSequence(int multiplier, int increment, int modulus, int initialTerm)
        {
            // Создаем список для хранения последовательности
            List<int> sequence = new List<int>();

            // Инициализируем последовательность начальным значением
            sequence.Add(initialTerm);

            // Генерация последовательности с использованием линейного конгруэнтного метода
            for (int i = 0; i < modulus; i++)
            {
                // Рассчитываем следующий элемент последовательности
                int nextElement = (increment * sequence[i] + multiplier) % modulus;

                // Добавляем элемент в последовательность
                sequence.Add(nextElement);
            }

            // Возвращаем сгенерированную последовательность
            return sequence;
        }
        static List<int> GenerateRandomSequence(int modulus)
        {
            // Создаем генератор случайных чисел
            Random randomGenerator = new Random();

            // Создаем список для хранения случайной последовательности
            List<int> randomSequence = new List<int>();

            // Генерация случайной последовательности чисел от 0 до modulus-1
            for (int i = 0; i < modulus; i++)
            {
                // Генерируем случайное число и добавляем его в последовательность
                int randomElement = randomGenerator.Next(0, modulus);
                randomSequence.Add(randomElement);
            }

            // Возвращаем сгенерированную случайную последовательность
            return randomSequence;
        }
        static void DisplaySequence(string message, List<int> sequence)
        {
            // Выводим пользователю сообщение о том, что будет выведена последовательность
            Console.Write($"{message}\n");

            // Выводим каждый элемент последовательности на экран
            foreach (var num in sequence)
            {
                Console.Write($"{num} ");
            }

            // Переход на новую строку для читаемости вывода
            Console.WriteLine();
        }
        static void DisplayNotGeneratedNumbers(string message, List<int> sequence, int modulus)
        {
            // Выводим пользователю сообщение о том, что будут выведены числа, которые не были сгенерированы
            Console.Write($"{message}\n");

            // Перебираем числа от 0 до modulus-1
            for (int i = 0; i < modulus; i++)
            {
                // Проверяем, было ли число i сгенерировано в последовательности
                if (sequence.IndexOf(i) == -1)
                    Console.Write($"{i} ");
            }

            // Переход на новую строку для читаемости вывода
            Console.WriteLine();
        }
        static void DisplayRepeatingNumbers(string message, List<int> sequence)
        {
            // Выводим пользователю сообщение о том, что будут выведены числа, сгенерированные более одного раза
            Console.Write($"{message}\n");

            // Перебираем элементы последовательности
            for (int i = 0; i < sequence.Count; i++)
            {
                // Проверяем, было ли текущее число сгенерировано более одного раза
                if (sequence.IndexOf(sequence[i]) != -1 && sequence.IndexOf(sequence[i]) != 0 && sequence.IndexOf(sequence[i]) != sequence.LastIndexOf(sequence[i]))
                    Console.Write($"{sequence[i]} ");
            }

            // Переход на новую строку для читаемости вывода
            Console.WriteLine();
        }

    }
}
