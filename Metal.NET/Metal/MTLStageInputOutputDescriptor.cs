namespace Metal.NET;

public partial class MTLStageInputOutputDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStageInputOutputDescriptor");

    public MTLStageInputOutputDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLAttributeDescriptorArray? Attributes
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStageInputOutputDescriptorSelector.Attributes);
            return ptr is not 0 ? new(ptr) : null;
        }
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
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStageInputOutputDescriptorSelector.Layouts);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLStageInputOutputDescriptorSelector.Reset);
    }

    public static MTLStageInputOutputDescriptor? StageInputOutputDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLStageInputOutputDescriptorSelector.StageInputOutputDescriptor);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLStageInputOutputDescriptorSelector
{
    public static readonly Selector Attributes = Selector.Register("attributes");

    public static readonly Selector IndexBufferIndex = Selector.Register("indexBufferIndex");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector Layouts = Selector.Register("layouts");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetIndexBufferIndex = Selector.Register("setIndexBufferIndex:");

    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");

    public static readonly Selector StageInputOutputDescriptor = Selector.Register("stageInputOutputDescriptor");
}
