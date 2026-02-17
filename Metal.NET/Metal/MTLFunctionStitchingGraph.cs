namespace Metal.NET;

public class MTLFunctionStitchingGraph : IDisposable
{
    public MTLFunctionStitchingGraph(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFunctionStitchingGraph()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunctionStitchingGraph value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionStitchingGraph(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingGraph");

    public MTLFunctionStitchingGraph() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public NSArray Attributes
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.Attributes));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetAttributes, value.NativePtr);
    }

    public NSString FunctionName
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.FunctionName));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetFunctionName, value.NativePtr);
    }

    public NSArray Nodes
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.Nodes));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetNodes, value.NativePtr);
    }

    public MTLFunctionStitchingFunctionNode OutputNode
    {
        get => new MTLFunctionStitchingFunctionNode(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.OutputNode));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetOutputNode, value.NativePtr);
    }

}

file class MTLFunctionStitchingGraphSelector
{
    public static readonly Selector Attributes = Selector.Register("attributes");

    public static readonly Selector SetAttributes = Selector.Register("setAttributes:");

    public static readonly Selector FunctionName = Selector.Register("functionName");

    public static readonly Selector SetFunctionName = Selector.Register("setFunctionName:");

    public static readonly Selector Nodes = Selector.Register("nodes");

    public static readonly Selector SetNodes = Selector.Register("setNodes:");

    public static readonly Selector OutputNode = Selector.Register("outputNode");

    public static readonly Selector SetOutputNode = Selector.Register("setOutputNode:");
}
