namespace Metal.NET;

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

    public MTLLogState LogState
    {
        get => GetProperty(ref field, MTL4CommandBufferOptionsBindings.LogState);
        set => SetProperty(ref field, MTL4CommandBufferOptionsBindings.SetLogState, value);
    }

    public MTLLogState LogState
    {
        get => GetProperty(ref field, MTL4CommandBufferOptionsBindings.LogState);
        set => SetProperty(ref field, MTL4CommandBufferOptionsBindings.SetLogState, value);
    }

    public void SetLogState(MTLLogState logState)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandBufferOptionsBindings.SetLogState, logState.NativePtr);
    }
}

file static class MTL4CommandBufferOptionsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CommandBufferOptions");

    public static readonly Selector LogState = "logState";

    public static readonly Selector SetLogState = "setLogState:";
}
