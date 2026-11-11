using System.Runtime.InteropServices;

namespace Metal.NET;

public readonly struct NSString(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(NSString value) => new(value.NativePtr);

    public NSString(string value) : this(Create(value))
    {
    }

    public NSString Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public static implicit operator string(NSString value)
    {
        return value.ToString();
    }

    public override string ToString()
    {
        return Marshal.PtrToStringUTF8(ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.UTF8String)) ?? string.Empty;
    }

    private static unsafe nint Create(string value)
    {
        if (value is null)
        {
            return 0;
        }

        fixed (char* pChars = value)
        {
            return ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithCharacters_Length, (nint)pChars, (nuint)value.Length);
        }
    }
}

file static class NSStringBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSString");

    public static readonly Selector InitWithCharacters_Length = "initWithCharacters:length:";

    public static readonly Selector UTF8String = "UTF8String";
}
