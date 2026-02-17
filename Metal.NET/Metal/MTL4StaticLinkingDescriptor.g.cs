namespace Metal.NET;

file class MTL4StaticLinkingDescriptorSelector
{
    public static readonly Selector SetFunctionDescriptors_ = Selector.Register("setFunctionDescriptors:");
    public static readonly Selector SetGroups_ = Selector.Register("setGroups:");
    public static readonly Selector SetPrivateFunctionDescriptors_ = Selector.Register("setPrivateFunctionDescriptors:");
}

public class MTL4StaticLinkingDescriptor : IDisposable
{
    public MTL4StaticLinkingDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4StaticLinkingDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4StaticLinkingDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4StaticLinkingDescriptor(nint value)
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

    public void SetFunctionDescriptors(NSArray functionDescriptors)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4StaticLinkingDescriptorSelector.SetFunctionDescriptors_, functionDescriptors.NativePtr);
    }

    public void SetGroups(nint groups)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4StaticLinkingDescriptorSelector.SetGroups_, groups);
    }

    public void SetPrivateFunctionDescriptors(NSArray privateFunctionDescriptors)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4StaticLinkingDescriptorSelector.SetPrivateFunctionDescriptors_, privateFunctionDescriptors.NativePtr);
    }

}
