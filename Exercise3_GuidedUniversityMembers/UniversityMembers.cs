namespace Exercise3GuidedUniversityMembers;

public class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"  Name: {Name}");
    }
}

public class Student : Person
{
    public string StudentId { get; set; }

    public Student(string name, string studentId) : base(name)
    {
        StudentId = studentId;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"  Name: {Name} | StudentId: {StudentId}");
    }
}

public class Employee : Person
{
    public decimal Salary { get; set; }

    public Employee(string name, decimal salary) : base(name)
    {
        Salary = salary;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"  Name: {Name} | Salary: {Salary:C}");
    }
}

public class Teacher : Person
{
    public string CourseName { get; set; }

    public Teacher(string name, string courseName) : base(name)
    {
        CourseName = courseName;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"  Name: {Name} | CourseName: {CourseName}");
    }
}
