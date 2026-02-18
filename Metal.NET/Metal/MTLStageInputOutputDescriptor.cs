namespace Metal.NET;

public class MTLStageInputOutputDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStageInputOutputDescriptor");

    public MTLStageInputOutputDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLStageInputOutputDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLStageInputOutputDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLAttributeDescriptorArray Attributes
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStageInputOutputDescriptorSelector.Attributes));
    }

    public nuint IndexBufferIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStageInputOutputDescriptorSelector.IndexBufferIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStageInputOutputDescriptorSelector.SetIndexBufferIndex, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLStageInputOutputDescriptorSelector.IndexType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStageInputOutputDescriptorSelector.SetIndexType, (ulong)value);
    }

    public MTLBufferLayoutDescriptorArray Layouts
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStageInputOutputDescriptorSelector.Layouts));
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLStageInputOutputDescriptorSelector.Reset);
    }

    public static implicit operator nint(MTLStageInputOutputDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLStageInputOutputDescriptor(nint value)
    {
        return new(value);
    }

    public static MTLStageInputOutputDescriptor StageInputOutputDescriptor()
    {
        MTLStageInputOutputDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLStageInputOutputDescriptorSelector.StageInputOutputDescriptor));

        return result;
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
