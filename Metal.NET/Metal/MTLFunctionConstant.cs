namespace Metal.NET;

public readonly struct MTLFunctionConstant(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLFunctionConstant() : this(ObjectiveCRuntime.AllocInit(MTLFunctionConstantBindings.Class))
    {
    }

    public nuint Index
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionConstantBindings.Index);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionConstantBindings.Name);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }

    public bool Required
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFunctionConstantBindings.Required);
    }

    public MTLDataType Type
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionConstantBindings.Type);
    }
}

file static class MTLFunctionConstantBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionConstant");

    public static readonly Selector Index = Selector.Register("index");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector Required = Selector.Register("required");

    public static readonly Selector Type = Selector.Register("type");
}
