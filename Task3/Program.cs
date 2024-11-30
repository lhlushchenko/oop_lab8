namespace Task3;
using System;

class Program
{
    // Оголошуємо універсальний делегат, який приймає два параметри типу double і повертає результат типу double
    delegate double ArithmeticOperation(double a, double b);

    static void Main(string[] args)
    {
        // Запит користувача на введення операції
        Console.WriteLine("Виберіть операцію (+, -, *, /):");
        string operation = Console.ReadLine();

        // Запит користувача на введення чисел
        Console.WriteLine("Введіть перше число:");
        string input1 = Console.ReadLine();
        Console.WriteLine("Введіть друге число:");
        string input2 = Console.ReadLine();

        // Перевірка на коректність введення чисел
        if (!double.TryParse(input1, out double num1) || !double.TryParse(input2, out double num2))
        {
            Console.WriteLine("Введено некоректні числа.");
            return;
        }

        // Оголошуємо змінну для делегата
        ArithmeticOperation operationMethod = null;

        // Визначаємо, який метод викликати залежно від вибору операції
        switch (operation)
        {
            case "+":
                operationMethod = Add;
                break;
            case "-":
                operationMethod = Subtract;
                break;
            case "*":
                operationMethod = Multiply;
                break;
            case "/":
                operationMethod = Divide;
                break;
            default:
                Console.WriteLine("Невідома операція.");
                return;
        }

        // Викликаємо відповідний метод через делегат та виводимо результат
        try
        {
            double result = operationMethod(num1, num2);
            Console.WriteLine($"Результат: {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Помилка: ділення на нуль.");
        }
    }

    // Метод для додавання
    static double Add(double a, double b)
    {
        return a + b;
    }

    // Метод для віднімання
    static double Subtract(double a, double b)
    {
        return a - b;
    }

    // Метод для множення
    static double Multiply(double a, double b)
    {
        return a * b;
    }

    // Метод для ділення
    static double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException();
        }
        return a / b;
    }
}