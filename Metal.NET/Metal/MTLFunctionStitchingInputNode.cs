namespace Metal.NET;

public class MTLFunctionStitchingInputNode(nint nativePtr, bool ownsReference = true) : MTLFunctionStitchingNode(nativePtr, ownsReference), INativeObject<MTLFunctionStitchingInputNode>
{
    public static new MTLFunctionStitchingInputNode Create(nint nativePtr) => new(nativePtr);

    public static new MTLFunctionStitchingInputNode CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

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
