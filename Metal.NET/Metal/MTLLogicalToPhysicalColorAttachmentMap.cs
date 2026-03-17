namespace Metal.NET;

public class MTLLogicalToPhysicalColorAttachmentMap(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLLogicalToPhysicalColorAttachmentMap>
{
    #region INativeObject
    public static new MTLLogicalToPhysicalColorAttachmentMap Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLLogicalToPhysicalColorAttachmentMap New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public void SetPhysicalIndexForLogicalIndex(nuint physicalIndex, nuint logicalIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapBindings.SetPhysicalIndex, physicalIndex, logicalIndex);
    }

    public void SetPhysicalIndex(nuint physicalIndex, nuint logicalIndex)
    {
        SetPhysicalIndexForLogicalIndex(physicalIndex, logicalIndex);
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

    public static readonly Selector SetPhysicalIndex = "setPhysicalIndex:forLogicalIndex:";
}
