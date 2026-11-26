using System;
using System.Collections.Generic;

class Song
{
    private string name = "";
    private string author = "";
    private Song? prev;

    public void SetName(string name)
    {
        this.name = name;
    }

    public void SetAuthor(string author)
    {
        this.author = author;
    }

    public void SetPrev(Song? prev)
    {
        this.prev = prev;
    }

    public string Title()
    {
        return name + " — " + author;
    }

    public void Print()
    {
        Console.WriteLine(Title());

        if (prev != null)
        {
            Console.WriteLine($"  Предыдущая: {prev.Title()}");
        }
    }

    public override bool Equals(object? other)
    {
        Song? song = other as Song;

        if (song == null)
        {
            return false;
        }

        return name == song.name && author == song.author;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, author);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Домашнее задание 8.2. Список песен.");
        Console.WriteLine("Учебные данные заданы в коде. Ввод не требуется.");

        Song first = new Song();
        first.SetName("Утро");
        first.SetAuthor("Анна");
        first.SetPrev(null);

        Song second = new Song();
        second.SetName("Огни города");
        second.SetAuthor("Илья");
        second.SetPrev(first);

        Song third = new Song();
        third.SetName("Дорога домой");
        third.SetAuthor("Лена");
        third.SetPrev(second);

        Song fourth = new Song();
        fourth.SetName("Тихий вечер");
        fourth.SetAuthor("Максим");
        fourth.SetPrev(third);

        List<Song> songs = new List<Song>();
        songs.Add(first);
        songs.Add(second);
        songs.Add(third);
        songs.Add(fourth);

        foreach (Song song in songs)
        {
            song.Print();
        }

        if (songs[0].Equals(songs[1]))
        {
            Console.WriteLine("Первая и вторая песни совпадают.");
        }
        else
        {
            Console.WriteLine("Первая и вторая песни различаются.");
        }
    }
}