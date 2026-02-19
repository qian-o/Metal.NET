namespace Metal.NET;

public class MTLLogicalToPhysicalColorAttachmentMap(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLLogicalToPhysicalColorAttachmentMap() : this(ObjectiveCRuntime.AllocInit(MTLLogicalToPhysicalColorAttachmentMapBindings.Class))
    {
    }

    public nuint GetPhysicalIndex(nuint logicalIndex)
    {
        return ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLLogicalToPhysicalColorAttachmentMapBindings.GetPhysicalIndex, logicalIndex);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapBindings.Reset);
    }

    public void SetPhysicalIndex(nuint physicalIndex, nuint logicalIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapBindings.SetPhysicalIndex, physicalIndex, logicalIndex);
    }
}

file static class MTLLogicalToPhysicalColorAttachmentMapBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLLogicalToPhysicalColorAttachmentMap");

    public static readonly Selector GetPhysicalIndex = Selector.Register("getPhysicalIndexForLogicalIndex:");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetPhysicalIndex = Selector.Register("setPhysicalIndex:forLogicalIndex:");
}
