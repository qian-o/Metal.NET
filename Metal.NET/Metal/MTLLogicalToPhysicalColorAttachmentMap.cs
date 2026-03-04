namespace Metal.NET;

public class MTLLogicalToPhysicalColorAttachmentMap(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLLogicalToPhysicalColorAttachmentMap>
{
    #region INativeObject
    public static MTLLogicalToPhysicalColorAttachmentMap Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLLogicalToPhysicalColorAttachmentMap New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLLogicalToPhysicalColorAttachmentMap() : this(ObjectiveC.AllocInit(MTLLogicalToPhysicalColorAttachmentMapBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint GetPhysicalIndex(nuint logicalIndex)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLLogicalToPhysicalColorAttachmentMapBindings.GetPhysicalIndex, logicalIndex);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapBindings.Reset);
    }

    public void SetPhysicalIndex(nuint physicalIndex, nuint logicalIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapBindings.SetPhysicalIndex, physicalIndex, logicalIndex);
    }
}

file static class MTLLogicalToPhysicalColorAttachmentMapBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLLogicalToPhysicalColorAttachmentMap");

    public static readonly Selector GetPhysicalIndex = "getPhysicalIndexForLogicalIndex:";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetPhysicalIndex = "setPhysicalIndex:forLogicalIndex:";
}
