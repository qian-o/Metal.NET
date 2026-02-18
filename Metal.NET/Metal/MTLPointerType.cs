namespace Metal.NET;

public partial class MTLPointerType : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLPointerType");

    public MTLPointerType(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPointerTypeSelector.Access);
    }

    public nuint Alignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPointerTypeSelector.Alignment);
    }

    public nuint DataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPointerTypeSelector.DataSize);
    }

    public MTLArrayType? ElementArrayType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPointerTypeSelector.ElementArrayType);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public bool ElementIsArgumentBuffer
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLPointerTypeSelector.ElementIsArgumentBuffer);
    }

    public MTLStructType? ElementStructType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPointerTypeSelector.ElementStructType);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLDataType ElementType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPointerTypeSelector.ElementType);
    }
}

file static class MTLPointerTypeSelector
{
    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector Alignment = Selector.Register("alignment");

    public static readonly Selector DataSize = Selector.Register("dataSize");

    public static readonly Selector ElementArrayType = Selector.Register("elementArrayType");

    public static readonly Selector ElementIsArgumentBuffer = Selector.Register("elementIsArgumentBuffer");

    public static readonly Selector ElementStructType = Selector.Register("elementStructType");

    public static readonly Selector ElementType = Selector.Register("elementType");
}
