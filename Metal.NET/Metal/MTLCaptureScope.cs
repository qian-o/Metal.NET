namespace Metal.NET;

public readonly struct MTLCaptureScope(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLCaptureScope value) => new(value.NativePtr);

    public MTLCaptureScope Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureScopeBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLCaptureScopeBindings.SetLabel, value.NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureScopeBindings.Device));
    }

    public MTLCommandQueue CommandQueue
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureScopeBindings.CommandQueue));
    }

    public MTL4CommandQueue Mtl4CommandQueue
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCaptureScopeBindings.Mtl4CommandQueue));
    }

    public void Begin()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureScopeBindings.BeginScope);
    }

    public void End()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCaptureScopeBindings.EndScope);
    }
}

file static class MTLCaptureScopeBindings
{
    public static readonly Selector BeginScope = "beginScope";

    public static readonly Selector CommandQueue = "commandQueue";

    public static readonly Selector Device = "device";

    public static readonly Selector EndScope = "endScope";

    public static readonly Selector Label = "label";

    public static readonly Selector Mtl4CommandQueue = "mtl4CommandQueue";

    public static readonly Selector SetLabel = "setLabel:";
}
