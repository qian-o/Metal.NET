namespace Metal.NET;

public class MTLFunctionStitchingGraph(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFunctionStitchingGraph() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingGraphSelector.Class))
    {
    }

    public NSArray? Attributes
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.Attributes));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetAttributes, value?.NativePtr ?? 0);
    }

    public NSString? FunctionName
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.FunctionName));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetFunctionName, value?.NativePtr ?? 0);
    }

    public NSArray? Nodes
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.Nodes));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetNodes, value?.NativePtr ?? 0);
    }

    public MTLFunctionStitchingFunctionNode? OutputNode
    {
        get => GetNullableObject<MTLFunctionStitchingFunctionNode>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.OutputNode));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetOutputNode, value?.NativePtr ?? 0);
    }
}

file static class MTLFunctionStitchingGraphSelector
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
