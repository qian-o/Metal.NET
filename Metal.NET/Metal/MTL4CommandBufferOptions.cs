namespace Metal.NET;

/// <summary>Options to configure a command buffer before encoding work into it.</summary>
public class MTL4CommandBufferOptions(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CommandBufferOptions>
{
    #region INativeObject
    public static new MTL4CommandBufferOptions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CommandBufferOptions New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4CommandBufferOptions() : this(ObjectiveC.AllocInit(MTL4CommandBufferOptionsBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>Contains information related to shader logging.</summary>
    public MTLLogState LogState
    {
        get => GetProperty(ref field, MTL4CommandBufferOptionsBindings.LogState);
        set => SetProperty(ref field, MTL4CommandBufferOptionsBindings.SetLogState, value);
    }
    #endregion
}

file static class MTL4CommandBufferOptionsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CommandBufferOptions");

    public static readonly Selector LogState = "logState";

    public static readonly Selector SetLogState = "setLogState:";
}
