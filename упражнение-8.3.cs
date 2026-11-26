using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Упражнение 8.3. Запись текста заглавными буквами.");
        Console.Write("Введите имя исходного файла: ");
        string? fileName = Console.ReadLine();

        if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
        {
            Console.WriteLine("Исходный файл не найден.");
            return;
        }

        string outputName = fileName + ".upper.txt";

        if (File.Exists(outputName))
        {
            Console.WriteLine($"Выходной файл уже существует: {outputName}");
            return;
        }

        try
        {
            string text = File.ReadAllText(fileName);
            string upperText = text.ToUpper();
            File.WriteAllText(outputName, upperText);

            Console.WriteLine($"Результат записан в файл {outputName}");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Ошибка при работе с файлом: {error.Message}");
        }
    }
}