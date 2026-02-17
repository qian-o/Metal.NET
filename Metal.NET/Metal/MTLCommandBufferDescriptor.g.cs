namespace Metal.NET;

file class MTLCommandBufferDescriptorSelector
{
    public static readonly Selector SetErrorOptions_ = Selector.Register("setErrorOptions:");
    public static readonly Selector SetLogState_ = Selector.Register("setLogState:");
    public static readonly Selector SetRetainedReferences_ = Selector.Register("setRetainedReferences:");
}

public class MTLCommandBufferDescriptor : IDisposable
{
    public MTLCommandBufferDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public void SetErrorOptions(nuint errorOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferDescriptorSelector.SetErrorOptions_, (nint)errorOptions);
    }

    public void SetLogState(MTLLogState logState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferDescriptorSelector.SetLogState_, logState.NativePtr);
    }

    public void SetRetainedReferences(Bool8 retainedReferences)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferDescriptorSelector.SetRetainedReferences_, (nint)retainedReferences.Value);
    }

}
