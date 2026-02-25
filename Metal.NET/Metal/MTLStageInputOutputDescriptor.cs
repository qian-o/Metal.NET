namespace Metal.NET;

public class MTLStageInputOutputDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLStageInputOutputDescriptor>
{
    public static MTLStageInputOutputDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLStageInputOutputDescriptor Null => new(0, false);

    public MTLStageInputOutputDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLStageInputOutputDescriptorBindings.Class), true)
    {
    }

    public MTLAttributeDescriptorArray Attributes
    {
        get => GetProperty(ref field, MTLStageInputOutputDescriptorBindings.Attributes);
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

    public MTLBufferLayoutDescriptorArray Layouts
    {
        get => GetProperty(ref field, MTLStageInputOutputDescriptorBindings.Layouts);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLStageInputOutputDescriptorBindings.Reset);
    }

    public static MTLStageInputOutputDescriptor StageInputOutputDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLStageInputOutputDescriptorBindings.Class, MTLStageInputOutputDescriptorBindings.StageInputOutputDescriptor);

        return new(nativePtr, false);
    }
}

file static class MTLStageInputOutputDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStageInputOutputDescriptor");

    public static readonly Selector Attributes = "attributes";

    public static readonly Selector IndexBufferIndex = "indexBufferIndex";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector Layouts = "layouts";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetIndexBufferIndex = "setIndexBufferIndex:";

    public static readonly Selector SetIndexType = "setIndexType:";

    public static readonly Selector StageInputOutputDescriptor = "stageInputOutputDescriptor";
}
