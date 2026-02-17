namespace Metal.NET;

public class MTLFunctionStitchingFunctionNode : IDisposable
{
    public MTLFunctionStitchingFunctionNode(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetArguments, arguments.NativePtr);
    }

    public void SetControlDependencies(NSArray controlDependencies)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetControlDependencies, controlDependencies.NativePtr);
    }

    public void SetName(NSString name)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetName, name.NativePtr);
    }

}

file class MTLFunctionStitchingFunctionNodeSelector
{
    public static readonly Selector SetArguments = Selector.Register("setArguments:");
    public static readonly Selector SetControlDependencies = Selector.Register("setControlDependencies:");
    public static readonly Selector SetName = Selector.Register("setName:");
}
