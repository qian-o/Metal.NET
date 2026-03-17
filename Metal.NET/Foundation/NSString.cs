using System.Runtime.InteropServices;
using System.Text;

namespace Metal.NET;

/// <summary>
/// A static, plain-text Unicode string object.
/// </summary>
public class NSString(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSString>
{
    #region INativeObject
    public static new NSString Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSString New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public string Value
    {
        get => Marshal.PtrToStringUTF8(ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.Utf8String)) ?? string.Empty;
    }

    public static unsafe implicit operator NSString(string value)
    {
        fixed (byte* utf8 = Encoding.UTF8.GetBytes(value + '\0'))
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithUtf8String, (nint)utf8);

            return new(nativePtr, NativeObjectOwnership.Managed);
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
    public static readonly nint Class = ObjectiveC.GetClass("NSString");

    public static readonly Selector Utf8String = "UTF8String";

    public static readonly Selector InitWithUtf8String = "initWithUTF8String:";
}