namespace Metal.NET;

public class MTLFunctionStitchingInputNode(nint nativePtr, bool owned) : MTLFunctionStitchingNode(nativePtr, owned)
{
    public MTLFunctionStitchingInputNode() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingInputNodeBindings.Class), true)
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
