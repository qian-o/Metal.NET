namespace Metal.NET;

public class MTLVertexAttribute(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLVertexAttribute>
{
    #region INativeObject
    public static new MTLVertexAttribute Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLVertexAttribute New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLVertexAttribute() : this(ObjectiveC.AllocInit(MTLVertexAttributeBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public Bool8 Active
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLVertexAttributeBindings.Active);
    }

    public nuint AttributeIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLVertexAttributeBindings.AttributeIndex);
    }

    public MTLDataType AttributeType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLVertexAttributeBindings.AttributeType);
    }

    public Bool8 IsActive
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLVertexAttributeBindings.IsActive);
    }

    public Bool8 IsPatchControlPointData
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLVertexAttributeBindings.IsPatchControlPointData);
    }

    public Bool8 IsPatchData
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLVertexAttributeBindings.IsPatchData);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLVertexAttributeBindings.Name);
    }

    public Bool8 PatchControlPointData
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLVertexAttributeBindings.PatchControlPointData);
    }

    public Bool8 PatchData
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLVertexAttributeBindings.PatchData);
    }
}

file static class MTLVertexAttributeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLVertexAttribute");

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
