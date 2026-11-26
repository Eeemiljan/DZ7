using System;

enum Department
{
    Other,
    Management,
    System,
    Development
}

class Employee
{
    public string Name { get; }
    public Department Department { get; }

    private Employee? manager;
    private Employee? secondManager;

    public Employee(string name, Department department,
        Employee? manager = null, Employee? secondManager = null)
    {
        Name = name;
        Department = department;
        this.manager = manager;
        this.secondManager = secondManager;
    }

    public bool HasManager(Employee person)
    {
        return person == manager || person == secondManager;
    }
}

class WorkTask
{
    public string Name { get; }
    public Department TargetDepartment { get; }

    public WorkTask(string name, Department targetDepartment)
    {
        Name = name;
        TargetDepartment = targetDepartment;
    }
}

class Program
{
    static void AssignTask(Employee sender, Employee receiver, WorkTask task)
    {
        Console.WriteLine($"{sender.Name} даёт задачу «{task.Name}» сотруднику {receiver.Name}.");

        if (!receiver.HasManager(sender))
        {
            Console.WriteLine("Не берёт: задачу дал не прямой руководитель.");
        }
        else if (receiver.Department != task.TargetDepartment)
        {
            Console.WriteLine("Не берёт: задача предназначена для другого отдела.");
        }
        else
        {
            Console.WriteLine("Берёт задачу.");
        }

        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("Проект 7. Назначение задач в компании.");
        Console.WriteLine("Сотрудники и задачи заданы в коде. Ввод не требуется.");
        Console.WriteLine();

        Employee timur = new Employee("Тимур", Department.Other);
        Employee rashid = new Employee("Рашид", Department.Other, timur);
        Employee ilham = new Employee("О Ильхам", Department.Other, timur);
        Employee lukas = new Employee("Лукас", Department.Other, rashid);

        Employee orkady = new Employee("Оркадий", Department.Management, ilham);
        Employee volodya = new Employee("Володя", Department.Management, orkady);

        Employee ilshat = new Employee("Ильшат", Department.System, orkady, volodya);
        Employee ivanych = new Employee("Иваныч", Department.System, ilshat);
        Employee ilya = new Employee("Илья", Department.System, ivanych);
        Employee vitya = new Employee("Витя", Department.System, ivanych);
        Employee zhenya = new Employee("Женя", Department.System, ivanych);

        Employee sergey = new Employee("Сергей", Department.Development, orkady, volodya);
        Employee laysan = new Employee("Ляйсан", Department.Development, sergey);
        Employee marat = new Employee("Марат", Department.Development, laysan);
        Employee dina = new Employee("Дина", Department.Development, laysan);
        Employee ildar = new Employee("Ильдар", Department.Development, laysan);
        Employee anton = new Employee("Антон", Department.Development, laysan);

        WorkTask plan = new WorkTask("Составить план автоматизации", Department.Management);
        WorkTask network = new WorkTask("Проверить сеть", Department.System);
        WorkTask automation = new WorkTask("Автоматизировать отчёт бухгалтерии",
            Department.Development);

        AssignTask(lukas, dina, automation);
        AssignTask(ilham, orkady, plan);

        AssignTask(orkady, ilshat, network);
        AssignTask(ilshat, ivanych, network);
        AssignTask(ivanych, ilya, network);
        AssignTask(ivanych, vitya, network);
        AssignTask(ivanych, zhenya, network);

        AssignTask(orkady, sergey, network);
        AssignTask(volodya, sergey, automation);
        AssignTask(sergey, laysan, automation);
        AssignTask(laysan, marat, automation);
        AssignTask(laysan, dina, automation);
        AssignTask(laysan, ildar, automation);
        AssignTask(laysan, anton, automation);
    }
}