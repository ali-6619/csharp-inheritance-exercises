using System;

namespace VehicleHierarchy
{
    // =====================================================
    // الطبقة الأساسية: Vehicle
    // =====================================================
    public class Vehicle
    {
        // الخصائص
        public string Brand { get; set; }
        public int Year { get; set; }

        // البناء (Constructor)
        public Vehicle(string brand, int year)
        {
            Brand = brand;
            Year = year;
            Console.WriteLine($"  [Constructor] Vehicle constructor executed for {Brand}.");
        }

        // دالة التشغيل
        public void Start()
        {
            Console.WriteLine($"  The {Brand} vehicle is starting...");
        }
    }

    // =====================================================
    // الطبقة المشتقة: Car (يرث من Vehicle)
    // =====================================================
    public class Car : Vehicle
    {
        // خاصية خاصة بـ Car
        public int NumberOfDoors { get; set; }

        // البناء - يستدعي بناء Vehicle باستخدام base(...)
        public Car(string brand, int year, int numberOfDoors)
            : base(brand, year)
        {
            NumberOfDoors = numberOfDoors;
            Console.WriteLine($"  [Constructor] Car constructor executed ({NumberOfDoors} doors).");
        }
    }

    // =====================================================
    // الطبقة المشتقة: Bus (يرث من Vehicle)
    // =====================================================
    public class Bus : Vehicle
    {
        // خاصية خاصة بـ Bus
        public int Capacity { get; set; }

        // البناء - يستدعي بناء Vehicle باستخدام base(...)
        public Bus(string brand, int year, int capacity)
            : base(brand, year)
        {
            Capacity = capacity;
            Console.WriteLine($"  [Constructor] Bus constructor executed (Capacity: {Capacity} passengers).");
        }
    }

    // =====================================================
    // الطبقة المشتقة: Motorcycle (يرث من Vehicle)
    // =====================================================
    public class Motorcycle : Vehicle
    {
        // خاصية خاصة بـ Motorcycle
        public bool HasSidecar { get; set; }

        // البناء - يستدعي بناء Vehicle باستخدام base(...)
        public Motorcycle(string brand, int year, bool hasSidecar)
            : base(brand, year)
        {
            HasSidecar = hasSidecar;
            Console.WriteLine($"  [Constructor] Motorcycle constructor executed (HasSidecar: {HasSidecar}).");
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
            Console.WriteLine("  Vehicle Hierarchy Demo");
            Console.WriteLine("========================================\n");

            // إنشاء كائن من Car
            Console.WriteLine(">> Creating Car object:");
            Car car = new Car(brand: "Toyota", year: 2023, numberOfDoors: 4);
            Console.Write("  Car -> ");
            car.Start();  // استدعاء دالة موروثة

            Console.WriteLine();

            // إنشاء كائن من Bus
            Console.WriteLine(">> Creating Bus object:");
            Bus bus = new Bus(brand: "Mercedes", year: 2022, capacity: 50);
            Console.Write("  Bus -> ");
            bus.Start();  // استدعاء دالة موروثة

            Console.WriteLine();

            // إنشاء كائن من Motorcycle
            Console.WriteLine(">> Creating Motorcycle object:");
            Motorcycle motorcycle = new Motorcycle(brand: "Harley-Davidson", year: 2024, hasSidecar: true);
            Console.Write("  Motorcycle -> ");
            motorcycle.Start();  // استدعاء دالة موروثة

            Console.WriteLine("\n========================================");
            Console.WriteLine("  All vehicles started successfully!");
            Console.WriteLine("========================================");
        }
    }
}
