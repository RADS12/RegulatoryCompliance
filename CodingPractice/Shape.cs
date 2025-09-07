using System;

public abstract class Shape
{
    public abstract double Area();
    public abstract double Perimeter();
}

public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius must be positive.");
        this.radius = radius;
    }

    public override double Area()
    {
        return Math.PI * radius * radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * radius;
    }
}

public class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        if (width <= 0 || height <= 0)
            throw new ArgumentException("Width and Height must be positive.");
        this.width = width;
        this.height = height;
    }

    public override double Area()
    {
        return width * height;
    }

    public override double Perimeter()
    {
        return 2 * (width + height);
    }
}

class Program
{
    static void Main()
    {
        Shape circle = new Circle(5);
        Shape rectangle = new Rectangle(4, 6);

        Console.WriteLine("Circle:");
        Console.WriteLine("Area: " + circle.Area());
        Console.WriteLine("Perimeter: " + circle.Perimeter());

        Console.WriteLine("\nRectangle:");
        Console.WriteLine("Area: " + rectangle.Area());
        Console.WriteLine("Perimeter: " + rectangle.Perimeter());
    }
}
