namespace Metal.NET;

public class MTLFunction : IDisposable
{
    public MTLFunction(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFunction()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunction value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunction(nint value)
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

    public MTLArgumentEncoder NewArgumentEncoder(uint bufferIndex)
    {
        var result = new MTLArgumentEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFunctionSelector.NewArgumentEncoder, (nint)bufferIndex));

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(uint bufferIndex, int reflection)
    {
        var result = new MTLArgumentEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFunctionSelector.NewArgumentEncoderReflection, (nint)bufferIndex, reflection));

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionSelector.SetLabel, label.NativePtr);
    }

}

file class MTLFunctionSelector
{
    public static readonly Selector NewArgumentEncoder = Selector.Register("newArgumentEncoder:");
    public static readonly Selector NewArgumentEncoderReflection = Selector.Register("newArgumentEncoder:reflection:");
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
