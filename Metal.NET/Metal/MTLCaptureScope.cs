namespace Metal.NET;

public class MTLCaptureScope(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLCommandQueue? CommandQueue
    {
        get => GetProperty<MTLCommandQueue>(ref field, MTLCaptureScopeBindings.CommandQueue);
    }

    public MTLDevice? Device
    {
        get => GetProperty<MTLDevice>(ref field, MTLCaptureScopeBindings.Device);
    }

    public NSString? Label
    {
        get => GetProperty<NSString>(ref field, MTLCaptureScopeBindings.Label);
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
