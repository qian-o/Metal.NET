namespace Metal.NET;

file class MTLVisibleFunctionTableDescriptorSelector
{
    public static readonly Selector SetFunctionCount_ = Selector.Register("setFunctionCount:");
    public static readonly Selector VisibleFunctionTableDescriptor = Selector.Register("visibleFunctionTableDescriptor");
}

public class MTLVisibleFunctionTableDescriptor : IDisposable
{
    public MTLVisibleFunctionTableDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLVisibleFunctionTableDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLVisibleFunctionTableDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLVisibleFunctionTableDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLVisibleFunctionTableDescriptor");

    public void SetFunctionCount(nuint functionCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVisibleFunctionTableDescriptorSelector.SetFunctionCount_, (nint)functionCount);
    }

    public static MTLVisibleFunctionTableDescriptor VisibleFunctionTableDescriptor()
    {
        var result = new MTLVisibleFunctionTableDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLVisibleFunctionTableDescriptorSelector.VisibleFunctionTableDescriptor));

        return result;
    }

}
