namespace Metal.NET;

public class MTL4StitchedFunctionDescriptor(nint nativePtr) : MTL4FunctionDescriptor(nativePtr)
{
    public MTL4StitchedFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4StitchedFunctionDescriptorSelector.Class))
    {
    }

    public NSArray? FunctionDescriptors
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StitchedFunctionDescriptorSelector.FunctionDescriptors));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StitchedFunctionDescriptorSelector.SetFunctionDescriptors, value?.NativePtr ?? 0);
    }

    public MTLFunctionStitchingGraph? FunctionGraph
    {
        get => GetNullableObject<MTLFunctionStitchingGraph>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StitchedFunctionDescriptorSelector.FunctionGraph));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StitchedFunctionDescriptorSelector.SetFunctionGraph, value?.NativePtr ?? 0);
    }
}

file static class MTL4StitchedFunctionDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4StitchedFunctionDescriptor");

    public static readonly Selector FunctionDescriptors = Selector.Register("functionDescriptors");

    public static readonly Selector FunctionGraph = Selector.Register("functionGraph");

    public static readonly Selector SetFunctionDescriptors = Selector.Register("setFunctionDescriptors:");

    public static readonly Selector SetFunctionGraph = Selector.Register("setFunctionGraph:");
}
