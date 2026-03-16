namespace Metal.NET;

/// <summary>A call graph node that describes an input to the call graph.</summary>
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

    #region Configuring an input node - Properties

    /// <summary>The index in the command’s buffer argument table that declares which data to read for this input node.</summary>
    public nuint ArgumentIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFunctionStitchingInputNodeBindings.ArgumentIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionStitchingInputNodeBindings.SetArgumentIndex, value);
    }
    #endregion
}

file static class MTLFunctionStitchingInputNodeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionStitchingInputNode");

    public static readonly Selector ArgumentIndex = "argumentIndex";

    public static readonly Selector SetArgumentIndex = "setArgumentIndex:";
}
