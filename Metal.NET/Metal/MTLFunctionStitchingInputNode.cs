namespace Metal.NET;

public class MTLFunctionStitchingInputNode : IDisposable
{
    public MTLFunctionStitchingInputNode(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFunctionStitchingInputNode()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunctionStitchingInputNode value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionStitchingInputNode(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingInputNode");

    public MTLFunctionStitchingInputNode() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public nuint ArgumentIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionStitchingInputNodeSelector.ArgumentIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingInputNodeSelector.SetArgumentIndex, (nuint)value);
    }

}

file class MTLFunctionStitchingInputNodeSelector
{
    public static readonly Selector ArgumentIndex = Selector.Register("argumentIndex");

    public static readonly Selector SetArgumentIndex = Selector.Register("setArgumentIndex:");
}
