using System.Runtime.InteropServices;
using System.Text;

namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSString with bidirectional <see cref="string"/> conversion.
/// </summary>
public class NSString(nint nativePtr) : NativeObject(nativePtr)
{
    public string Value
    {
        get => Marshal.PtrToStringUTF8(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSStringBindings.Utf8String)) ?? string.Empty;
    }

    public static unsafe implicit operator NSString(string value)
    {
        fixed (byte* utf8 = Encoding.UTF8.GetBytes(value + '\0'))
        {
            return new(ObjectiveCRuntime.MsgSendPtr(NSStringBindings.Class, NSStringBindings.StringWithUtf8String, (nint)utf8));
        }
    }

    public static implicit operator string(NSString value)
    {
        return value.Value;
    }

    public override string ToString()
    {
        return Value;
    }
}

file static class NSStringBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSString");

    public static readonly Selector Utf8String = "UTF8String";

    public static readonly Selector StringWithUtf8String = "stringWithUTF8String:";
}
