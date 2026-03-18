namespace Metal.NET;

public class MTLCaptureScope(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCaptureScope>
{
    #region INativeObject
    public static new MTLCaptureScope Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCaptureScope New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Label
    {
        get => GetProperty(ref field, MTLCaptureScopeBindings.Label);
        set => SetProperty(ref field, MTLCaptureScopeBindings.SetLabel, value);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLCaptureScopeBindings.Device);
    }

    public MTLCommandQueue CommandQueue
    {
        get => GetProperty(ref field, MTLCaptureScopeBindings.CommandQueue);
    }

    public MTL4CommandQueue Mtl4CommandQueue
    {
        get => GetProperty(ref field, MTLCaptureScopeBindings.Mtl4CommandQueue);
    }

    public void Begin()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureScopeBindings.Begin);
    }

    public void End()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureScopeBindings.End);
    }
}

file static class MTLCaptureScopeBindings
{
    public static readonly Selector Begin = "beginScope";

    public static readonly Selector CommandQueue = "commandQueue";

    public static readonly Selector Device = "device";

    public static readonly Selector End = "endScope";

    public static readonly Selector Label = "label";

    public static readonly Selector Mtl4CommandQueue = "mtl4CommandQueue";

    public static readonly Selector SetLabel = "setLabel:";
}
