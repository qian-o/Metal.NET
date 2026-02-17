namespace Metal.NET;

public class MTLStageInputOutputDescriptor : IDisposable
{
    public MTLStageInputOutputDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLStageInputOutputDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLStageInputOutputDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLStageInputOutputDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLStageInputOutputDescriptor");

    public MTLStageInputOutputDescriptor() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public MTLAttributeDescriptorArray Attributes
    {
        get => new MTLAttributeDescriptorArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStageInputOutputDescriptorSelector.Attributes));
    }

    public nuint IndexBufferIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStageInputOutputDescriptorSelector.IndexBufferIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStageInputOutputDescriptorSelector.SetIndexBufferIndex, (nuint)value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLStageInputOutputDescriptorSelector.IndexType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStageInputOutputDescriptorSelector.SetIndexType, (uint)value);
    }

    public MTLBufferLayoutDescriptorArray Layouts
    {
        get => new MTLBufferLayoutDescriptorArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStageInputOutputDescriptorSelector.Layouts));
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLStageInputOutputDescriptorSelector.Reset);
    }

    public static MTLStageInputOutputDescriptor StageInputOutputDescriptor()
    {
        MTLStageInputOutputDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLStageInputOutputDescriptorSelector.StageInputOutputDescriptor));

        return result;
    }

}

file class MTLStageInputOutputDescriptorSelector
{
    public static readonly Selector Attributes = Selector.Register("attributes");

    public static readonly Selector IndexBufferIndex = Selector.Register("indexBufferIndex");

    public static readonly Selector SetIndexBufferIndex = Selector.Register("setIndexBufferIndex:");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");

    public static readonly Selector Layouts = Selector.Register("layouts");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector StageInputOutputDescriptor = Selector.Register("stageInputOutputDescriptor");
}
