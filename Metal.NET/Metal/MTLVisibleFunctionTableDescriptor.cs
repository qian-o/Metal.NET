namespace Metal.NET;

public class MTLVisibleFunctionTableDescriptor : IDisposable
{
    public MTLVisibleFunctionTableDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void SetFunctionCount(uint functionCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVisibleFunctionTableDescriptorSelector.SetFunctionCount, (nint)functionCount);
    }

    public static MTLVisibleFunctionTableDescriptor VisibleFunctionTableDescriptor()
    {
        MTLVisibleFunctionTableDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLVisibleFunctionTableDescriptorSelector.VisibleFunctionTableDescriptor));

        return result;
    }

}

file class MTLVisibleFunctionTableDescriptorSelector
{
    public static readonly Selector SetFunctionCount = Selector.Register("setFunctionCount:");

    public static readonly Selector VisibleFunctionTableDescriptor = Selector.Register("visibleFunctionTableDescriptor");
}
