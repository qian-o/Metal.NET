using System.Runtime.InteropServices;
using System.Text;

namespace Metal.NET;

public partial class NSString
{
    public static unsafe implicit operator NSString(string value)
    {
        fixed (byte* utf8 = Encoding.UTF8.GetBytes(value + '\0'))
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringInteropBindings.Class), NSStringInteropBindings.InitWithUtf8String, (nint)utf8);

            return new(nativePtr, NativeObjectOwnership.Managed);
        }
    }

    public static implicit operator string(NSString value)
    {
        return value.ToString();
    }

    public override string ToString()
    {
        return Marshal.PtrToStringUTF8(ObjectiveC.MsgSendNInt(NativePtr, NSStringInteropBindings.Utf8String)) ?? string.Empty;
    }
}

file static class NSStringInteropBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSString");

    public static readonly Selector Utf8String = "UTF8String";

    public static readonly Selector InitWithUtf8String = "initWithUTF8String:";
}
