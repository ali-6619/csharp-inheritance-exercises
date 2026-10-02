using System;

// ============================================
// Exercise 1: Vehicle Hierarchy
// ============================================

public class Vehicle
{
    public string Brand { get; set; }
    public int Year { get; set; }

    public Vehicle(string brand, int year)
    {
        Brand = brand;
        Year = year;
    }

    public void Start()
    {
        Console.WriteLine($"The {Brand} vehicle from {Year} is starting...");
    }
}

public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }

    public Car(string brand, int year, int numberOfDoors) : base(brand, year)
    {
        NumberOfDoors = numberOfDoors;
    }
}

public class Bus : Vehicle
{
    public int Capacity { get; set; }

    public Bus(string brand, int year, int capacity) : base(brand, year)
    {
        Capacity = capacity;
    }
}

public class Motorcycle : Vehicle
{
    public bool HasSidecar { get; set; }

    public Motorcycle(string brand, int year, bool hasSidecar) : base(brand, year)
    {
        HasSidecar = hasSidecar;
    }
}

// ============================================
// Exercise 2: University Members Hierarchy
// ============================================

public class Person
{
    public string Name { get; set; }
    public string Email { get; set; }

    public Person(string name, string email)
    {
        Console.WriteLine("Person constructor called.");
        Name = name;
        Email = email;
    }

    public void DisplayBasicInfo()
    {
        Console.WriteLine($"Name: {Name}, Email: {Email}");
    }
}

public class Student : Person
{
    public string StudentId { get; set; }
    public double GPA { get; set; }

    public Student(string name, string email, string studentId, double gpa) : base(name, email)
    {
        Console.WriteLine("Student constructor called.");
        StudentId = studentId;
        GPA = gpa;
    }
}

public class Employee : Person
{
    public string EmployeeId { get; set; }
    public double Salary { get; set; }

    public Employee(string name, string email, string employeeId, double salary) : base(name, email)
    {
        Console.WriteLine("Employee constructor called.");
        EmployeeId = employeeId;
        Salary = salary;
    }
}

public class Teacher : Employee
{
    public string CourseName { get; set; }

    public Teacher(string name, string email, string employeeId, double salary, string courseName) 
        : base(name, email, employeeId, salary)
    {
        Console.WriteLine("Teacher constructor called.");
        CourseName = courseName;
    }

    public void Teach()
    {
        Console.WriteLine($"{Name} is teaching {CourseName}.");
    }
}

// ============================================
// Main Program
// ============================================

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Vehicle Hierarchy Demo ===\n");

        Car myCar = new Car("Toyota", 2023, 4);
        Bus myBus = Bus("Mercedes", 2022, 50);
        Motorcycle myMotorcycle = new Motorcycle("Honda", 2021, false);

        myCar.Start();
        myBus.Start();
        myMotorcycle.Start();

        Console.WriteLine("\n=== University Members Demo ===\n");

        Student student = new Student("Ahmed", "ahmed@university.edu", "S12345", 3.8);
        Teacher teacher = new Teacher("Dr. Sara", "sara@university.edu", "E987", 75000, "Computer Science");

        Console.WriteLine("\n--- Calling inherited method ---");
        student.DisplayBasicInfo();
        teacher.DisplayBasicInfo();

        Console.WriteLine("\n--- Calling specialized method ---");
        teacher.Teach();
    }
}
