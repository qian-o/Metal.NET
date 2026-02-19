namespace Metal.NET;

public class MTL4CommandBufferOptions(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTL4CommandBufferOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CommandBufferOptionsBindings.Class), true)
    {
    }

    public MTLLogState? LogState
    {
        get => GetProperty(ref field, MTL4CommandBufferOptionsBindings.LogState);
        set => SetProperty(ref field, MTL4CommandBufferOptionsBindings.SetLogState, value);
    }
}

file static class MTL4CommandBufferOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommandBufferOptions");

    public static readonly Selector LogState = "logState";

    public static readonly Selector SetLogState = "setLogState:";
}
