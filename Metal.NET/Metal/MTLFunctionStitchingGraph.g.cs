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

    public static MTLFunctionStitchingGraph New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLFunctionStitchingGraph(ptr);
    }

    public void SetAttributes(NSArray attributes)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetAttributes, attributes.NativePtr);
    }

    public void SetFunctionName(NSString functionName)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetFunctionName, functionName.NativePtr);
    }

    public void SetNodes(NSArray nodes)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetNodes, nodes.NativePtr);
    }

    public void SetOutputNode(MTLFunctionStitchingFunctionNode outputNode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetOutputNode, outputNode.NativePtr);
    }

}

file class MTLFunctionStitchingGraphSelector
{
    public static readonly Selector SetAttributes = Selector.Register("setAttributes:");
    public static readonly Selector SetFunctionName = Selector.Register("setFunctionName:");
    public static readonly Selector SetNodes = Selector.Register("setNodes:");
    public static readonly Selector SetOutputNode = Selector.Register("setOutputNode:");
}
