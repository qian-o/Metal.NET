namespace Metal.NET;

public class MTL4StitchedFunctionDescriptor(nint nativePtr, bool ownsReference) : MTL4FunctionDescriptor(nativePtr, ownsReference), INativeObject<MTL4StitchedFunctionDescriptor>
{
    public static new MTL4StitchedFunctionDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static new MTL4StitchedFunctionDescriptor Null => Create(0, false);
    public static new MTL4StitchedFunctionDescriptor Empty => Null;

    public MTL4StitchedFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4StitchedFunctionDescriptorBindings.Class), true)
    {
    }

    public MTL4FunctionDescriptor[] FunctionDescriptors
    {
        get => GetArrayProperty<MTL4FunctionDescriptor>(MTL4StitchedFunctionDescriptorBindings.FunctionDescriptors);
        set => SetArrayProperty(MTL4StitchedFunctionDescriptorBindings.SetFunctionDescriptors, value);
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
