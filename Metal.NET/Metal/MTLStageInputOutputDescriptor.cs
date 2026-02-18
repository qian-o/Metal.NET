namespace Metal.NET;

public class MTLStageInputOutputDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLStageInputOutputDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLStageInputOutputDescriptorSelector.Class))
    {
    }

    public MTLAttributeDescriptorArray? Attributes
    {
        get => GetNullableObject<MTLAttributeDescriptorArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStageInputOutputDescriptorSelector.Attributes));
    }

    public nuint IndexBufferIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStageInputOutputDescriptorSelector.IndexBufferIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStageInputOutputDescriptorSelector.SetIndexBufferIndex, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStageInputOutputDescriptorSelector.IndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStageInputOutputDescriptorSelector.SetIndexType, (nuint)value);
    }

    public MTLBufferLayoutDescriptorArray? Layouts
    {
        get => GetNullableObject<MTLBufferLayoutDescriptorArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStageInputOutputDescriptorSelector.Layouts));
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLStageInputOutputDescriptorSelector.Reset);
    }

    public static MTLStageInputOutputDescriptor? StageInputOutputDescriptor()
    {
        return GetNullableObject<MTLStageInputOutputDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLStageInputOutputDescriptorSelector.Class, MTLStageInputOutputDescriptorSelector.StageInputOutputDescriptor));
    }
}

file static class MTLStageInputOutputDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStageInputOutputDescriptor");

    public static readonly Selector Attributes = Selector.Register("attributes");

    public static readonly Selector IndexBufferIndex = Selector.Register("indexBufferIndex");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector Layouts = Selector.Register("layouts");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetIndexBufferIndex = Selector.Register("setIndexBufferIndex:");

    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");

    public static readonly Selector StageInputOutputDescriptor = Selector.Register("stageInputOutputDescriptor");
}
