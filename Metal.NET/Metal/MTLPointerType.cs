namespace Metal.NET;

public class MTLPointerType(nint nativePtr) : MTLType(nativePtr), INativeObject<MTLPointerType>
{
    public static new MTLPointerType Create(nint nativePtr) => new(nativePtr);

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

    public bool ElementIsArgumentBuffer
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLPointerTypeBindings.ElementIsArgumentBuffer);
    }

    public MTLDataType ElementType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPointerTypeBindings.ElementType);
    }

    public MTLArrayType ElementArrayType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPointerTypeBindings.ElementArrayType);

        return new(nativePtr);
    }

    public MTLStructType ElementStructType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPointerTypeBindings.ElementStructType);

        return new(nativePtr);
    }
}

file static class MTLPointerTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLPointerType");

    public static readonly Selector Access = "access";

    public static readonly Selector Alignment = "alignment";

    public static readonly Selector DataSize = "dataSize";

    public static readonly Selector ElementArrayType = "elementArrayType";

    public static readonly Selector ElementIsArgumentBuffer = "elementIsArgumentBuffer";

    public static readonly Selector ElementStructType = "elementStructType";

    public static readonly Selector ElementType = "elementType";
}
