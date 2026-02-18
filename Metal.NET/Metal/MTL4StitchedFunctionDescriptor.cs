namespace Metal.NET;

public partial class MTL4StitchedFunctionDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4StitchedFunctionDescriptor");

    public MTL4StitchedFunctionDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? FunctionDescriptors
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StitchedFunctionDescriptorSelector.FunctionDescriptors);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StitchedFunctionDescriptorSelector.SetFunctionDescriptors, value?.NativePtr ?? 0);
    }

    public MTLFunctionStitchingGraph? FunctionGraph
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StitchedFunctionDescriptorSelector.FunctionGraph);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StitchedFunctionDescriptorSelector.SetFunctionGraph, value?.NativePtr ?? 0);
    }
}

file static class MTL4StitchedFunctionDescriptorSelector
{
    public static readonly Selector FunctionDescriptors = Selector.Register("functionDescriptors");

    public static readonly Selector FunctionGraph = Selector.Register("functionGraph");

    public static readonly Selector SetFunctionDescriptors = Selector.Register("setFunctionDescriptors:");

    public static readonly Selector SetFunctionGraph = Selector.Register("setFunctionGraph:");
}
