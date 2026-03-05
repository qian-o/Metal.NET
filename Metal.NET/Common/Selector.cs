using System.Runtime.InteropServices;

namespace Metal.NET;

[StructLayout(LayoutKind.Sequential)]
public readonly struct Selector(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator Selector(string name)
    {
        return ObjectiveC.RegisterName(name);
    }
}
