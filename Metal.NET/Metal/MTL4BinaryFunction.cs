namespace Metal.NET;

public partial class MTL4BinaryFunction : NativeObject
{
    public MTL4BinaryFunction(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4BinaryFunctionSelector.FunctionType);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4BinaryFunctionSelector.Name);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTL4BinaryFunctionSelector
{
    public static readonly Selector FunctionType = Selector.Register("functionType");

    public static readonly Selector Name = Selector.Register("name");
}
