namespace Metal.NET;

public class MTLFunctionStitchingInputNode(nint nativePtr, bool ownsReference) : MTLFunctionStitchingNode(nativePtr, ownsReference), INativeObject<MTLFunctionStitchingInputNode>
{
    public static new MTLFunctionStitchingInputNode Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static new MTLFunctionStitchingInputNode Null => Create(0, false);
    public static new MTLFunctionStitchingInputNode Empty => Null;

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
