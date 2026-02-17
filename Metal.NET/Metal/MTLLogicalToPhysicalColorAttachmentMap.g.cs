namespace Metal.NET;

file class MTLLogicalToPhysicalColorAttachmentMapSelector
{
    public static readonly Selector GetPhysicalIndex_ = Selector.Register("getPhysicalIndex:");
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetPhysicalIndex_logicalIndex_ = Selector.Register("setPhysicalIndex:logicalIndex:");
}

public class MTLLogicalToPhysicalColorAttachmentMap : IDisposable
{
    public MTLLogicalToPhysicalColorAttachmentMap(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public nuint GetPhysicalIndex(nuint logicalIndex)
    {
        var result = (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapSelector.GetPhysicalIndex_, (nint)logicalIndex);

        return result;
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapSelector.Reset);
    }

    public void SetPhysicalIndex(nuint physicalIndex, nuint logicalIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapSelector.SetPhysicalIndex_logicalIndex_, (nint)physicalIndex, (nint)logicalIndex);
    }

}
