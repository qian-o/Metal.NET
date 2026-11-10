namespace Metal.NET;

public readonly struct MTLFunctionStitchingGraph(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLFunctionStitchingGraph value) => new(value.NativePtr);

    public MTLFunctionStitchingGraph() : this(ObjectiveC.AllocInit(MTLFunctionStitchingGraphBindings.Class))
    {
    }

    public MTLFunctionStitchingGraph Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString FunctionName
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionStitchingGraphBindings.FunctionName));
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionStitchingGraphBindings.SetFunctionName, value.NativePtr);
    }

    public NSArray<MTLFunctionStitchingFunctionNode> Nodes
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionStitchingGraphBindings.Nodes));
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionStitchingGraphBindings.SetNodes, value.NativePtr);
    }

    public MTLFunctionStitchingFunctionNode OutputNode
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionStitchingGraphBindings.OutputNode));
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionStitchingGraphBindings.SetOutputNode, value.NativePtr);
    }

    public NSArray<MTLFunctionStitchingAttribute> Attributes
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionStitchingGraphBindings.Attributes));
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionStitchingGraphBindings.SetAttributes, value.NativePtr);
    }

    public static MTLFunctionStitchingGraph InitWithFunctionName(NSString functionName, NSArray<MTLFunctionStitchingFunctionNode> nodes, MTLFunctionStitchingFunctionNode outputNode, NSArray<MTLFunctionStitchingAttribute> attributes)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(MTLFunctionStitchingGraphBindings.Class), MTLFunctionStitchingGraphBindings.InitWithFunctionName_Nodes_OutputNode_Attributes, functionName.NativePtr, nodes.NativePtr, outputNode.NativePtr, attributes.NativePtr);

        return new(nativePtr);
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
