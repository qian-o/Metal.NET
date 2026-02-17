namespace Metal.NET;

public class MTLLogicalToPhysicalColorAttachmentMap : IDisposable
{
    public MTLLogicalToPhysicalColorAttachmentMap(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLLogicalToPhysicalColorAttachmentMap()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint GetPhysicalIndex(nuint logicalIndex)
    {
        nuint result = ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLLogicalToPhysicalColorAttachmentMapSelector.GetPhysicalIndex, logicalIndex);

        return result;
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapSelector.Reset);
    }

    public void SetPhysicalIndex(nuint physicalIndex, nuint logicalIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapSelector.SetPhysicalIndexLogicalIndex, physicalIndex, logicalIndex);
    }

    public static implicit operator nint(MTLLogicalToPhysicalColorAttachmentMap value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLLogicalToPhysicalColorAttachmentMap(nint value)
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

file class MTLLogicalToPhysicalColorAttachmentMapSelector
{
    public static readonly Selector GetPhysicalIndex = Selector.Register("getPhysicalIndex:");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetPhysicalIndexLogicalIndex = Selector.Register("setPhysicalIndex:logicalIndex:");
}
