using Utils;

namespace Shapes;

public class Triangle : Shape
{
    private double[] _sides = null!;

    public Triangle(double side1, double side2, double side3) => TrySetSides(new[] { side1, side2, side3 });

    public override double Area
    {
        get
        {
            var semiperimiter = _sides.Sum() / 2;

            return Math.Sqrt(_sides.Aggregate(semiperimiter, (product, length) => product * (semiperimiter - length)));
        }
    }

    public bool IsRight => Math.Pow(_sides[2], 2).IsCloseTo(Math.Pow(_sides[0], 2) + Math.Pow(_sides[1], 2));

    private void TrySetSides(IEnumerable<double> sides)
    {
        var orderedSides = sides.Order().ToArray();

        if (orderedSides[0] <= 0)
            throw new ArgumentException("All sides' lengths should be positive numbers");

        if (orderedSides[0] + orderedSides[1] <= orderedSides[2])
            throw new ArgumentException("Length of each side should be less than sum of two other");

        _sides = orderedSides;
    }
}