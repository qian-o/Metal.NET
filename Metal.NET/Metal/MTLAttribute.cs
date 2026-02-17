namespace Metal.NET;

public class MTLAttribute : IDisposable
{
    public MTLAttribute(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLAttribute()
    {
        Release();
    }

    public nint NativePtr { get; }

    public Bool8 Active
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeSelector.Active);
    }

    public nuint AttributeIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAttributeSelector.AttributeIndex);
    }

    public MTLDataType AttributeType
    {
        get => (MTLDataType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLAttributeSelector.AttributeType));
    }

    public Bool8 IsActive
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeSelector.IsActive);
    }

    public Bool8 IsPatchControlPointData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeSelector.IsPatchControlPointData);
    }

    public Bool8 IsPatchData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeSelector.IsPatchData);
    }

    public NSString Name
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAttributeSelector.Name));
    }

    public Bool8 PatchControlPointData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeSelector.PatchControlPointData);
    }

    public Bool8 PatchData
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLAttributeSelector.PatchData);
    }

    public static implicit operator nint(MTLAttribute value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAttribute(nint value)
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

file class MTLAttributeSelector
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
