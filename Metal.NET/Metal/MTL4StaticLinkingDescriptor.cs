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

    public NSArray FunctionDescriptors
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StaticLinkingDescriptorSelector.FunctionDescriptors));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StaticLinkingDescriptorSelector.SetFunctionDescriptors, value.NativePtr);
    }

    public nint Groups
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StaticLinkingDescriptorSelector.Groups);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StaticLinkingDescriptorSelector.SetGroups, value);
    }

    public NSArray PrivateFunctionDescriptors
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StaticLinkingDescriptorSelector.PrivateFunctionDescriptors));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StaticLinkingDescriptorSelector.SetPrivateFunctionDescriptors, value.NativePtr);
    }

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
}

file class MTL4StaticLinkingDescriptorSelector
{
    public static readonly Selector FunctionDescriptors = Selector.Register("functionDescriptors");

    public static readonly Selector SetFunctionDescriptors = Selector.Register("setFunctionDescriptors:");

    public static readonly Selector Groups = Selector.Register("groups");

    public static readonly Selector SetGroups = Selector.Register("setGroups:");

    public static readonly Selector PrivateFunctionDescriptors = Selector.Register("privateFunctionDescriptors");

    public static readonly Selector SetPrivateFunctionDescriptors = Selector.Register("setPrivateFunctionDescriptors:");
}
