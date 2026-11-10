using System.Buffers;
using System.Runtime.InteropServices;
using System.Text;

namespace Metal.NET;

public readonly struct NSString(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(NSString value) => new(value.NativePtr);

    public NSString Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public static unsafe implicit operator NSString(string value)
    {
        int maxByteCount = Encoding.UTF8.GetMaxByteCount(value.Length) + 1;
        byte[]? rented = null;
        Span<byte> buffer = maxByteCount <= 512
            ? stackalloc byte[maxByteCount]
            : (rented = ArrayPool<byte>.Shared.Rent(maxByteCount));

        try
        {
            int written = Encoding.UTF8.GetBytes(value, buffer);
            buffer[written] = 0;

            fixed (byte* utf8 = buffer)
            {
                nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringInteropBindings.Class), NSStringInteropBindings.InitWithUtf8String, (nint)utf8);

                return new(nativePtr);
            }
        }
        finally
        {
            if (rented is not null)
            {
                ArrayPool<byte>.Shared.Return(rented);
            }
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
