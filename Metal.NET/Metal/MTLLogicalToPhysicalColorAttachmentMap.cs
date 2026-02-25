namespace Metal.NET;

public class MTLLogicalToPhysicalColorAttachmentMap(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLLogicalToPhysicalColorAttachmentMap>
{
    public static MTLLogicalToPhysicalColorAttachmentMap Null { get; } = new(0, false);

    public static MTLLogicalToPhysicalColorAttachmentMap Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLLogicalToPhysicalColorAttachmentMap() : this(ObjectiveCRuntime.AllocInit(MTLLogicalToPhysicalColorAttachmentMapBindings.Class), true)
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

    public static readonly Selector GetPhysicalIndex = "getPhysicalIndexForLogicalIndex:";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetPhysicalIndex = "setPhysicalIndex:forLogicalIndex:";
}
