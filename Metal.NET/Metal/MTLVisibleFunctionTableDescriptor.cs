namespace Metal.NET;

public class MTLVisibleFunctionTableDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVisibleFunctionTableDescriptor");

    public MTLVisibleFunctionTableDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLVisibleFunctionTableDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLVisibleFunctionTableDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

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
}

file class MTLVisibleFunctionTableDescriptorSelector
{
    public static readonly Selector FunctionCount = Selector.Register("functionCount");

    public static readonly Selector SetFunctionCount = Selector.Register("setFunctionCount:");
}
