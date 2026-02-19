namespace Metal.NET;

public readonly struct MTL4StitchedFunctionDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4StitchedFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4StitchedFunctionDescriptorBindings.Class))
    {
    }

    public NSArray? FunctionDescriptors
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StitchedFunctionDescriptorBindings.FunctionDescriptors);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StitchedFunctionDescriptorBindings.SetFunctionDescriptors, value?.NativePtr ?? 0);
    }

    public MTLFunctionStitchingGraph? FunctionGraph
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StitchedFunctionDescriptorBindings.FunctionGraph);
            return ptr is not 0 ? new MTLFunctionStitchingGraph(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StitchedFunctionDescriptorBindings.SetFunctionGraph, value?.NativePtr ?? 0);
    }
}

file static class MTL4StitchedFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4StitchedFunctionDescriptor");

    public static readonly Selector FunctionDescriptors = Selector.Register("functionDescriptors");

    public static readonly Selector FunctionGraph = Selector.Register("functionGraph");

    public static readonly Selector SetFunctionDescriptors = Selector.Register("setFunctionDescriptors:");

    public static readonly Selector SetFunctionGraph = Selector.Register("setFunctionGraph:");
}
