namespace Metal.NET;

/// <summary>
/// A type that synchronizes memory operations to one or more resources within a single Metal device.
/// </summary>
public class MTLEvent(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLEvent>
{
    #region INativeObject
    public static new MTLEvent Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLEvent New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying the event - Properties

    /// <summary>
    /// The device object that created the event.
    /// </summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLEventBindings.Device);
    }

    /// <summary>
    /// A string that identifies the event.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLEventBindings.Label);
        set => SetProperty(ref field, MTLEventBindings.SetLabel, value);
    }
    #endregion
}

file static class MTLEventBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
