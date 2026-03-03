namespace Metal.NET;

public class MTLFunctionStitchingGraph(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLFunctionStitchingGraph>
{
    public static MTLFunctionStitchingGraph Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLFunctionStitchingGraph Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLFunctionStitchingGraph() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingGraphBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLFunctionStitchingAttribute[] Attributes
    {
        get => GetArrayProperty<MTLFunctionStitchingAttribute>(MTLFunctionStitchingGraphBindings.Attributes);
        set => SetArrayProperty(MTLFunctionStitchingGraphBindings.SetAttributes, value);
    }

    public NSString FunctionName
    {
        get => GetProperty(ref field, MTLFunctionStitchingGraphBindings.FunctionName);
        set => SetProperty(ref field, MTLFunctionStitchingGraphBindings.SetFunctionName, value);
    }

    public MTLFunctionStitchingFunctionNode[] Nodes
    {
        get => GetArrayProperty<MTLFunctionStitchingFunctionNode>(MTLFunctionStitchingGraphBindings.Nodes);
        set => SetArrayProperty(MTLFunctionStitchingGraphBindings.SetNodes, value);
    }

    public MTLFunctionStitchingFunctionNode OutputNode
    {
        get => GetProperty(ref field, MTLFunctionStitchingGraphBindings.OutputNode);
        set => SetProperty(ref field, MTLFunctionStitchingGraphBindings.SetOutputNode, value);
    }
}

file static class MTLFunctionStitchingGraphBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingGraph");

    public static readonly Selector Attributes = "attributes";

    public static readonly Selector FunctionName = "functionName";

    public static readonly Selector Nodes = "nodes";

    public static readonly Selector OutputNode = "outputNode";

    public static readonly Selector SetAttributes = "setAttributes:";

    public static readonly Selector SetFunctionName = "setFunctionName:";

    public static readonly Selector SetNodes = "setNodes:";

    public static readonly Selector SetOutputNode = "setOutputNode:";
}
