using Exercise4ShapeAreas;

namespace Exercise4ShapeAreas;

public static class Program
{
    public static void Main()
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Circle(5));
        shapes.Add(new Rectangle(4, 6));

        foreach (var shape in shapes)
        {
            Console.WriteLine($"Type: {shape.GetType().Name}, Area: {shape.CalculateArea():F2}");
        }
    }
}
