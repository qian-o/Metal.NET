namespace Metal.NET;

public class MTL4StitchedFunctionDescriptor(nint nativePtr, bool ownsReference = true) : MTL4FunctionDescriptor(nativePtr, ownsReference), INativeObject<MTL4StitchedFunctionDescriptor>
{
    public static new MTL4StitchedFunctionDescriptor Create(nint nativePtr) => new(nativePtr);

    public static new MTL4StitchedFunctionDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTL4StitchedFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4StitchedFunctionDescriptorBindings.Class))
    {
    }

    public NSArray FunctionDescriptors
    {
        get => GetProperty(ref field, MTL4StitchedFunctionDescriptorBindings.FunctionDescriptors);
        set => SetProperty(ref field, MTL4StitchedFunctionDescriptorBindings.SetFunctionDescriptors, value);
    }

    public MTLFunctionStitchingGraph FunctionGraph
    {
        get => GetProperty(ref field, MTL4StitchedFunctionDescriptorBindings.FunctionGraph);
        set => SetProperty(ref field, MTL4StitchedFunctionDescriptorBindings.SetFunctionGraph, value);
    }
}

file static class MTL4StitchedFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4StitchedFunctionDescriptor");

    public static readonly Selector FunctionDescriptors = "functionDescriptors";

    public static readonly Selector FunctionGraph = "functionGraph";

    public static readonly Selector SetFunctionDescriptors = "setFunctionDescriptors:";

    public static readonly Selector SetFunctionGraph = "setFunctionGraph:";
}
