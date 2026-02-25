using System.Runtime.InteropServices;
using System.Text;

namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSString with bidirectional <see cref="string"/> conversion.
/// </summary>
public class NSString(nint nativePtr) : NativeObject(nativePtr), INativeObject<NSString>
{
    public static NSString Create(nint nativePtr) => new(nativePtr);

    public string Value
    {
        get => Marshal.PtrToStringUTF8(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSStringBindings.Utf8String)) ?? string.Empty;
    }

    public static unsafe implicit operator NSString(string value)
    {
        fixed (byte* utf8 = Encoding.UTF8.GetBytes(value + '\0'))
        {
            return new(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(NSStringBindings.Class, NSStringBindings.Alloc), NSStringBindings.InitWithUtf8String, (nint)utf8));
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

    public static readonly Selector Alloc = "alloc";

    public static readonly Selector InitWithUtf8String = "initWithUTF8String:";
}