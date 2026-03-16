namespace Metal.NET;

/// <summary>Groups together properties that describe a shader function suitable for stitching.</summary>
public class MTL4StitchedFunctionDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4FunctionDescriptor(nativePtr, ownership), INativeObject<MTL4StitchedFunctionDescriptor>
{
    #region INativeObject
    public static new MTL4StitchedFunctionDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4StitchedFunctionDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4StitchedFunctionDescriptor() : this(ObjectiveC.AllocInit(MTL4StitchedFunctionDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>Configures an array of function descriptors with references to functions that contribute to the stitching process.</summary>
    public MTL4FunctionDescriptor[] FunctionDescriptors
    {
        get => GetArrayProperty<MTL4FunctionDescriptor>(MTL4StitchedFunctionDescriptorBindings.FunctionDescriptors);
        set => SetArrayProperty(MTL4StitchedFunctionDescriptorBindings.SetFunctionDescriptors, value);
    }

    /// <summary>Sets the graph representing how to stitch functions together.</summary>
    public MTLFunctionStitchingGraph FunctionGraph
    {
        get => GetProperty(ref field, MTL4StitchedFunctionDescriptorBindings.FunctionGraph);
        set => SetProperty(ref field, MTL4StitchedFunctionDescriptorBindings.SetFunctionGraph, value);
    }
    #endregion
}

file static class MTL4StitchedFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4StitchedFunctionDescriptor");

    public static readonly Selector FunctionDescriptors = "functionDescriptors";

    public static readonly Selector FunctionGraph = "functionGraph";

    public static readonly Selector SetFunctionDescriptors = "setFunctionDescriptors:";

    public static readonly Selector SetFunctionGraph = "setFunctionGraph:";
}
