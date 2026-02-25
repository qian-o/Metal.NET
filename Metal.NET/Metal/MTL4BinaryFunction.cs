namespace Metal.NET;

public class MTL4BinaryFunction(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4BinaryFunction>
{
    public static MTL4BinaryFunction Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTL4BinaryFunction Null => new(0, false);

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
