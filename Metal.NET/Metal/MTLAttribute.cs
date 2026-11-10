namespace Metal.NET;

public readonly struct MTLAttribute(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLAttribute value) => new(value.NativePtr);

    public MTLAttribute Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAttributeBindings.Name));
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

    public Bool8 IsPatchData
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAttributeBindings.IsPatchData);
    }

    public Bool8 IsPatchControlPointData
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAttributeBindings.IsPatchControlPointData);
    }
}

file static class MTLAttributeBindings
{
    public static readonly Selector AttributeIndex = "attributeIndex";

    public static readonly Selector AttributeType = "attributeType";

    public static readonly Selector IsActive = "isActive";

    public static readonly Selector IsPatchControlPointData = "isPatchControlPointData";

    public static readonly Selector IsPatchData = "isPatchData";

    public static readonly Selector Name = "name";
}
