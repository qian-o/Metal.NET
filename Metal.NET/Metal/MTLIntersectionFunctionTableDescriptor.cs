namespace Metal.NET;

public class MTLIntersectionFunctionTableDescriptor : IDisposable
{
    public MTLIntersectionFunctionTableDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void SetFunctionCount(uint functionCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableDescriptorSelector.SetFunctionCount, (nint)functionCount);
    }

    public static MTLIntersectionFunctionTableDescriptor IntersectionFunctionTableDescriptor()
    {
        MTLIntersectionFunctionTableDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLIntersectionFunctionTableDescriptorSelector.IntersectionFunctionTableDescriptor));

        return result;
    }

}

file class MTLIntersectionFunctionTableDescriptorSelector
{
    public static readonly Selector SetFunctionCount = Selector.Register("setFunctionCount:");

    public static readonly Selector IntersectionFunctionTableDescriptor = Selector.Register("intersectionFunctionTableDescriptor");
}
