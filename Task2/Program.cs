namespace Task2;

using System;

class Program
{
    // Оголошення делегата, який приймає номер кольору і викликає відповідний метод
    delegate void ColorDelegate();

    static void Main(string[] args)
    {
        // Зчитуємо порядковий номер кольору
        Console.WriteLine("Введіть номер кольору (1-7):");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Потрібно було ввести число");
            return;
        }

        if (int.TryParse(input, out int colorNumber) && colorNumber >= 1 && colorNumber <= 7)
        {
            // В залежності від номера викликаємо відповідний метод
            ColorDelegate colorMethod = colorNumber switch
            {
                1 => RedColor,
                2 => OrangeColor,
                3 => YellowColor,
                4 => GreenColor,
                5 => LightBlueColor,
                6 => BlueColor,
                7 => VioletColor,
                _ => null // Це навряд чи буде викликано, бо ми перевіряємо обмеження
            };

            // Якщо метод знайдений, викликаємо його
            colorMethod?.Invoke();
        }
        else
        {
            Console.WriteLine("Невірний номер кольору. Введіть число від 1 до 7.");
        }
    }

    // Метод для червоного кольору
    static void RedColor()
    {
        Console.WriteLine("Червоний: RGB(255, 0, 0)");
    }

    // Метод для помаранчевого кольору
    static void OrangeColor()
    {
        Console.WriteLine("Помаранчевий: RGB(255, 165, 0)");
    }

    // Метод для жовтого кольору
    static void YellowColor()
    {
        Console.WriteLine("Жовтий: RGB(255, 255, 0)");
    }

    // Метод для зеленого кольору
    static void GreenColor()
    {
        Console.WriteLine("Зелений: RGB(0, 255, 0)");
    }

    // Метод для блакитного кольору
    static void LightBlueColor()
    {
        Console.WriteLine("Блакитний: RGB(0, 255, 255)");
    }

    // Метод для синього кольору
    static void BlueColor()
    {
        Console.WriteLine("Синій: RGB(0, 0, 255)");
    }

    // Метод для фіолетового кольору
    static void VioletColor()
    {
        Console.WriteLine("Фіолетовий: RGB(238, 130, 238)");
    }
}