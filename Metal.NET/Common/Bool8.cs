using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Objective-C BOOL mapped to a single byte.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct Bool8(bool value)
{
    public readonly byte Value = value ? (byte)1 : (byte)0;

    public static implicit operator bool(Bool8 value)
    {
        return value.Value is not 0;
    }

    public static implicit operator Bool8(bool value)
    {
        return new(value);
    }
}
