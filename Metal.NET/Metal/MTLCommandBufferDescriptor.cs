namespace Metal.NET;

public class MTLCommandBufferDescriptor : IDisposable
{
    public MTLCommandBufferDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLCommandBufferDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLCommandBufferDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLCommandBufferDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    public nuint ErrorOptions
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLCommandBufferDescriptorSelector.ErrorOptions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferDescriptorSelector.SetErrorOptions, (nuint)value);
    }

    public MTLLogState LogState
    {
        get => new MTLLogState(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandBufferDescriptorSelector.LogState));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferDescriptorSelector.SetLogState, value.NativePtr);
    }

    public Bool8 RetainedReferences
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLCommandBufferDescriptorSelector.RetainedReferences);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferDescriptorSelector.SetRetainedReferences, value);
    }

}

file class MTLCommandBufferDescriptorSelector
{
    public static readonly Selector ErrorOptions = Selector.Register("errorOptions");

    public static readonly Selector SetErrorOptions = Selector.Register("setErrorOptions:");

    public static readonly Selector LogState = Selector.Register("logState");

    public static readonly Selector SetLogState = Selector.Register("setLogState:");

    public static readonly Selector RetainedReferences = Selector.Register("retainedReferences");

    public static readonly Selector SetRetainedReferences = Selector.Register("setRetainedReferences:");
}
