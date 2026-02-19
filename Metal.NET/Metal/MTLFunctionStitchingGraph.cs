namespace Metal.NET;

public class MTLFunctionStitchingGraph(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public MTLFunctionStitchingGraph() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingGraphBindings.Class), false)
    {
    }

    public NSArray? Attributes
    {
        get => GetProperty(ref field, MTLFunctionStitchingGraphBindings.Attributes);
        set => SetProperty(ref field, MTLFunctionStitchingGraphBindings.SetAttributes, value);
    }

    public NSString? FunctionName
    {
        get => GetProperty(ref field, MTLFunctionStitchingGraphBindings.FunctionName);
        set => SetProperty(ref field, MTLFunctionStitchingGraphBindings.SetFunctionName, value);
    }

    public NSArray? Nodes
    {
        get => GetProperty(ref field, MTLFunctionStitchingGraphBindings.Nodes);
        set => SetProperty(ref field, MTLFunctionStitchingGraphBindings.SetNodes, value);
    }

    public MTLFunctionStitchingFunctionNode? OutputNode
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
