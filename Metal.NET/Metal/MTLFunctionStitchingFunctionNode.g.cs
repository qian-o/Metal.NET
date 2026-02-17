namespace Metal.NET;

file class MTLFunctionStitchingFunctionNodeSelector
{
    public static readonly Selector SetArguments_ = Selector.Register("setArguments:");
    public static readonly Selector SetControlDependencies_ = Selector.Register("setControlDependencies:");
    public static readonly Selector SetName_ = Selector.Register("setName:");
}

public class MTLFunctionStitchingFunctionNode : IDisposable
{
    public MTLFunctionStitchingFunctionNode(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLFunctionStitchingFunctionNode()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunctionStitchingFunctionNode value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionStitchingFunctionNode(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingFunctionNode");

    public static MTLFunctionStitchingFunctionNode New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLFunctionStitchingFunctionNode(ptr);
    }

    public void SetArguments(NSArray arguments)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetArguments_, arguments.NativePtr);
    }

    public void SetControlDependencies(NSArray controlDependencies)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetControlDependencies_, controlDependencies.NativePtr);
    }

    public void SetName(NSString name)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetName_, name.NativePtr);
    }

}
