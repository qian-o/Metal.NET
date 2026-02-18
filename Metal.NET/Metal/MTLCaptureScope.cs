namespace Metal.NET;

public class MTLCaptureScope(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLCommandQueue? CommandQueue
    {
        get => GetNullableObject<MTLCommandQueue>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureScopeSelector.CommandQueue));
    }

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureScopeSelector.Device));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureScopeSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureScopeSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public void BeginScope()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureScopeSelector.BeginScope);
    }

    public void EndScope()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureScopeSelector.EndScope);
    }
}

file static class MTLCaptureScopeSelector
{
    public static readonly Selector BeginScope = Selector.Register("beginScope");

    public static readonly Selector CommandQueue = Selector.Register("commandQueue");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector EndScope = Selector.Register("endScope");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
