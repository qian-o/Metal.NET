namespace Metal.NET;

file class MTLFunctionStitchingGraphSelector
{
    public static readonly Selector SetAttributes_ = Selector.Register("setAttributes:");
    public static readonly Selector SetFunctionName_ = Selector.Register("setFunctionName:");
    public static readonly Selector SetNodes_ = Selector.Register("setNodes:");
    public static readonly Selector SetOutputNode_ = Selector.Register("setOutputNode:");
}

public class MTLFunctionStitchingGraph : IDisposable
{
    public MTLFunctionStitchingGraph(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetAttributes_, attributes.NativePtr);
    }

    public void SetFunctionName(NSString functionName)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetFunctionName_, functionName.NativePtr);
    }

    public void SetNodes(NSArray nodes)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetNodes_, nodes.NativePtr);
    }

    public void SetOutputNode(MTLFunctionStitchingFunctionNode outputNode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingGraphSelector.SetOutputNode_, outputNode.NativePtr);
    }

}
