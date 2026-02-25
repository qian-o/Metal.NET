namespace Metal.NET;

public class MTLAttribute(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLAttribute>
{
    public static MTLAttribute Create(nint nativePtr) => new(nativePtr, true);

    public static MTLAttribute CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLAttribute() : this(ObjectiveCRuntime.AllocInit(MTLAttributeBindings.Class), true)
    {
    }

    public bool Active
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeBindings.Active);
    }

    public nuint AttributeIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAttributeBindings.AttributeIndex);
    }

    public MTLDataType AttributeType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAttributeBindings.AttributeType);
    }

    public bool IsActive
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeBindings.IsActive);
    }

    public bool IsPatchControlPointData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeBindings.IsPatchControlPointData);
    }

    public bool IsPatchData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeBindings.IsPatchData);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLAttributeBindings.Name);
    }

    public bool PatchControlPointData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeBindings.PatchControlPointData);
    }

    public bool PatchData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeBindings.PatchData);
    }
}

file static class MTLAttributeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAttribute");

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
