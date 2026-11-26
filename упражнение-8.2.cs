using System;

class Program
{
    static string ReverseText(string text)
    {
        string result = "";

        for (int i = text.Length - 1; i >= 0; i--)
        {
            result = result + text[i];
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine("Упражнение 8.2. Строка в обратном порядке.");
        Console.WriteLine("Примеры заданы в коде. Ввод не требуется.");

        Console.WriteLine($"«Привет» -> «{ReverseText("Привет")}»");
        Console.WriteLine($"«Кот спит!» -> «{ReverseText("Кот спит!")}»");
        Console.WriteLine($"«» -> «{ReverseText("")}»");
    }
}