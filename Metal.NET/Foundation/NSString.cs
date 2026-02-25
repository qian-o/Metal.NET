using System.Runtime.InteropServices;
using System.Text;

namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSString with bidirectional <see cref="string"/> conversion.
/// </summary>
public class NSString(nint nativePtr, bool ownsReference, bool allowGCRelease) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<NSString>
{
    public static NSString Null { get; } = new(0, false, false);

    public static NSString Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public string Value
    {
        get => Marshal.PtrToStringUTF8(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSStringBindings.Utf8String)) ?? string.Empty;
    }

    public static unsafe implicit operator NSString(string value)
    {
        fixed (byte* utf8 = Encoding.UTF8.GetBytes(value + '\0'))
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.Alloc(NSStringBindings.Class), NSStringBindings.InitWithUtf8String, (nint)utf8);

            return new(nativePtr, true, false);
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

    public static readonly Selector InitWithUtf8String = "initWithUTF8String:";
}