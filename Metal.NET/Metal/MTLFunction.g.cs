namespace Metal.NET;

file class MTLFunctionSelector
{
    public static readonly Selector NewArgumentEncoder_ = Selector.Register("newArgumentEncoder:");
    public static readonly Selector NewArgumentEncoder_reflection_ = Selector.Register("newArgumentEncoder:reflection:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
}

public class MTLFunction : IDisposable
{
    public MTLFunction(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public MTLArgumentEncoder NewArgumentEncoder(nuint bufferIndex)
    {
        var result = new MTLArgumentEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFunctionSelector.NewArgumentEncoder_, (nint)bufferIndex));

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(nuint bufferIndex, nint reflection)
    {
        var result = new MTLArgumentEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFunctionSelector.NewArgumentEncoder_reflection_, (nint)bufferIndex, reflection));

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionSelector.SetLabel_, label.NativePtr);
    }

}
