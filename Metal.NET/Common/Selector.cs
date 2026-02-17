using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// A cached Objective-C selector (SEL).
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct Selector
{
    public readonly nint NativePtr;

    public Selector(nint ptr) => NativePtr = ptr;

    public static unsafe Selector Register(string name)
    {
        fixed (byte* utf8 = System.Text.Encoding.UTF8.GetBytes(name + '\0'))
        {
            return ObjectiveCRuntime.sel_registerName(utf8);
        }
    }
}
