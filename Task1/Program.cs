namespace Task1;
using System;

class Program
{
    // Оголошення делегата, який буде вказувати на метод, що приймає double і повертає double
    delegate double FuncDelegate(double x);

    // Метод для обчислення F(x) = cos(x + 1), коли x > 0
    static double F1(double x)
    {
        return Math.Cos(x + 1);
    }

    // Метод для обчислення F(x) = 1 - 2 * sin(x), коли x <= 0
    static double F2(double x)
    {
        return 1 - 2 * Math.Sin(x);
    }

    static void Main(string[] args)
    {
        // Зчитуємо введення користувача
        Console.WriteLine("Введіть значення x:");
        string input = Console.ReadLine();

        // Перевірка на порожній ввід
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Потрібно було ввести число");
            return;
        }

        // Спроба перетворити введене значення в число
        if (double.TryParse(input, out double x))
        {
            // Оголошуємо змінну для делегата
            FuncDelegate func;

            // Вибір методу на основі значення x
            if (x > 0)
            {
                func = F1;  // Вибираємо метод для x > 0
            }
            else
            {
                func = F2;  // Вибираємо метод для x <= 0
            }

            // Викликаємо відповідну функцію через делегат
            double result = func(x);

            // Виведення результату
            Console.WriteLine($"Результат обчислення F({x}) = {result}");
        }
        else
        {
            // Якщо введене значення не можна перетворити на число
            Console.WriteLine("Потрібно було ввести число");
        }
    }
}