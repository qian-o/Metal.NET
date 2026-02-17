namespace Metal.NET;

public class MTLFunctionStitchingInputNode : IDisposable
{
    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingInputNode");

    public MTLFunctionStitchingInputNode(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLFunctionStitchingInputNode() : this(ObjectiveCRuntime.AllocInit(s_class))
    {
    }

    ~MTLFunctionStitchingInputNode()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint ArgumentIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionStitchingInputNodeSelector.ArgumentIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingInputNodeSelector.SetArgumentIndex, (nuint)value);
    }

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

}

file class MTLFunctionStitchingInputNodeSelector
{
    public static readonly Selector ArgumentIndex = Selector.Register("argumentIndex");

    public static readonly Selector SetArgumentIndex = Selector.Register("setArgumentIndex:");
}
