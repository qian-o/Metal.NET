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

    public nuint GetPhysicalIndex(uint logicalIndex)
    {
        var result = (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapSelector.GetPhysicalIndex, (nint)logicalIndex);

        return result;
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapSelector.Reset);
    }

    public void SetPhysicalIndex(uint physicalIndex, uint logicalIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapSelector.SetPhysicalIndexLogicalIndex, (nint)physicalIndex, (nint)logicalIndex);
    }

}

file class MTLLogicalToPhysicalColorAttachmentMapSelector
{
    public static readonly Selector GetPhysicalIndex = Selector.Register("getPhysicalIndex:");
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetPhysicalIndexLogicalIndex = Selector.Register("setPhysicalIndex:logicalIndex:");
}
