namespace Metal.NET;

/// <summary>
/// Represents a raw or compressed file, such as a resource asset file in your app’s bundle.
/// </summary>
public class MTLIOFileHandle(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIOFileHandle>
{
    #region INativeObject
    public static new MTLIOFileHandle Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIOFileHandle New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Naming a file handle - Properties

    /// <summary>
    /// An optional name for the file that the handle represents.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLIOFileHandleBindings.Label);
        set => SetProperty(ref field, MTLIOFileHandleBindings.SetLabel, value);
    }
    #endregion
}

file static class MTLIOFileHandleBindings
{
    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
