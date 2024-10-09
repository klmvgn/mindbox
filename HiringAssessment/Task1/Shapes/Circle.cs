namespace Shapes;

public class Circle : Shape
{
    private double _radius;

    public Circle(double radius) => TrySetRadius(radius);

    public override double Area => Math.PI * Math.Pow(_radius, 2);

    private void TrySetRadius(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius should be a positive number");

        _radius = radius;
    }
}