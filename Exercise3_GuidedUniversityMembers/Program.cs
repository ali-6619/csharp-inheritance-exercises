using Exercise3GuidedUniversityMembers;

namespace Exercise3GuidedUniversityMembers;

public static class Program
{
    public static void PrintInfo(Person person)
    {
        Console.WriteLine($"  Runtime type: {person.GetType().Name}");
        person.DisplayInfo();
        Console.WriteLine();
    }

    public static void Main()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine(" Guided Exercise - University Members");
        Console.WriteLine("==================================================");
        Console.WriteLine("Hierarchy:   Person");
        Console.WriteLine("                |-- Student");
        Console.WriteLine("                |-- Employee");
        Console.WriteLine("                `-- Teacher");
        Console.WriteLine();

        List<Person> members = new List<Person>
        {
            new Student("Sara Ahmed", "S-2024-118"),
            new Employee("Omar Khalil", 12500m),
            new Teacher("Layla Hassan", "OOP 204")
        };

        Console.WriteLine("--- Loop over List<Person> ---");
        foreach (Person member in members)
        {
            Console.WriteLine($"  GetType() -> {member.GetType()}");
            member.DisplayInfo();
            Console.WriteLine();
        }

        Console.WriteLine("--- Calling the method that accepts a Person ---");
        foreach (Person member in members)
        {
            PrintInfo(member);
        }
    }
}
