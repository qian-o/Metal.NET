using System.Runtime.InteropServices;
using System.Text;

namespace Metal.NET;

/// <summary>
/// A cached Objective-C selector (SEL).
/// Supports implicit conversion from <see cref="string"/> for convenient initialization.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct Selector(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public static unsafe implicit operator Selector(string name)
    {
        fixed (byte* utf8 = Encoding.UTF8.GetBytes(name + '\0'))
        {
            return ObjectiveCRuntime.RegisterName(utf8);
        }
    }
}
