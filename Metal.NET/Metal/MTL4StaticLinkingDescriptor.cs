namespace Metal.NET;

public readonly struct MTL4StaticLinkingDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4StaticLinkingDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4StaticLinkingDescriptorBindings.Class))
    {
    }

    public NSArray? FunctionDescriptors
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StaticLinkingDescriptorBindings.FunctionDescriptors);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StaticLinkingDescriptorBindings.SetFunctionDescriptors, value?.NativePtr ?? 0);
    }

    public NSArray? PrivateFunctionDescriptors
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StaticLinkingDescriptorBindings.PrivateFunctionDescriptors);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StaticLinkingDescriptorBindings.SetPrivateFunctionDescriptors, value?.NativePtr ?? 0);
    }
}

file static class MTL4StaticLinkingDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4StaticLinkingDescriptor");

    public static readonly Selector FunctionDescriptors = Selector.Register("functionDescriptors");

    public static readonly Selector PrivateFunctionDescriptors = Selector.Register("privateFunctionDescriptors");

    public static readonly Selector SetFunctionDescriptors = Selector.Register("setFunctionDescriptors:");

    public static readonly Selector SetPrivateFunctionDescriptors = Selector.Register("setPrivateFunctionDescriptors:");
}
