namespace Metal.NET;

public class MTLPointerType(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLPointerType() : this(ObjectiveCRuntime.AllocInit(MTLPointerTypeBindings.Class))
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPointerTypeBindings.Access);
    }

    public nuint Alignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPointerTypeBindings.Alignment);
    }

    public nuint DataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPointerTypeBindings.DataSize);
    }

    public MTLArrayType? ElementArrayType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPointerTypeBindings.ElementArrayType);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLArrayType(ptr);
            }

            return field;
        }
    }

    public bool ElementIsArgumentBuffer
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLPointerTypeBindings.ElementIsArgumentBuffer);
    }

    public MTLStructType? ElementStructType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPointerTypeBindings.ElementStructType);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLStructType(ptr);
            }

            return field;
        }
    }

    public MTLDataType ElementType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPointerTypeBindings.ElementType);
    }
}

file static class MTLPointerTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLPointerType");

    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector Alignment = Selector.Register("alignment");

    public static readonly Selector DataSize = Selector.Register("dataSize");

    public static readonly Selector ElementArrayType = Selector.Register("elementArrayType");

    public static readonly Selector ElementIsArgumentBuffer = Selector.Register("elementIsArgumentBuffer");

    public static readonly Selector ElementStructType = Selector.Register("elementStructType");

    public static readonly Selector ElementType = Selector.Register("elementType");
}
