namespace Metal.NET;

/// <summary>A description of a new stitched function.</summary>
public class MTLFunctionStitchingGraph(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionStitchingGraph>
{
    #region INativeObject
    public static new MTLFunctionStitchingGraph Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionStitchingGraph New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFunctionStitchingGraph() : this(ObjectiveC.AllocInit(MTLFunctionStitchingGraphBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring a function graph - Properties

    /// <summary>The name of the new stitched function.</summary>
    public NSString FunctionName
    {
        get => GetProperty(ref field, MTLFunctionStitchingGraphBindings.FunctionName);
        set => SetProperty(ref field, MTLFunctionStitchingGraphBindings.SetFunctionName, value);
    }

    /// <summary>The nodes in the function’s call graph.</summary>
    public MTLFunctionStitchingFunctionNode[] Nodes
    {
        get => GetArrayProperty<MTLFunctionStitchingFunctionNode>(MTLFunctionStitchingGraphBindings.Nodes);
        set => SetArrayProperty(MTLFunctionStitchingGraphBindings.SetNodes, value);
    }

    /// <summary>The node with the output that’s the output of the new stitched function.</summary>
    public MTLFunctionStitchingFunctionNode OutputNode
    {
        get => GetProperty(ref field, MTLFunctionStitchingGraphBindings.OutputNode);
        set => SetProperty(ref field, MTLFunctionStitchingGraphBindings.SetOutputNode, value);
    }

    /// <summary>A list of attributes to configure how the Metal device object generates the new stitched function.</summary>
    public MTLFunctionStitchingAttribute[] Attributes
    {
        get => GetArrayProperty<MTLFunctionStitchingAttribute>(MTLFunctionStitchingGraphBindings.Attributes);
        set => SetArrayProperty(MTLFunctionStitchingGraphBindings.SetAttributes, value);
    }
    #endregion
}

file static class MTLFunctionStitchingGraphBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionStitchingGraph");

    public static readonly Selector Attributes = "attributes";

    public static readonly Selector FunctionName = "functionName";

    public static readonly Selector Nodes = "nodes";

    public static readonly Selector OutputNode = "outputNode";

    public static readonly Selector SetAttributes = "setAttributes:";

    public static readonly Selector SetFunctionName = "setFunctionName:";

    public static readonly Selector SetNodes = "setNodes:";

    public static readonly Selector SetOutputNode = "setOutputNode:";
}
