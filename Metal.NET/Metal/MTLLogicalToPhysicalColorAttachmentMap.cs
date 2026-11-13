namespace Metal.NET;

public readonly struct MTLLogicalToPhysicalColorAttachmentMap(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLLogicalToPhysicalColorAttachmentMap value) => new(value.NativePtr);

    public MTLLogicalToPhysicalColorAttachmentMap Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public void SetPhysicalIndex(nuint physicalIndex, nuint logicalIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapBindings.SetPhysicalIndex_ForLogicalIndex, physicalIndex, logicalIndex);
    }

    public nuint GetPhysicalIndexForLogicalIndex(nuint logicalIndex)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLLogicalToPhysicalColorAttachmentMapBindings.GetPhysicalIndexForLogicalIndex, logicalIndex);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapBindings.Reset);
    }
}

file static class MTLLogicalToPhysicalColorAttachmentMapBindings
{
    public static readonly Selector GetPhysicalIndexForLogicalIndex = "getPhysicalIndexForLogicalIndex:";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetPhysicalIndex_ForLogicalIndex = "setPhysicalIndex:forLogicalIndex:";
}
