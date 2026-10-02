using System;

namespace UniversityMembers
{
    // =====================================================
    // الطبقة الأساسية: Person
    // =====================================================
    public class Person
    {
        // الخصائص
        public string Name { get; set; }
        public string Email { get; set; }

        // البناء (Constructor) - يُنفذ أولاً في التسلسل الهرمي
        public Person(string name, string email)
        {
            Name = name;
            Email = email;
            Console.WriteLine("  [Constructor] Person constructor executed.");
        }

        // دالة لعرض المعلومات الأساسية
        public void DisplayBasicInfo()
        {
            Console.WriteLine($"  Name: {Name}");
            Console.WriteLine($"  Email: {Email}");
        }
    }

    // =====================================================
    // الطبقة المشتقة: Student (يرث من Person)
    // =====================================================
    public class Student : Person
    {
        // خصائص خاصة بـ Student
        public string StudentId { get; set; }
        public double GPA { get; set; }

        // البناء - يستدعي بناء Person باستخدام base(...)
        public Student(string name, string email, string studentId, double gpa)
            : base(name, email)  // يستدعي بناء الطبقة الأساسية أولاً
        {
            StudentId = studentId;
            GPA = gpa;
            Console.WriteLine("  [Constructor] Student constructor executed.");
        }

        // دالة خاصة بـ Student
        public void DisplayStudentInfo()
        {
            Console.WriteLine("  --- Student Information ---");
            DisplayBasicInfo();  // استدعاء دالة موروثة
            Console.WriteLine($"  Student ID: {StudentId}");
            Console.WriteLine($"  GPA: {GPA}");
        }
    }

    // =====================================================
    // الطبقة المشتقة: Employee (يرث من Person)
    // =====================================================
    public class Employee : Person
    {
        // خصائص خاصة بـ Employee
        public string EmployeeId { get; set; }
        public double Salary { get; set; }

        // البناء - يستدعي بناء Person باستخدام base(...)
        public Employee(string name, string email, string employeeId, double salary)
            : base(name, email)  // يستدعي بناء الطبقة الأساسية أولاً
        {
            EmployeeId = employeeId;
            Salary = salary;
            Console.WriteLine("  [Constructor] Employee constructor executed.");
        }

        // دالة خاصة بـ Employee
        public void DisplayEmployeeInfo()
        {
            Console.WriteLine("  --- Employee Information ---");
            DisplayBasicInfo();  // استدعاء دالة موروثة
            Console.WriteLine($"  Employee ID: {EmployeeId}");
            Console.WriteLine($"  Salary: {Salary:C}");
        }
    }

    // =====================================================
    // الطبقة المشتقة: Teacher (يرث من Employee)
    // =====================================================
    public class Teacher : Employee
    {
        // خصائص خاصة بـ Teacher
        public string CourseName { get; set; }

        // البناء - يستدعي بناء Employee باستخدام base(...)
        public Teacher(string name, string email, string employeeId, double salary, string courseName)
            : base(name, email, employeeId, salary)  // يستدعي بناء Employee أولاً
        {
            CourseName = courseName;
            Console.WriteLine("  [Constructor] Teacher constructor executed.");
        }

        // دالة خاصة بـ Teacher
        public void Teach()
        {
            Console.WriteLine($"  {Name} is teaching {CourseName}.");
        }

        // دالة لعرض كل المعلومات
        public void DisplayTeacherInfo()
        {
            Console.WriteLine("  --- Teacher Information ---");
            DisplayEmployeeInfo();  // استدعاء دالة موروثة من Employee
            Console.WriteLine($"  Course: {CourseName}");
        }
    }

    // =====================================================
    // البرنامج الرئيسي
    // =====================================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("  University Members Hierarchy Demo");
            Console.WriteLine("========================================\n");

            // إنشاء كائن من Student
            Console.WriteLine(">> Creating Student object:");
            Student student = new Student(
                name: "Ahmed Ali",
                email: "ahmed@university.edu",
                studentId: "STU-2024-001",
                gpa: 3.75
            );

            Console.WriteLine("\n>> Calling Student methods:");
            student.DisplayStudentInfo();      // دالة متخصصة
            student.DisplayBasicInfo();        // دالة موروثة من Person

            Console.WriteLine("\n----------------------------------------\n");

            // إنشاء كائن من Teacher
            Console.WriteLine(">> Creating Teacher object:");
            Teacher teacher = new Teacher(
                name: "Dr. Sara Mohammed",
                email: "sara.m@university.edu",
                employeeId: "EMP-1005",
                salary: 85000,
                courseName: "Advanced C# Programming"
            );

            Console.WriteLine("\n>> Calling Teacher methods:");
            teacher.DisplayTeacherInfo();      // دالة متخصصة
            teacher.Teach();                   // دالة متخصصة
            teacher.DisplayEmployeeInfo();     // دالة موروثة من Employee
            teacher.DisplayBasicInfo();        // دالة موروثة من Person

            Console.WriteLine("\n========================================");
            Console.WriteLine("  Constructor Execution Order:");
            Console.WriteLine("  Person -> Employee -> Teacher");
            Console.WriteLine("========================================");
        }
    }
}
