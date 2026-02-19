namespace Metal.NET;

public class MTLFunctionStitchingInputNode(nint nativePtr) : MTLFunctionStitchingNode(nativePtr)
{
    public MTLFunctionStitchingInputNode() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingInputNodeBindings.Class))
    {
    }

    public nuint ArgumentIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionStitchingInputNodeBindings.ArgumentIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingInputNodeBindings.SetArgumentIndex, value);
    }
}

file static class MTLFunctionStitchingInputNodeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingInputNode");

    public static readonly Selector ArgumentIndex = "argumentIndex";

    public static readonly Selector SetArgumentIndex = "setArgumentIndex:";
}
