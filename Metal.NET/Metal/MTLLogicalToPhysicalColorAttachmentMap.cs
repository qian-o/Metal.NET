namespace Metal.NET;

public class MTLLogicalToPhysicalColorAttachmentMap(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLLogicalToPhysicalColorAttachmentMap() : this(ObjectiveCRuntime.AllocInit(MTLLogicalToPhysicalColorAttachmentMapSelector.Class))
    {
    }

    public nuint GetPhysicalIndex(nuint logicalIndex)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLLogicalToPhysicalColorAttachmentMapSelector.GetPhysicalIndex, logicalIndex);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapSelector.Reset);
    }

    public void SetPhysicalIndex(nuint physicalIndex, nuint logicalIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapSelector.SetPhysicalIndex, physicalIndex, logicalIndex);
    }
}

file static class MTLLogicalToPhysicalColorAttachmentMapSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLLogicalToPhysicalColorAttachmentMap");

    public static readonly Selector GetPhysicalIndex = Selector.Register("getPhysicalIndexForLogicalIndex:");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetPhysicalIndex = Selector.Register("setPhysicalIndex:forLogicalIndex:");
}
