using Exercise1VehicleHierarchy;

namespace Exercise1VehicleHierarchy;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine(" Exercise 1 - Vehicle Hierarchy");
        Console.WriteLine("==================================================");
        Console.WriteLine("Hierarchy:   Vehicle");
        Console.WriteLine("                |-- Car");
        Console.WriteLine("                |-- Bus");
        Console.WriteLine("                `-- Motorcycle");
        Console.WriteLine();

        // ---- One object of each derived class --------------------
        // The console output shows the execution order:
        // base( Vehicle ) constructor runs FIRST, derived one after.
        Console.WriteLine("--- Creating one object of each derived class ---");
        var car = new Car("Toyota", 2021, 4);
        var bus = new Bus("Mercedes-Benz", 2018, 45);
        var motorcycle = new Motorcycle("Harley-Davidson", 2023, true);

        // ---- Every object can use Start() ------------------------
        // Start() is declared once in Vehicle and never overridden,
        // so all three objects inherit and use the same method.
        Console.WriteLine();
        Console.WriteLine("--- Demonstrating inherited Start() ---");
        car.Start();
        bus.Start();
        motorcycle.Start();

        // ---- Same thing through a Vehicle reference -------------
        // Proves each derived object *is* a Vehicle.
        Console.WriteLine();
        Console.WriteLine("--- Start() via Vehicle-typed references ---");
        Vehicle[] fleet = { car, bus, motorcycle };
        foreach (var vehicle in fleet)
        {
            vehicle.Start();
        }

        // ---- Each object keeps its own extra data ----------------
        Console.WriteLine();
        Console.WriteLine("--- Derived-class members ---");
        Console.WriteLine($"  Car.NumberOfDoors      = {car.NumberOfDoors}");
        Console.WriteLine($"  Bus.Capacity           = {bus.Capacity}");
        Console.WriteLine($"  Motorcycle.HasSidecar  = {motorcycle.HasSidecar}");

        // ---- is / type check -------------------------------------
        Console.WriteLine();
        Console.WriteLine("--- Every derived object is a Vehicle ---");
        foreach (var vehicle in fleet)
        {
            Console.WriteLine($"  {vehicle.GetType().Name,-13} is Vehicle -> {vehicle is Vehicle}");
        }
    }
}
