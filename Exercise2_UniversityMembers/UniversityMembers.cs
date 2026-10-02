namespace Exercise2UniversityMembers;

// ---------------------------------------------------------------
// Base class (root of the hierarchy)
// ---------------------------------------------------------------
public class Person
{
    public string Name { get; set; }
    public string Email { get; set; }

    public Person(string name, string email)
    {
        Name = name;
        Email = email;
        Console.WriteLine($"  [Person ctor]    Name = {Name}, Email = {Email}");
    }

    public virtual void DisplayBasicInfo()
    {
        Console.WriteLine($"  Name: {Name} | Email: {Email}");
    }
}

// ---------------------------------------------------------------
// Derived class: Student  ( Person -> Student )
// ---------------------------------------------------------------
public class Student : Person
{
    public string StudentId { get; set; }
    public double GPA { get; set; }

    public Student(string name, string email, string studentId, double gpa)
        : base(name, email)              // <-- calls the Person constructor
    {
        StudentId = studentId;
        GPA = gpa;
        Console.WriteLine($"  [Student ctor]   StudentId = {StudentId}, GPA = {GPA}");
    }

    // Overrides Person.DisplayBasicInfo and extends it
    public override void DisplayBasicInfo()
    {
        base.DisplayBasicInfo();        // <-- reuse the parent output
        Console.WriteLine($"  StudentId: {StudentId} | GPA: {GPA}");
    }
}

// ---------------------------------------------------------------
// Derived class: Employee  ( Person -> Employee )
// ---------------------------------------------------------------
public class Employee : Person
{
    public string EmployeeId { get; set; }
    public decimal Salary { get; set; }

    public Employee(string name, string email, string employeeId, decimal salary)
        : base(name, email)
    {
        EmployeeId = employeeId;
        Salary = salary;
        Console.WriteLine($"  [Employee ctor]  EmployeeId = {EmployeeId}, Salary = {Salary}");
    }

    public override void DisplayBasicInfo()
    {
        base.DisplayBasicInfo();
        Console.WriteLine($"  EmployeeId: {EmployeeId} | Salary: {Salary}");
    }
}

// ---------------------------------------------------------------
// Derived class: Teacher  ( Person -> Employee -> Teacher )
// ---------------------------------------------------------------
public class Teacher : Employee
{
    public string CourseName { get; set; }

    public Teacher(string name, string email, string employeeId, decimal salary, string courseName)
        : base(name, email, employeeId, salary)   // <-- calls the Employee constructor
    {
        CourseName = courseName;
        Console.WriteLine($"  [Teacher ctor]   CourseName = {CourseName}");
    }

    public void Teach()
    {
        Console.WriteLine($"  {Name} is teaching '{CourseName}'.");
    }

    public override void DisplayBasicInfo()
    {
        base.DisplayBasicInfo();        // <-- Employee's version, which calls Person's
        Console.WriteLine($"  CourseName: {CourseName}");
    }
}
