namespace Exercise1VehicleHierarchy;

// ---------------------------------------------------------------
// Base class
// ---------------------------------------------------------------
public class Vehicle
{
    public string Brand { get; set; }
    public int Year { get; set; }

    public Vehicle(string brand, int year)
    {
        Brand = brand;
        Year = year;
        Console.WriteLine($"  [Vehicle ctor]      Brand = {Brand}, Year = {Year}");
    }

    public void Start()
    {
        Console.WriteLine($"  {Brand} ({Year}) is starting...");
    }
}

// ---------------------------------------------------------------
// Derived class 1
// ---------------------------------------------------------------
public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }

    public Car(string brand, int year, int numberOfDoors) : base(brand, year)
    {
        NumberOfDoors = numberOfDoors;
        Console.WriteLine($"  [Car ctor]          NumberOfDoors = {NumberOfDoors}");
    }
}

// ---------------------------------------------------------------
// Derived class 2
// ---------------------------------------------------------------
public class Bus : Vehicle
{
    public int Capacity { get; set; }

    public Bus(string brand, int year, int capacity) : base(brand, year)
    {
        Capacity = capacity;
        Console.WriteLine($"  [Bus ctor]          Capacity = {Capacity}");
    }
}

// ---------------------------------------------------------------
// Derived class 3
// ---------------------------------------------------------------
public class Motorcycle : Vehicle
{
    public bool HasSidecar { get; set; }

    public Motorcycle(string brand, int year, bool hasSidecar) : base(brand, year)
    {
        HasSidecar = hasSidecar;
        Console.WriteLine($"  [Motorcycle ctor]   HasSidecar = {HasSidecar}");
    }
}
