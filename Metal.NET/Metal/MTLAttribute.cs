namespace Metal.NET;

public class MTLAttribute(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLAttribute>
{
    #region INativeObject
    public static new MTLAttribute Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAttribute New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLAttribute() : this(ObjectiveC.AllocInit(MTLAttributeBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    /// <summary>Deprecated: please use isActive instead</summary>
    [Obsolete("please use isActive instead")]
    public Bool8 Active
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAttributeBindings.Active);
    }

    public nuint AttributeIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAttributeBindings.AttributeIndex);
    }

    public MTLDataType AttributeType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLAttributeBindings.AttributeType);
    }

    public Bool8 IsActive
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAttributeBindings.IsActive);
    }

    public Bool8 IsPatchControlPointData
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAttributeBindings.IsPatchControlPointData);
    }

    public Bool8 IsPatchData
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAttributeBindings.IsPatchData);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLAttributeBindings.Name);
    }

    /// <summary>Deprecated: please use isPatchControlPointData instead</summary>
    [Obsolete("please use isPatchControlPointData instead")]
    public Bool8 PatchControlPointData
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAttributeBindings.PatchControlPointData);
    }

    /// <summary>Deprecated: please use isPatchData instead</summary>
    [Obsolete("please use isPatchData instead")]
    public Bool8 PatchData
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAttributeBindings.PatchData);
    }
}

file static class MTLAttributeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAttribute");

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
