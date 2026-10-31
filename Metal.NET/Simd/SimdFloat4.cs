using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace Metal.NET;

[StructLayout(LayoutKind.Sequential)]
public struct SimdFloat4(float x, float y, float z, float w)
{
    public Vector128<float> XYZW = Vector128.Create(x, y, z, w);

    [UnscopedRef]
    public ref float X => ref Unsafe.As<Vector128<float>, float>(ref XYZW);

    [UnscopedRef]
    public ref float Y => ref Unsafe.Add(ref Unsafe.As<Vector128<float>, float>(ref XYZW), 1);

    [UnscopedRef]
    public ref float Z => ref Unsafe.Add(ref Unsafe.As<Vector128<float>, float>(ref XYZW), 2);

    [UnscopedRef]
    public ref float W => ref Unsafe.Add(ref Unsafe.As<Vector128<float>, float>(ref XYZW), 3);
}