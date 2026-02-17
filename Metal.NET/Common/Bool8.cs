using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Objective-C BOOL mapped to a single byte.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct Bool8
{
    public readonly byte Value;

    public Bool8(bool value) => Value = value ? (byte)1 : (byte)0;

    public static implicit operator bool(Bool8 b) => b.Value != 0;
    public static implicit operator Bool8(bool b) => new(b);
}
