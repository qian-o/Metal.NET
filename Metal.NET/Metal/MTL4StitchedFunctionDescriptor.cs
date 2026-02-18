namespace Metal.NET;

public class MTL4StitchedFunctionDescriptor(nint nativePtr) : MTL4FunctionDescriptor(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4StitchedFunctionDescriptor");

    public NSArray FunctionDescriptors
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StitchedFunctionDescriptorSelector.FunctionDescriptors));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StitchedFunctionDescriptorSelector.SetFunctionDescriptors, value.NativePtr);
    }

    public MTLFunctionStitchingGraph FunctionGraph
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StitchedFunctionDescriptorSelector.FunctionGraph));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StitchedFunctionDescriptorSelector.SetFunctionGraph, value.NativePtr);
    }

    public static implicit operator nint(MTL4StitchedFunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4StitchedFunctionDescriptor(nint value)
    {
        return new(value);
    }
}

file class MTL4StitchedFunctionDescriptorSelector
{
    public static readonly Selector FunctionDescriptors = Selector.Register("functionDescriptors");

    public static readonly Selector SetFunctionDescriptors = Selector.Register("setFunctionDescriptors:");

    public static readonly Selector FunctionGraph = Selector.Register("functionGraph");

    public static readonly Selector SetFunctionGraph = Selector.Register("setFunctionGraph:");
}
