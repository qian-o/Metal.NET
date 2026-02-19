namespace Metal.NET;

public readonly struct MTLFunctionStitchingGraph(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLFunctionStitchingGraph() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingGraphBindings.Class))
    {
    }

    public NSArray? Attributes
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphBindings.Attributes);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphBindings.SetAttributes, value?.NativePtr ?? 0);
    }

    public NSString? FunctionName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphBindings.FunctionName);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphBindings.SetFunctionName, value?.NativePtr ?? 0);
    }

    public NSArray? Nodes
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphBindings.Nodes);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphBindings.SetNodes, value?.NativePtr ?? 0);
    }

    public MTLFunctionStitchingFunctionNode? OutputNode
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphBindings.OutputNode);
            return ptr is not 0 ? new MTLFunctionStitchingFunctionNode(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphBindings.SetOutputNode, value?.NativePtr ?? 0);
    }
}

file static class MTLFunctionStitchingGraphBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingGraph");

    public static readonly Selector Attributes = Selector.Register("attributes");

    public static readonly Selector FunctionName = Selector.Register("functionName");

    public static readonly Selector Nodes = Selector.Register("nodes");

    public static readonly Selector OutputNode = Selector.Register("outputNode");

    public static readonly Selector SetAttributes = Selector.Register("setAttributes:");

    public static readonly Selector SetFunctionName = Selector.Register("setFunctionName:");

    public static readonly Selector SetNodes = Selector.Register("setNodes:");

    public static readonly Selector SetOutputNode = Selector.Register("setOutputNode:");
}
