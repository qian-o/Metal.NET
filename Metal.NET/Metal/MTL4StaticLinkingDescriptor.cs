namespace Metal.NET;

public class MTL4StaticLinkingDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4StaticLinkingDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4StaticLinkingDescriptorSelector.Class))
    {
    }

    public NSArray? FunctionDescriptors
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StaticLinkingDescriptorSelector.FunctionDescriptors));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StaticLinkingDescriptorSelector.SetFunctionDescriptors, value?.NativePtr ?? 0);
    }

    public NSArray? PrivateFunctionDescriptors
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StaticLinkingDescriptorSelector.PrivateFunctionDescriptors));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StaticLinkingDescriptorSelector.SetPrivateFunctionDescriptors, value?.NativePtr ?? 0);
    }
}

file static class MTL4StaticLinkingDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4StaticLinkingDescriptor");

    public static readonly Selector FunctionDescriptors = Selector.Register("functionDescriptors");

    public static readonly Selector PrivateFunctionDescriptors = Selector.Register("privateFunctionDescriptors");

    public static readonly Selector SetFunctionDescriptors = Selector.Register("setFunctionDescriptors:");

    public static readonly Selector SetPrivateFunctionDescriptors = Selector.Register("setPrivateFunctionDescriptors:");
}
