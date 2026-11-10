namespace Metal.NET;

public readonly struct MTLStageInputOutputDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLStageInputOutputDescriptor value) => new(value.NativePtr);

    public MTLStageInputOutputDescriptor() : this(ObjectiveC.AllocInit(MTLStageInputOutputDescriptorBindings.Class))
    {
    }

    public MTLStageInputOutputDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLBufferLayoutDescriptorArray Layouts
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLStageInputOutputDescriptorBindings.Layouts));
    }

    public MTLAttributeDescriptorArray Attributes
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLStageInputOutputDescriptorBindings.Attributes));
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTLStageInputOutputDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTLStageInputOutputDescriptorBindings.SetIndexType, (nuint)value);
    }

    public nuint IndexBufferIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLStageInputOutputDescriptorBindings.IndexBufferIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLStageInputOutputDescriptorBindings.SetIndexBufferIndex, value);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLStageInputOutputDescriptorBindings.Reset);
    }

    public static MTLStageInputOutputDescriptor StageInputOutputDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLStageInputOutputDescriptorBindings.Class, MTLStageInputOutputDescriptorBindings.StageInputOutputDescriptor);

        return new(nativePtr);
    }
}

file static class MTLStageInputOutputDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLStageInputOutputDescriptor");

    public static readonly Selector Attributes = "attributes";

    public static readonly Selector IndexBufferIndex = "indexBufferIndex";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector Layouts = "layouts";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetIndexBufferIndex = "setIndexBufferIndex:";

    public static readonly Selector SetIndexType = "setIndexType:";

    public static readonly Selector StageInputOutputDescriptor = "stageInputOutputDescriptor";
}
