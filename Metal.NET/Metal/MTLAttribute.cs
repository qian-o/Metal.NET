namespace Metal.NET;

public class MTLAttribute(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLAttribute() : this(ObjectiveCRuntime.AllocInit(MTLAttributeSelector.Class))
    {
    }

    public bool Active
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeSelector.Active);
    }

    public nuint AttributeIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAttributeSelector.AttributeIndex);
    }

    public MTLDataType AttributeType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAttributeSelector.AttributeType);
    }

    public bool IsActive
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeSelector.IsActive);
    }

    public bool IsPatchControlPointData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeSelector.IsPatchControlPointData);
    }

    public bool IsPatchData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeSelector.IsPatchData);
    }

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAttributeSelector.Name));
    }

    public bool PatchControlPointData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeSelector.PatchControlPointData);
    }

    public bool PatchData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeSelector.PatchData);
    }
}

file static class MTLAttributeSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAttribute");

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
