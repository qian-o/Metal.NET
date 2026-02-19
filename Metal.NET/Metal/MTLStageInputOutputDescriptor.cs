namespace Metal.NET;

public class MTLStageInputOutputDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLStageInputOutputDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLStageInputOutputDescriptorBindings.Class))
    {
    }

    public MTLAttributeDescriptorArray? Attributes
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStageInputOutputDescriptorBindings.Attributes);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLAttributeDescriptorArray(ptr);
            }

            return field;
        }
    }

    public nuint IndexBufferIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStageInputOutputDescriptorBindings.IndexBufferIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStageInputOutputDescriptorBindings.SetIndexBufferIndex, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStageInputOutputDescriptorBindings.IndexType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStageInputOutputDescriptorBindings.SetIndexType, (nuint)value);
    }

    public MTLBufferLayoutDescriptorArray? Layouts
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStageInputOutputDescriptorBindings.Layouts);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLBufferLayoutDescriptorArray(ptr);
            }

            return field;
        }
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLStageInputOutputDescriptorBindings.Reset);
    }

    public static MTLStageInputOutputDescriptor? StageInputOutputDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLStageInputOutputDescriptorBindings.Class, MTLStageInputOutputDescriptorBindings.StageInputOutputDescriptor);
        return ptr is not 0 ? new MTLStageInputOutputDescriptor(ptr) : null;
    }
}

file static class MTLStageInputOutputDescriptorBindings
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
