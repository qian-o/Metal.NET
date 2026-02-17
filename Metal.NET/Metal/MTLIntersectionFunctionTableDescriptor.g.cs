namespace Metal.NET;

file class MTLIntersectionFunctionTableDescriptorSelector
{
    public static readonly Selector SetFunctionCount_ = Selector.Register("setFunctionCount:");
    public static readonly Selector IntersectionFunctionTableDescriptor = Selector.Register("intersectionFunctionTableDescriptor");
}

public class MTLIntersectionFunctionTableDescriptor : IDisposable
{
    public MTLIntersectionFunctionTableDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLIntersectionFunctionTableDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLIntersectionFunctionTableDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIntersectionFunctionTableDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionTableDescriptor");

    public void SetFunctionCount(nuint functionCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTableDescriptorSelector.SetFunctionCount_, (nint)functionCount);
    }

    public static MTLIntersectionFunctionTableDescriptor IntersectionFunctionTableDescriptor()
    {
        var result = new MTLIntersectionFunctionTableDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLIntersectionFunctionTableDescriptorSelector.IntersectionFunctionTableDescriptor));

        return result;
    }

}
