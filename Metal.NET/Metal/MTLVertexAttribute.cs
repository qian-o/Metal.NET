namespace Metal.NET;

public class MTLVertexAttribute(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLVertexAttribute() : this(ObjectiveCRuntime.AllocInit(MTLVertexAttributeBindings.Class))
    {
    }

    public bool Active
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeBindings.Active);
    }

    public nuint AttributeIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexAttributeBindings.AttributeIndex);
    }

    public MTLDataType AttributeType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexAttributeBindings.AttributeType);
    }

    public bool IsActive
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeBindings.IsActive);
    }

    public bool IsPatchControlPointData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeBindings.IsPatchControlPointData);
    }

    public bool IsPatchData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeBindings.IsPatchData);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexAttributeBindings.Name);

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

    public bool PatchControlPointData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeBindings.PatchControlPointData);
    }

    public bool PatchData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeBindings.PatchData);
    }
}

file static class MTLVertexAttributeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexAttribute");

    public static readonly Selector Active = Selector.Register("isActive");

    public static readonly Selector AttributeIndex = Selector.Register("attributeIndex");

    public static readonly Selector AttributeType = Selector.Register("attributeType");

    public static readonly Selector IsActive = Selector.Register("isActive");

    public static readonly Selector IsPatchControlPointData = Selector.Register("isPatchControlPointData");

    public static readonly Selector IsPatchData = Selector.Register("isPatchData");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector PatchControlPointData = Selector.Register("isPatchControlPointData");

    public static readonly Selector PatchData = Selector.Register("isPatchData");
}
