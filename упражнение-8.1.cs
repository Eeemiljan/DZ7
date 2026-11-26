using System;

enum BankAccountType
{
    Current,
    Savings
}

class BankAccount
{
    private static int lastNumber = 1000;

    private int number;
    private decimal balance;
    private BankAccountType type;

    private static int GenerateNumber()
    {
        lastNumber++;
        return lastNumber;
    }

    public BankAccount()
    {
        number = GenerateNumber();
    }

    public void SetData(decimal balance, BankAccountType type)
    {
        if (balance < 0)
        {
            Console.WriteLine("Начальный баланс не может быть отрицательным.");
            return;
        }

        this.balance = balance;
        this.type = type;
    }

    public int GetNumber()
    {
        return number;
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public BankAccountType GetAccountType()
    {
        return type;
    }

    public bool Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        balance = balance + amount;
        return true;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > balance)
        {
            return false;
        }

        balance = balance - amount;
        return true;
    }

    public bool TransferFrom(BankAccount fromAccount, decimal amount)
    {
        if (fromAccount == this)
        {
            return false;
        }

        if (!fromAccount.Withdraw(amount))
        {
            return false;
        }

        Deposit(amount);
        return true;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Упражнение 8.1. Перевод денег между счетами.");
        Console.WriteLine("Суммы заданы в коде. Ввод не требуется.");

        BankAccount first = new BankAccount();
        first.SetData(15000m, BankAccountType.Current);

        BankAccount second = new BankAccount();
        second.SetData(5000m, BankAccountType.Savings);

        Console.WriteLine($"До перевода: счёт {first.GetNumber()} — {first.GetBalance()}, счёт {second.GetNumber()} — {second.GetBalance()}.");

        if (second.TransferFrom(first, 3000m))
        {
            Console.WriteLine("Перевод 3000 выполнен.");
        }

        Console.WriteLine($"После перевода: счёт {first.GetNumber()} — {first.GetBalance()}, счёт {second.GetNumber()} — {second.GetBalance()}.");

        if (!second.TransferFrom(first, 20000m))
        {
            Console.WriteLine("Перевод 20000 отклонён.");
        }

        Console.WriteLine($"Итог: счёт {first.GetNumber()} — {first.GetBalance()}, счёт {second.GetNumber()} — {second.GetBalance()}.");
    }
}