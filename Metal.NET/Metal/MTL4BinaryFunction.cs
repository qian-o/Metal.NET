namespace Metal.NET;

public class MTL4BinaryFunction(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4BinaryFunction>
{
    public static MTL4BinaryFunction Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4BinaryFunction Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4BinaryFunctionBindings.FunctionType);
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
