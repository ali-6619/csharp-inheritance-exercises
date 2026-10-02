using Exercise2UniversityMembers;

namespace Exercise2UniversityMembers;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine(" Exercise 2 - University Members");
        Console.WriteLine("==================================================");
        Console.WriteLine("Hierarchy:   Person");
        Console.WriteLine("                |-- Student");
        Console.WriteLine("                `-- Employee");
        Console.WriteLine("                      `-- Teacher");
        Console.WriteLine();

        // ---- Objects: one Student, one Teacher ------------------
        // The printed order shows the constructor chain:
        //   Student : Person ctor runs first
        //   Teacher : Employee ctor runs first, which runs Person ctor
        Console.WriteLine("--- Creating the objects (constructor order) ---");
        var student = new Student("Sara Ahmed", "sara.ahmed@university.edu", "S-2024-118", 3.85);
        var teacher = new Teacher("Dr. Omar Khalil", "o.khalil@university.edu", "E-1042", 12500m, "OOP 204");

        // ---- Inherited + overridden method ----------------------
        Console.WriteLine();
        Console.WriteLine("--- Student.DisplayBasicInfo() ---");
        student.DisplayBasicInfo();

        Console.WriteLine();
        Console.WriteLine("--- Teacher.DisplayBasicInfo() ---");
        Console.WriteLine("  (Teacher -> Employee -> Person, each layer adds a line)");
        teacher.DisplayBasicInfo();

        // ---- Specialized method ----------------------------------
        Console.WriteLine();
        Console.WriteLine("--- Teacher.Teach() : specialized method ---");
        teacher.Teach();

        // ---- Inherited behaviour through Person reference ------
        Console.WriteLine();
        Console.WriteLine("--- Calling through Person-typed references ---");
        Person[] people = { student, teacher };
        foreach (var person in people)
        {
            person.DisplayBasicInfo();      // virtual -> resolved at runtime
            Console.WriteLine("  ---");
        }

        // ---- Type relationships ----------------------------------
        Console.WriteLine();
        Console.WriteLine("--- Type checks ---");
        foreach (var person in people)
        {
            Console.WriteLine($"  {person.GetType().Name,-8} is Person   -> {person is Person}");
            Console.WriteLine($"  {person.GetType().Name,-8} is Employee -> {person is Employee}");
        }
    }
}
