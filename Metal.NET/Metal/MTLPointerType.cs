namespace Metal.NET;

public class MTLPointerType(nint nativePtr) : MTLType(nativePtr)
{
    public MTLPointerType() : this(ObjectiveCRuntime.AllocInit(MTLPointerTypeSelector.Class))
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
        get => GetNullableObject<MTLArrayType>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPointerTypeSelector.ElementArrayType));
    }

    public bool ElementIsArgumentBuffer
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLPointerTypeSelector.ElementIsArgumentBuffer);
    }

    public MTLStructType? ElementStructType
    {
        get => GetNullableObject<MTLStructType>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPointerTypeSelector.ElementStructType));
    }

    public MTLDataType ElementType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPointerTypeSelector.ElementType);
    }
}

file static class MTLPointerTypeSelector
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
