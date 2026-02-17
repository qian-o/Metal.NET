namespace Metal.NET;

public class MTL4StitchedFunctionDescriptor : IDisposable
{
    public MTL4StitchedFunctionDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public NSArray FunctionDescriptors
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StitchedFunctionDescriptorSelector.FunctionDescriptors));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StitchedFunctionDescriptorSelector.SetFunctionDescriptors, value.NativePtr);
    }

    public MTLFunctionStitchingGraph FunctionGraph
    {
        get => new MTLFunctionStitchingGraph(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StitchedFunctionDescriptorSelector.FunctionGraph));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StitchedFunctionDescriptorSelector.SetFunctionGraph, value.NativePtr);
    }

}

file class MTL4StitchedFunctionDescriptorSelector
{
    public static readonly Selector FunctionDescriptors = Selector.Register("functionDescriptors");

    public static readonly Selector SetFunctionDescriptors = Selector.Register("setFunctionDescriptors:");

    public static readonly Selector FunctionGraph = Selector.Register("functionGraph");

    public static readonly Selector SetFunctionGraph = Selector.Register("setFunctionGraph:");
}
