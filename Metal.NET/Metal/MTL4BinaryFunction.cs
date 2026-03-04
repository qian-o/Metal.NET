namespace Metal.NET;

public class MTL4BinaryFunction(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTL4BinaryFunction>
{
    #region INativeObject
    public static MTL4BinaryFunction Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4BinaryFunction New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveC.MsgSendULong(NativePtr, MTL4BinaryFunctionBindings.FunctionType);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTL4BinaryFunctionBindings.Name);
    }
}

file static class MTL4BinaryFunctionBindings
{
    public static readonly Selector FunctionType = "functionType";

    public static readonly Selector Name = "name";
}
