namespace Metal.NET;

public class MTLVertexAttribute : IDisposable
{
    public MTLVertexAttribute(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLVertexAttribute()
    {
        Release();
    }

    public nint NativePtr { get; }

    public Bool8 Active
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeSelector.Active);
    }

    public nuint AttributeIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLVertexAttributeSelector.AttributeIndex);
    }

    public MTLDataType AttributeType
    {
        get => (MTLDataType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLVertexAttributeSelector.AttributeType));
    }

    public Bool8 IsActive
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeSelector.IsActive);
    }

    public Bool8 IsPatchControlPointData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeSelector.IsPatchControlPointData);
    }

    public Bool8 IsPatchData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeSelector.IsPatchData);
    }

    public NSString Name
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexAttributeSelector.Name));
    }

    public Bool8 PatchControlPointData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeSelector.PatchControlPointData);
    }

    public Bool8 PatchData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLVertexAttributeSelector.PatchData);
    }

    public static implicit operator nint(MTLVertexAttribute value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLVertexAttribute(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLVertexAttributeSelector
{
    public static readonly Selector Active = Selector.Register("active");

    public static readonly Selector AttributeIndex = Selector.Register("attributeIndex");

    public static readonly Selector AttributeType = Selector.Register("attributeType");

    public static readonly Selector IsActive = Selector.Register("isActive");

    public static readonly Selector IsPatchControlPointData = Selector.Register("isPatchControlPointData");

    public static readonly Selector IsPatchData = Selector.Register("isPatchData");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector PatchControlPointData = Selector.Register("patchControlPointData");

    public static readonly Selector PatchData = Selector.Register("patchData");
}
