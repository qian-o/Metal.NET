using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSData for raw byte buffer access.
/// </summary>
public class NSData(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSData>
{
    public static NSData Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSData Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public nuint Length
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSDataBindings.Length);
    }

    public nint Bytes
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSDataBindings.Bytes);
    }

    public static unsafe NSData DataWithBytes(ReadOnlySpan<byte> bytes)
    {
        fixed (byte* ptr = bytes)
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NSDataBindings.Class, NSDataBindings.DataWithBytesLength, (nint)ptr, (nuint)bytes.Length);

            return new(nativePtr, NativeObjectOwnership.Owned);
        }
    }

    public byte[] ToArray()
    {
        int length = (int)Length;

        byte[] result = new byte[length];

        Marshal.Copy(Bytes, result, 0, length);

        return result;
    }

    public static implicit operator NSData(byte[] bytes) => DataWithBytes(bytes);
}

file static class NSDataBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSData");

    public static readonly Selector Length = "length";

    public static readonly Selector Bytes = "bytes";

    public static readonly Selector DataWithBytesLength = "dataWithBytes:length:";
}
