namespace Metal.NET;

/// <summary>
/// A collection of logged messages, created when a Metal device runs a command buffer.
/// </summary>
public class MTLLogContainer(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLLogContainer>
{
    #region INativeObject
    public static new MTLLogContainer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLLogContainer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTLLogContainerBindings
{
}
