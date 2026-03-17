namespace Metal.NET;

/// <summary>
/// An instance that represents an attribute of a vertex function.
/// </summary>
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

    #region Describing the attribute - Properties

    /// <summary>
    /// The name of the attribute.
    /// </summary>
    public NSString Name
    {
        get => GetProperty(ref field, MTLVertexAttributeBindings.Name);
    }

    /// <summary>
    /// The index of the attribute, as declared in Metal shader source code.
    /// </summary>
    public nuint AttributeIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLVertexAttributeBindings.AttributeIndex);
    }

    /// <summary>
    /// The data type for the attribute, as declared in Metal shader source code.
    /// </summary>
    public MTLDataType AttributeType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLVertexAttributeBindings.AttributeType);
    }

    /// <summary>
    /// A Boolean value that indicates whether this vertex attribute is active.
    /// </summary>
    public Bool8 IsActive
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLVertexAttributeBindings.IsActive);
    }

    /// <summary>
    /// A Boolean value that indicates whether this vertex attribute represents control point data.
    /// </summary>
    public Bool8 IsPatchControlPointData
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLVertexAttributeBindings.IsPatchControlPointData);
    }

    /// <summary>
    /// A Boolean value that indicates whether this vertex attribute represents patch data.
    /// </summary>
    public Bool8 IsPatchData
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLVertexAttributeBindings.IsPatchData);
    }
    #endregion

    /// <summary>
    /// Deprecated: please use isActive instead
    /// </summary>
    [Obsolete("please use isActive instead")]
    public Bool8 Active
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLVertexAttributeBindings.Active);
    }

    /// <summary>
    /// Deprecated: please use isPatchControlPointData instead
    /// </summary>
    [Obsolete("please use isPatchControlPointData instead")]
    public Bool8 PatchControlPointData
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLVertexAttributeBindings.PatchControlPointData);
    }

    /// <summary>
    /// Deprecated: please use isPatchData instead
    /// </summary>
    [Obsolete("please use isPatchData instead")]
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
