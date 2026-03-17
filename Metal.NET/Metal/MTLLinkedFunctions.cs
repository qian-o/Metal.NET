namespace Metal.NET;

public class MTLLinkedFunctions(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLLinkedFunctions>
{
    #region INativeObject
    public static new MTLLinkedFunctions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLLinkedFunctions New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLLinkedFunctions() : this(ObjectiveC.AllocInit(MTLLinkedFunctionsBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public static MTLLinkedFunctions LinkedFunctions()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLLinkedFunctionsBindings.Class, MTLLinkedFunctionsBindings.LinkedFunctions);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLLinkedFunctionsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLLinkedFunctions");

    public static readonly Selector LinkedFunctions = "linkedFunctions";
}
