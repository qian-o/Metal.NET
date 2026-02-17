using System.Runtime.InteropServices;
using System.Text;

namespace Metal.NET;

public class NSString : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("NSString");

    public NSString(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~NSString()
    {
        Release();
    }

    public nint NativePtr { get; }

    public string Value => Marshal.PtrToStringUTF8(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSStringSelector.Utf8String)) ?? string.Empty;

    public static implicit operator nint(NSString value)
    {
        return value.NativePtr;
    }

    public static implicit operator NSString(nint value)
    {
        return new(value);
    }

    public static unsafe implicit operator NSString(string value)
    {
        fixed (byte* utf8 = Encoding.UTF8.GetBytes(value + '\0'))
        {
            return new(ObjectiveCRuntime.MsgSendPtr(Class, NSStringSelector.StringWithUtf8String, (nint)utf8));
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

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class NSStringSelector
{
    public static readonly Selector Utf8String = Selector.Register("UTF8String");

    public static readonly Selector StringWithUtf8String = Selector.Register("stringWithUTF8String:");
}
