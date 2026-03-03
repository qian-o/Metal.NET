namespace Metal.NET;

public class MTL4CommandBufferOptions(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4CommandBufferOptions>
{
    public static MTL4CommandBufferOptions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4CommandBufferOptions Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTL4CommandBufferOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CommandBufferOptionsBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLLogState LogState
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
