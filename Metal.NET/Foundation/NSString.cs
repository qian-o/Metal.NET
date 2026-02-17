using System.Runtime.InteropServices;

namespace Metal.NET;

public class NSString : IDisposable
{
    private static readonly nint s_class = ObjectiveCRuntime.GetClass("NSString");

    public NSString(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~NSString()
    {
        Release();
    }

    public nint NativePtr { get; }

    public string Value
    {
        get
        {
            nint utf8Ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSStringSelector.Utf8String);

            return Marshal.PtrToStringUTF8(utf8Ptr) ?? string.Empty;
        }
    }

    public static implicit operator nint(NSString value)
    {
        return value.NativePtr;
    }

    public static implicit operator NSString(nint value)
    {
        return new(value);
    }

    public static implicit operator NSString(string value)
    {
        return From(value);
    }

    public static implicit operator string(NSString value)
    {
        return value.Value;
    }

    public override string ToString() => Value;

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

    public static unsafe NSString From(string value)
    {
        fixed (byte* utf8 = System.Text.Encoding.UTF8.GetBytes(value + '\0'))
        {
            return new(ObjectiveCRuntime.MsgSendPtr(s_class, NSStringSelector.StringWithUtf8String, (nint)utf8));
        }
    }
}

file class NSStringSelector
{
    public static readonly Selector Utf8String = Selector.Register("UTF8String");

    public static readonly Selector StringWithUtf8String = Selector.Register("stringWithUTF8String:");
}
