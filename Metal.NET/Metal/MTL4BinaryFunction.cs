namespace Metal.NET;

public readonly struct MTL4BinaryFunction(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4BinaryFunctionBindings.FunctionType);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4BinaryFunctionBindings.Name);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }
}

file static class MTL4BinaryFunctionBindings
{
    public static readonly Selector FunctionType = Selector.Register("functionType");

    public static readonly Selector Name = Selector.Register("name");
}
