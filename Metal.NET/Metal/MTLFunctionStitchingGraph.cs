namespace Metal.NET;

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

    public NSString FunctionName
    {
        get => GetProperty(ref field, MTLFunctionStitchingGraphBindings.FunctionName);
        set => SetProperty(ref field, MTLFunctionStitchingGraphBindings.SetFunctionName, value);
    }

    public NSArray<MTLFunctionStitchingFunctionNode> Nodes
    {
        get => GetProperty(ref field, MTLFunctionStitchingGraphBindings.Nodes);
        set => SetProperty(ref field, MTLFunctionStitchingGraphBindings.SetNodes, value);
    }

    public MTLFunctionStitchingFunctionNode OutputNode
    {
        get => GetProperty(ref field, MTLFunctionStitchingGraphBindings.OutputNode);
        set => SetProperty(ref field, MTLFunctionStitchingGraphBindings.SetOutputNode, value);
    }

    public NSArray<MTLFunctionStitchingAttribute> Attributes
    {
        get => GetProperty(ref field, MTLFunctionStitchingGraphBindings.Attributes);
        set => SetProperty(ref field, MTLFunctionStitchingGraphBindings.SetAttributes, value);
    }

    public static MTLFunctionStitchingGraph InitWithFunctionName(NSString functionName, NSArray<MTLFunctionStitchingFunctionNode> nodes, MTLFunctionStitchingFunctionNode outputNode, NSArray<MTLFunctionStitchingAttribute> attributes)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(MTLFunctionStitchingGraphBindings.Class), MTLFunctionStitchingGraphBindings.InitWithFunctionName_Nodes_OutputNode_Attributes, functionName.NativePtr, nodes.NativePtr, outputNode.NativePtr, attributes.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }
}

file static class MTLFunctionStitchingGraphBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionStitchingGraph");

    public static readonly Selector Attributes = "attributes";

    public static readonly Selector FunctionName = "functionName";

    public static readonly Selector InitWithFunctionName_Nodes_OutputNode_Attributes = "initWithFunctionName:nodes:outputNode:attributes:";

    public static readonly Selector Nodes = "nodes";

    public static readonly Selector OutputNode = "outputNode";

    public static readonly Selector SetAttributes = "setAttributes:";

    public static readonly Selector SetFunctionName = "setFunctionName:";

    public static readonly Selector SetNodes = "setNodes:";

    public static readonly Selector SetOutputNode = "setOutputNode:";
}
