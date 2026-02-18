namespace Metal.NET;

public partial class MTLFunctionStitchingGraph : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingGraph");

    public MTLFunctionStitchingGraph(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? Attributes
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.Attributes);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetAttributes, value?.NativePtr ?? 0);
    }

    public NSString? FunctionName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.FunctionName);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetFunctionName, value?.NativePtr ?? 0);
    }

    public NSArray? Nodes
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.Nodes);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetNodes, value?.NativePtr ?? 0);
    }

    public MTLFunctionStitchingFunctionNode? OutputNode
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.OutputNode);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetOutputNode, value?.NativePtr ?? 0);
    }
}

file static class MTLFunctionStitchingGraphSelector
{
    public static readonly Selector Attributes = Selector.Register("attributes");

    public static readonly Selector FunctionName = Selector.Register("functionName");

    public static readonly Selector Nodes = Selector.Register("nodes");

    public static readonly Selector OutputNode = Selector.Register("outputNode");

    public static readonly Selector SetAttributes = Selector.Register("setAttributes:");

    public static readonly Selector SetFunctionName = Selector.Register("setFunctionName:");

    public static readonly Selector SetNodes = Selector.Register("setNodes:");

    public static readonly Selector SetOutputNode = Selector.Register("setOutputNode:");
}
