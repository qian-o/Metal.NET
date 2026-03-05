namespace Metal.NET;

public class MTLFunctionStitchingInputNode(nint nativePtr, NativeObjectOwnership ownership) : MTLFunctionStitchingNode(nativePtr, ownership), INativeObject<MTLFunctionStitchingInputNode>
{
    #region INativeObject
    public static new MTLFunctionStitchingInputNode Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionStitchingInputNode New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFunctionStitchingInputNode() : this(ObjectiveC.AllocInit(MTLFunctionStitchingInputNodeBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint ArgumentIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFunctionStitchingInputNodeBindings.ArgumentIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionStitchingInputNodeBindings.SetArgumentIndex, value);
    }
}

file static class MTLFunctionStitchingInputNodeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionStitchingInputNode");

    public static readonly Selector ArgumentIndex = "argumentIndex";

    public static readonly Selector SetArgumentIndex = "setArgumentIndex:";
}
