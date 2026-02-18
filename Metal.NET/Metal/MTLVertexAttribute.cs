namespace Metal.NET;

public class MTLVertexAttribute(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLVertexAttribute() : this(ObjectiveCRuntime.AllocInit(MTLVertexAttributeSelector.Class))
    {
    }

    public bool Active
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeSelector.Active);
    }

    public nuint AttributeIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexAttributeSelector.AttributeIndex);
    }

    public MTLDataType AttributeType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexAttributeSelector.AttributeType);
    }

    public bool IsActive
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeSelector.IsActive);
    }

    public bool IsPatchControlPointData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeSelector.IsPatchControlPointData);
    }

    public bool IsPatchData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeSelector.IsPatchData);
    }

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexAttributeSelector.Name));
    }

    public bool PatchControlPointData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeSelector.PatchControlPointData);
    }

    public bool PatchData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeSelector.PatchData);
    }
}

file static class MTLVertexAttributeSelector
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
