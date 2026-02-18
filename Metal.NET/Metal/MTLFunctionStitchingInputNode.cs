namespace Metal.NET;

public class MTLFunctionStitchingInputNode(nint nativePtr) : MTLFunctionStitchingNode(nativePtr)
{
    public MTLFunctionStitchingInputNode() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingInputNodeSelector.Class))
    {
    }

    public nuint ArgumentIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionStitchingInputNodeSelector.ArgumentIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingInputNodeSelector.SetArgumentIndex, value);
    }
}

file static class MTLFunctionStitchingInputNodeSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingInputNode");

    public static readonly Selector ArgumentIndex = Selector.Register("argumentIndex");

    public static readonly Selector SetArgumentIndex = Selector.Register("setArgumentIndex:");
}
