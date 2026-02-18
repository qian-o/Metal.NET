namespace Metal.NET;

public partial class MTL4StaticLinkingDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4StaticLinkingDescriptor");

    public MTL4StaticLinkingDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? FunctionDescriptors
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StaticLinkingDescriptorSelector.FunctionDescriptors);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StaticLinkingDescriptorSelector.SetFunctionDescriptors, value?.NativePtr ?? 0);
    }

    public NSArray? PrivateFunctionDescriptors
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StaticLinkingDescriptorSelector.PrivateFunctionDescriptors);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StaticLinkingDescriptorSelector.SetPrivateFunctionDescriptors, value?.NativePtr ?? 0);
    }
}

file static class MTL4StaticLinkingDescriptorSelector
{
    public static readonly Selector FunctionDescriptors = Selector.Register("functionDescriptors");

    public static readonly Selector PrivateFunctionDescriptors = Selector.Register("privateFunctionDescriptors");

    public static readonly Selector SetFunctionDescriptors = Selector.Register("setFunctionDescriptors:");

    public static readonly Selector SetPrivateFunctionDescriptors = Selector.Register("setPrivateFunctionDescriptors:");
}
