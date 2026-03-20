namespace Metal.NET;

public class MTL4BinaryFunction(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4BinaryFunction>
{
    #region INativeObject
    public static new MTL4BinaryFunction Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4BinaryFunction New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Name
    {
        get => GetProperty(ref field, MTL4BinaryFunctionBindings.Name);
    }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveC.MsgSendULong(NativePtr, MTL4BinaryFunctionBindings.FunctionType);
    }
}

file static class MTL4BinaryFunctionBindings
{
    public static readonly Selector FunctionType = "functionType";

    public static readonly Selector Name = "name";
}
