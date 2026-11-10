namespace Metal.NET;

public readonly struct MTLVertexAttribute(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLVertexAttribute value) => new(value.NativePtr);

    public MTLVertexAttribute Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLVertexAttributeBindings.Name));
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

    public Bool8 IsPatchData
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLVertexAttributeBindings.IsPatchData);
    }

    public Bool8 IsPatchControlPointData
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLVertexAttributeBindings.IsPatchControlPointData);
    }
}

file static class MTLVertexAttributeBindings
{
    public static readonly Selector AttributeIndex = "attributeIndex";

    public static readonly Selector AttributeType = "attributeType";

    public static readonly Selector IsActive = "isActive";

    public static readonly Selector IsPatchControlPointData = "isPatchControlPointData";

    public static readonly Selector IsPatchData = "isPatchData";

    public static readonly Selector Name = "name";
}
