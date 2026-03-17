namespace Metal.NET;

public class MTLStageInputOutputDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLStageInputOutputDescriptor>
{
    #region INativeObject
    public static new MTLStageInputOutputDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLStageInputOutputDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLStageInputOutputDescriptor() : this(ObjectiveC.AllocInit(MTLStageInputOutputDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLBufferLayoutDescriptorArray Layouts
    {
        get => GetProperty(ref field, MTLStageInputOutputDescriptorBindings.Layouts);
    }

    public MTLAttributeDescriptorArray Attributes
    {
        get => GetProperty(ref field, MTLStageInputOutputDescriptorBindings.Attributes);
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

    public static MTLStageInputOutputDescriptor StageInputOutputDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLStageInputOutputDescriptorBindings.Class, MTLStageInputOutputDescriptorBindings.StageInputOutputDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLStageInputOutputDescriptorBindings.Reset);
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
