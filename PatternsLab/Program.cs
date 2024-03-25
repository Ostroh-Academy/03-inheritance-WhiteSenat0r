namespace PatternsLab;

class Vector2DSystem(double[] a, double[] b)
{
    private protected readonly double[] A = a;
    private protected readonly double[] B = b;

    public void PrintCoordinates()
    {
        Console.WriteLine($"Vector A: ({string.Join(',', A)})");
        Console.WriteLine($"Vector B: ({string.Join(',', B)})");
    }

    public bool IsLinearlyIndependent() => !GetDeterminant().Equals(0);

    protected virtual double GetDeterminant() => A[0] * B[1] - A[1] * B[0];
}

class Vector3DSystem(double[] a, double[] b, double[] c) : Vector2DSystem(a, b)
{
    private protected readonly double[] C = c;
    
    public new void PrintCoordinates()
    {
        base.PrintCoordinates();
        Console.WriteLine($"Vector C: ({string.Join(',', C)})");
    }

    protected override double GetDeterminant() =>
        A[0] * (B[1] * C[2] - B[2] * C[1]) -
        A[1] * (B[0] * C[2] - B[2] * C[0]) +
        A[2] * (B[0] * C[1] - B[1] * C[0]);
}

class Program
{
    static void Main(string[] args)
    {
        var system2D = new Vector2DSystem([1, 2], [3, 4]);

        system2D.PrintCoordinates();

        var isIndependent2D = system2D.IsLinearlyIndependent();
        Console.WriteLine($"System 2D is linearly independent: {isIndependent2D}");

        var system3D = new Vector3DSystem([1, 2, 3], [3, 4, 5], [6, 7, 8]);

        system3D.PrintCoordinates();

        var isIndependent3D = system3D.IsLinearlyIndependent();
        Console.WriteLine($"System 3D is linearly independent: {isIndependent3D}");
    }
}