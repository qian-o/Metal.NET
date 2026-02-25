namespace Metal.NET;

public class MTLCaptureScope(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLCaptureScope>
{
    public static MTLCaptureScope Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLCaptureScope Null => new(0, false);

    public MTLCommandQueue CommandQueue
    {
        get => GetProperty(ref field, MTLCaptureScopeBindings.CommandQueue);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLCaptureScopeBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLCaptureScopeBindings.Label);
        set => SetProperty(ref field, MTLCaptureScopeBindings.SetLabel, value);
    }

    public void BeginScope()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureScopeBindings.BeginScope);
    }

    public void EndScope()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureScopeBindings.EndScope);
    }
}

file static class MTLCaptureScopeBindings
{
    public static readonly Selector BeginScope = "beginScope";

    public static readonly Selector CommandQueue = "commandQueue";

    public static readonly Selector Device = "device";

    public static readonly Selector EndScope = "endScope";

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
