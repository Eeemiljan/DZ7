using System;

class Program
{
    static bool SupportsFormatting(object value)
    {
        bool supportsInterface = value is IFormattable;
        IFormattable? formattable = value as IFormattable;

        return supportsInterface && formattable != null;
    }

    static void Main()
    {
        Console.WriteLine("Упражнение 8.4. Проверка интерфейса IFormattable.");
        Console.WriteLine("Примеры заданы в коде. Ввод не требуется.");

        Console.WriteLine($"Целое число: {SupportsFormatting(42)}");
        Console.WriteLine($"Десятичное число: {SupportsFormatting(12.5m)}");
        Console.WriteLine($"Строка: {SupportsFormatting("Привет")}");
    }
}