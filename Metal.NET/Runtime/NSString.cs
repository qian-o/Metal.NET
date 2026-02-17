using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSString pointer.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct NSString
{
    public readonly IntPtr NativePtr;

    public NSString(IntPtr ptr) => NativePtr = ptr;

    public static implicit operator IntPtr(NSString s) => s.NativePtr;
    public static implicit operator NSString(IntPtr ptr) => new(ptr);

    public bool IsNull => NativePtr == IntPtr.Zero;

    private static readonly Selector s_UTF8String = Selector.Register("UTF8String");
    private static readonly Selector s_stringWithUTF8String = Selector.Register("stringWithUTF8String:");
    private static readonly IntPtr s_class = ObjectiveCRuntime.GetClass("NSString");

    public string GetValue()
    {
        var utf8Ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, s_UTF8String);
        return Marshal.PtrToStringUTF8(utf8Ptr) ?? string.Empty;
    }

    public static unsafe NSString From(string value)
    {
        fixed (byte* utf8 = System.Text.Encoding.UTF8.GetBytes(value + '\0'))
        {
            var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, s_stringWithUTF8String, (IntPtr)utf8);
            return new NSString(ptr);
        }
    }

    public override string ToString() => GetValue();
}
