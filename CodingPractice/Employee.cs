using System;

public class Employee
{
    public string Name { get; set; }

    public Employee(string name)
    {
        Name = name;
    }

    // virtual allows derived classes to override
    public virtual void Work()
    {
        Console.WriteLine($"{Name} is working on general tasks.");
    }
}

public class Manager : Employee
{
    public Manager(string name) : base(name) { }

    public override void Work()
    {
        Console.WriteLine($"{Name} is managing the team and delegating tasks.");
    }
}

public class Intern : Employee
{
    public Intern(string name) : base(name) { }

    public override void Work()
    {
        Console.WriteLine($"{Name} is assisting with small tasks and learning new skills.");
    }
}

class Program
{
    static void Main()
    {
        Employee emp1 = new Employee("Alice");
        Employee mgr = new Manager("Bob");
        Employee intern = new Intern("Charlie");

        // Polymorphism in action
        emp1.Work();
        mgr.Work();
        intern.Work();
    }
}
