namespace Metal.NET;

public class MTLFunctionConstant(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFunctionConstant() : this(ObjectiveCRuntime.AllocInit(MTLFunctionConstantSelector.Class))
    {
    }

    public nuint Index
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionConstantSelector.Index);
    }

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionConstantSelector.Name));
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
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionConstant");

    public static readonly Selector Index = Selector.Register("index");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector Required = Selector.Register("required");

    public static readonly Selector Type = Selector.Register("type");
}
