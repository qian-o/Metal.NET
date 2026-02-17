namespace Metal.NET;

public class MTLFunctionStitchingGraph : IDisposable
{
    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingGraph");

    public MTLFunctionStitchingGraph(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLFunctionStitchingGraph() : this(ObjectiveCRuntime.AllocInit(s_class))
    {
    }

    ~MTLFunctionStitchingGraph()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray Attributes
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.Attributes));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetAttributes, value.NativePtr);
    }

    public NSString FunctionName
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.FunctionName));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetFunctionName, value.NativePtr);
    }

    public NSArray Nodes
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.Nodes));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetNodes, value.NativePtr);
    }

    public MTLFunctionStitchingFunctionNode OutputNode
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingGraphSelector.OutputNode));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetOutputNode, value.NativePtr);
    }

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
