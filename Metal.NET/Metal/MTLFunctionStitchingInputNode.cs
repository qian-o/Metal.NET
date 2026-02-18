namespace Metal.NET;

public class MTLFunctionStitchingInputNode(nint nativePtr) : MTLFunctionStitchingNode(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingInputNode");

    public nuint ArgumentIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionStitchingInputNodeSelector.ArgumentIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingInputNodeSelector.SetArgumentIndex, value);
    }

    public static implicit operator nint(MTLFunctionStitchingInputNode value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionStitchingInputNode(nint value)
    {
        return new(value);
    }
}

file class MTLFunctionStitchingInputNodeSelector
{
    public static readonly Selector ArgumentIndex = Selector.Register("argumentIndex");

    public static readonly Selector SetArgumentIndex = Selector.Register("setArgumentIndex:");
}
