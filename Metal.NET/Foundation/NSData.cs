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

    public byte[] ToArray()
    {
        int length = (int)Length;

        byte[] result = new byte[length];

        Marshal.Copy(Bytes, result, 0, length);

        return result;
    }
}

file static class NSDataBindings
{
    public static readonly Selector Length = "length";

    public static readonly Selector Bytes = "bytes";
}
