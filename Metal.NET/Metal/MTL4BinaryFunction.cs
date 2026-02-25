namespace Metal.NET;

public class MTL4BinaryFunction(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4BinaryFunction>
{
    public static MTL4BinaryFunction Create(nint nativePtr) => new(nativePtr, true);

    public static MTL4BinaryFunction CreateBorrowed(nint nativePtr) => new(nativePtr, false);

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
