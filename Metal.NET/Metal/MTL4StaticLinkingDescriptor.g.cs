namespace Metal.NET;

public class MTL4StaticLinkingDescriptor : IDisposable
{
    public MTL4StaticLinkingDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4StaticLinkingDescriptorSelector.SetFunctionDescriptors, functionDescriptors.NativePtr);
    }

    public void SetGroups(int groups)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4StaticLinkingDescriptorSelector.SetGroups, groups);
    }

    public void SetPrivateFunctionDescriptors(NSArray privateFunctionDescriptors)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4StaticLinkingDescriptorSelector.SetPrivateFunctionDescriptors, privateFunctionDescriptors.NativePtr);
    }

}

file class MTL4StaticLinkingDescriptorSelector
{
    public static readonly Selector SetFunctionDescriptors = Selector.Register("setFunctionDescriptors:");
    public static readonly Selector SetGroups = Selector.Register("setGroups:");
    public static readonly Selector SetPrivateFunctionDescriptors = Selector.Register("setPrivateFunctionDescriptors:");
}
