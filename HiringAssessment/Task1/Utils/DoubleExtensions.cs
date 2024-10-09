namespace Utils;

public static class DoubleExtensions
{
    private const double DefaultPrecision = 1E-20;

    public static bool IsCloseTo(this double first, double second) => IsCloseTo(first, second, DefaultPrecision);

    private static bool IsCloseTo(this double first, double second, double precision)
        => Math.Abs(first - second) <= precision;
}