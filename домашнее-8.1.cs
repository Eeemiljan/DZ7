using System;
using System.IO;

class Program
{
    public void SearchMail(ref string s)
    {
        int separator = s.IndexOf("#");

        if (separator == -1)
        {
            s = "";
            return;
        }

        int start = separator + 1;
        s = s.Substring(start, s.Length - start).Trim();
    }

    static void Main()
    {
        Console.WriteLine("Домашнее задание 8.1. Извлечение адресов почты.");
        Console.WriteLine("Подготовьте contacts.txt: одна запись «ФИО # почта» на строку.");

        string inputName = "contacts.txt";
        string outputName = "emails.txt";

        if (!File.Exists(inputName))
        {
            Console.WriteLine($"Файл {inputName} не найден.");
            return;
        }

        if (File.Exists(outputName))
        {
            Console.WriteLine($"Файл {outputName} уже существует.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(inputName);
            string[] emails = new string[lines.Length];
            Program program = new Program();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                program.SearchMail(ref line);

                if (line == "")
                {
                    Console.WriteLine($"В строке {i + 1} нет адреса после #.");
                    return;
                }

                emails[i] = line;
            }

            File.WriteAllLines(outputName, emails);
            Console.WriteLine($"Записано адресов: {emails.Length}. Файл: {outputName}");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Ошибка при работе с файлом: {error.Message}");
        }
    }
}