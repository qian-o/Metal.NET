namespace Metal.NET;

public readonly struct MTL4StitchedFunctionDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTL4FunctionDescriptor(MTL4StitchedFunctionDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4StitchedFunctionDescriptor value) => new(value.NativePtr);

    public MTL4StitchedFunctionDescriptor() : this(ObjectiveC.AllocInit(MTL4StitchedFunctionDescriptorBindings.Class))
    {
    }

    public MTL4StitchedFunctionDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLFunctionStitchingGraph FunctionGraph
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4StitchedFunctionDescriptorBindings.FunctionGraph));
        set => ObjectiveC.MsgSend(NativePtr, MTL4StitchedFunctionDescriptorBindings.SetFunctionGraph, value.NativePtr);
    }

    public NSArray<MTL4FunctionDescriptor> FunctionDescriptors
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4StitchedFunctionDescriptorBindings.FunctionDescriptors));
        set => ObjectiveC.MsgSend(NativePtr, MTL4StitchedFunctionDescriptorBindings.SetFunctionDescriptors, value.NativePtr);
    }
}

file static class MTL4StitchedFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4StitchedFunctionDescriptor");

    public static readonly Selector FunctionDescriptors = "functionDescriptors";

    public static readonly Selector FunctionGraph = "functionGraph";

    public static readonly Selector SetFunctionDescriptors = "setFunctionDescriptors:";

    public static readonly Selector SetFunctionGraph = "setFunctionGraph:";
}
