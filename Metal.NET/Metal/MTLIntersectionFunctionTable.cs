namespace Metal.NET;

public class MTLIntersectionFunctionTable : IDisposable
{
    public MTLIntersectionFunctionTable(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLIntersectionFunctionTable()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLIntersectionFunctionTableSelector.GpuResourceID);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetBufferOffsetAtIndex, buffer.NativePtr, offset, index);
    }

    public static implicit operator nint(MTLIntersectionFunctionTable value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIntersectionFunctionTable(nint value)
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

file class MTLIntersectionFunctionTableSelector
{
    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector SetBufferOffsetAtIndex = Selector.Register("setBuffer:offset:atIndex:");
}
