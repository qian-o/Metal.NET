namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSData for accessing raw byte buffers.
/// </summary>
public class NSData(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSData>
{
    public static NSData Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSData Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    /// <summary>
    /// Gets the number of bytes in the data object.
    /// </summary>
    public nuint Length
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSDataBindings.Length);
    }

    /// <summary>
    /// Gets a pointer to the data object's contents.
    /// </summary>
    public nint Bytes
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSDataBindings.Bytes);
    }

    /// <summary>
    /// Creates an NSData object from a byte buffer.
    /// </summary>
    /// <param name="bytes">Pointer to the data buffer.</param>
    /// <param name="length">The number of bytes in the buffer.</param>
    /// <returns>A new NSData object that copies the specified data.</returns>
    public static unsafe NSData FromBytes(nint bytes, nuint length)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(
            ObjectiveCRuntime.Alloc(NSDataBindings.Class),
            NSDataBindings.InitWithBytesLength,
            bytes,
            length);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates an NSData object from a managed byte array.
    /// </summary>
    /// <param name="data">The byte array to copy.</param>
    /// <returns>A new NSData object containing a copy of the data.</returns>
    public static unsafe NSData FromBytes(byte[] data)
    {
        fixed (byte* pData = data)
        {
            return FromBytes((nint)pData, (nuint)data.Length);
        }
    }
}

file static class NSDataBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSData");

    public static readonly Selector Length = "length";

    public static readonly Selector Bytes = "bytes";

    public static readonly Selector InitWithBytesLength = "initWithBytes:length:";
}
