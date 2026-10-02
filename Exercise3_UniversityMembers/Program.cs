using Exercise3UniversityMembers;

namespace Exercise3UniversityMembers;

public static class Program
{
    // Method that accepts Person and calls DisplayInfo()
    public static void DisplayPersonInfo(Person person)
    {
        person.DisplayInfo();
    }

    public static void Main()
    {
        List<Person> people = new List<Person>();
        people.Add(new Student("Sara Ahmed", "S-2024-118"));
        people.Add(new Employee("Omar Khalil", 12500m));
        people.Add(new Teacher("Mona Hassan", "OOP 204"));

        foreach (var person in people)
        {
            Console.WriteLine($"Runtime type: {person.GetType()}");
            person.DisplayInfo();
            Console.WriteLine();
        }

        Console.WriteLine("--- Via method accepting Person ---");
        DisplayPersonInfo(new Student("Ali Saleh", "S-2024-200"));
    }
}
