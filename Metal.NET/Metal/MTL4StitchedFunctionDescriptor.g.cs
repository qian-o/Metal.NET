namespace Metal.NET;

file class MTL4StitchedFunctionDescriptorSelector
{
    public static readonly Selector SetFunctionDescriptors_ = Selector.Register("setFunctionDescriptors:");
    public static readonly Selector SetFunctionGraph_ = Selector.Register("setFunctionGraph:");
}

public class MTL4StitchedFunctionDescriptor : IDisposable
{
    public MTL4StitchedFunctionDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4StitchedFunctionDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4StitchedFunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4StitchedFunctionDescriptor(nint value)
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

    public void SetFunctionDescriptors(NSArray functionDescriptors)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4StitchedFunctionDescriptorSelector.SetFunctionDescriptors_, functionDescriptors.NativePtr);
    }

    public void SetFunctionGraph(MTLFunctionStitchingGraph functionGraph)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4StitchedFunctionDescriptorSelector.SetFunctionGraph_, functionGraph.NativePtr);
    }

}
