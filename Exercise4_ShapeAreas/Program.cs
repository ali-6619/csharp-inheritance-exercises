using Exercise4ShapeAreas;

namespace Exercise4ShapeAreas;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine(" Independent Exercise - Shape Areas");
        Console.WriteLine("==================================================");
        Console.WriteLine("Hierarchy:   Shape");
        Console.WriteLine("                |-- Circle");
        Console.WriteLine("                `-- Rectangle");
        Console.WriteLine();

        List<Shape> shapes = new List<Shape>
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Circle(2.5)
        };

        Console.WriteLine("--- Type and area of each shape ---");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"  Type: {shape.GetType().Name,-10} | Area: {shape.CalculateArea():F2}");
        }
    }
}
