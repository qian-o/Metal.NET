using System.Runtime.InteropServices;

namespace Metal.NET;

[StructLayout(LayoutKind.Sequential)]
public struct SimdFloat4x4(SimdFloat4 column0, SimdFloat4 column1, SimdFloat4 column2, SimdFloat4 column3)
{
    public SimdFloat4 Column0 = column0;

    public SimdFloat4 Column1 = column1;

    public SimdFloat4 Column2 = column2;

    public SimdFloat4 Column3 = column3;
}
