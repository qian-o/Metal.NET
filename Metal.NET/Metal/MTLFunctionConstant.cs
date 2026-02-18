namespace Metal.NET;

public partial class MTLFunctionConstant : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionConstant");

    public MTLFunctionConstant(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint Index
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionConstantSelector.Index);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionConstantSelector.Name);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public bool Required
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFunctionConstantSelector.Required);
    }

    public MTLDataType Type
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionConstantSelector.Type);
    }
}

file static class MTLFunctionConstantSelector
{
    public static readonly Selector Index = Selector.Register("index");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector Required = Selector.Register("required");

    public static readonly Selector Type = Selector.Register("type");
}
