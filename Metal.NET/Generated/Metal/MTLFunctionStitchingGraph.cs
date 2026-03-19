namespace Metal.NET;

public partial class MTLFunctionStitchingGraph(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionStitchingGraph>
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

    public MTLFunctionStitchingAttribute[] Attributes
    {
        get => GetArrayProperty<MTLFunctionStitchingAttribute>(MTLFunctionStitchingGraphBindings.Attributes);
        set => SetArrayProperty(MTLFunctionStitchingGraphBindings.SetAttributes, value);
    }

    public static MTLFunctionStitchingGraph InitWithFunctionName_Nodes_OutputNode_Attributes(NSString functionName, MTLFunctionStitchingFunctionNode[] nodes, MTLFunctionStitchingFunctionNode outputNode, MTLFunctionStitchingAttribute[] attributes)
    {
        nint pNodes = NSArray.FromArray(nodes);
        nint pAttributes = NSArray.FromArray(attributes);

        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(MTLFunctionStitchingGraphBindings.Class), MTLFunctionStitchingGraphBindings.InitWithFunctionName_Nodes_OutputNode_Attributes, functionName.NativePtr, pNodes, outputNode.NativePtr, pAttributes);

        ObjectiveC.Release(pNodes);
        ObjectiveC.Release(pAttributes);

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
