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

    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVisibleFunctionTableDescriptor");

    public nuint FunctionCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVisibleFunctionTableDescriptorSelector.FunctionCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLVisibleFunctionTableDescriptorSelector.SetFunctionCount, value);
    }

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

    public static MTLVisibleFunctionTableDescriptor VisibleFunctionTableDescriptor()
    {
        MTLVisibleFunctionTableDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLVisibleFunctionTableDescriptorSelector.VisibleFunctionTableDescriptor));

        return result;
    }
}

file class MTLVisibleFunctionTableDescriptorSelector
{
    public static readonly Selector FunctionCount = Selector.Register("functionCount");

    public static readonly Selector SetFunctionCount = Selector.Register("setFunctionCount:");

    public static readonly Selector VisibleFunctionTableDescriptor = Selector.Register("visibleFunctionTableDescriptor");
}
