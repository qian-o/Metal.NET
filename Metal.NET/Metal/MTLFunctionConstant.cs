namespace Metal.NET;

public class MTLFunctionConstant(nint nativePtr) : NativeObject(nativePtr)
{
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

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
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
