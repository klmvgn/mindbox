using System.Collections;
using FluentAssertions;

namespace Shapes.Tests;

public class ShapesTests
{
    [TestCaseSource(typeof(TestData), nameof(TestData.ModelConsistencyTestCases))]
    public void Ctor(Func<Shape> ctorInvocation, Exception? exception)
    {
        if (exception is null)
        {
            ctorInvocation.Should().NotThrow();
        }
        else
        {
            ctorInvocation
                .Should().Throw<Exception>().Which
                .Should().Match<Exception>(
                    ex => ex.GetType() == exception.GetType() && ex.Message == exception.Message);
        }
    }
    
    [TestCaseSource(typeof(TestData), nameof(TestData.AreaTestCases))]
    public double Area(Shape shape) => shape.Area;

    [TestCaseSource(typeof(TestData), nameof(TestData.TriangleIsRightTestCases))]
    public bool TriangleIsRight(Triangle triangle) => triangle.IsRight;
}

public class TestData
{
    public static IEnumerable ModelConsistencyTestCases
    {
        get
        {
            // Circle
            yield return new TestCaseData(
                () => new Circle(1),
                default);
            yield return new TestCaseData(
                () => new Circle(0),
                new ArgumentException("Radius should be a positive number"));
            // Triangle
            yield return new TestCaseData(
                () => new Triangle(2, 3, 4),
                default);
            yield return new TestCaseData(
                () => new Triangle(-1, 1, 2),
                new ArgumentException("All sides' lengths should be positive numbers"));
            yield return new TestCaseData(
                () => new Triangle(1, 2, 3),
                new ArgumentException("Length of each side should be less than sum of two other"));
        }
    }

    public static IEnumerable AreaTestCases
    {
        get
        {
            // Circle
            yield return new TestCaseData(new Circle(1))
                .Returns(Math.PI);
            yield return new TestCaseData(new Circle(2))
                .Returns(4 * Math.PI);
            // Triangle
            yield return new TestCaseData(new Triangle(1, 1, 1))
                .Returns(Math.Sqrt(3) / 4);
            yield return new TestCaseData(new Triangle(3, 4, 5))
                .Returns(6);
        }
    }

    public static IEnumerable TriangleIsRightTestCases
    {
        get
        {
            yield return new TestCaseData(new Triangle(1, 1, 1))
                .Returns(false);
            yield return new TestCaseData(new Triangle(2, 3, 4))
                .Returns(false);
            yield return new TestCaseData(new Triangle(3, 4, 5))
                .Returns(true);
            yield return new TestCaseData(new Triangle(20, 21, 29))
                .Returns(true);
        }
    }
}