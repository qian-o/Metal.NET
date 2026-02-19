namespace Metal.NET;

public class MTL4StitchedFunctionDescriptor(nint nativePtr, bool retain) : MTL4FunctionDescriptor(nativePtr, retain)
{
    public MTL4StitchedFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4StitchedFunctionDescriptorBindings.Class), false)
    {
    }

    public NSArray? FunctionDescriptors
    {
        get => GetProperty(ref field, MTL4StitchedFunctionDescriptorBindings.FunctionDescriptors);
        set => SetProperty(ref field, MTL4StitchedFunctionDescriptorBindings.SetFunctionDescriptors, value);
    }

    public MTLFunctionStitchingGraph? FunctionGraph
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
