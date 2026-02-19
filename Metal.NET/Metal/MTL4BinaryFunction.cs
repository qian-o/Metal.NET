namespace Metal.NET;

public class MTL4BinaryFunction(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4BinaryFunctionBindings.FunctionType);
    }

    public NSString? Name
    {
        get => GetProperty(ref field, MTL4BinaryFunctionBindings.Name);
    }
}

file static class MTL4BinaryFunctionBindings
{
    public static readonly Selector FunctionType = "functionType";

    public static readonly Selector Name = "name";
}
