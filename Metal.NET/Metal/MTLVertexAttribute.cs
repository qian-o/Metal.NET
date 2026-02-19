namespace Metal.NET;

public class MTLVertexAttribute(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLVertexAttribute() : this(ObjectiveCRuntime.AllocInit(MTLVertexAttributeBindings.Class), true)
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
        get => GetProperty(ref field, MTLVertexAttributeBindings.Name);
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

    public static readonly Selector Active = "isActive";

    public static readonly Selector AttributeIndex = "attributeIndex";

    public static readonly Selector AttributeType = "attributeType";

    public static readonly Selector IsActive = "isActive";

    public static readonly Selector IsPatchControlPointData = "isPatchControlPointData";

    public static readonly Selector IsPatchData = "isPatchData";

    public static readonly Selector Name = "name";

    public static readonly Selector PatchControlPointData = "isPatchControlPointData";

    public static readonly Selector PatchData = "isPatchData";
}
