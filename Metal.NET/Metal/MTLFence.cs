namespace Metal.NET;

/// <summary>A synchronization mechanism that orders memory operations between GPU passes.</summary>
public class MTLFence(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFence>
{
    #region INativeObject
    public static new MTLFence Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFence New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying a fence - Properties

    /// <summary>The device object that created the fence.</summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLFenceBindings.Device);
    }

    /// <summary>A string that identifies the fence.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLFenceBindings.Label);
        set => SetProperty(ref field, MTLFenceBindings.SetLabel, value);
    }
    #endregion
}

file static class MTLFenceBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
