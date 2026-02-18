namespace Metal.NET;

public class MTL4BinaryFunction(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4BinaryFunctionSelector.FunctionType);
    }

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4BinaryFunctionSelector.Name));
    }
}

file static class MTL4BinaryFunctionSelector
{
    public static readonly Selector FunctionType = Selector.Register("functionType");

    public static readonly Selector Name = Selector.Register("name");
}
