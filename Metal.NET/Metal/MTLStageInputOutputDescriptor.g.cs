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

    public static MTLStageInputOutputDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLStageInputOutputDescriptor(ptr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStageInputOutputDescriptorSelector.Reset);
    }

    public void SetIndexBufferIndex(uint indexBufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStageInputOutputDescriptorSelector.SetIndexBufferIndex, (nint)indexBufferIndex);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStageInputOutputDescriptorSelector.SetIndexType, (nint)(uint)indexType);
    }

    public static MTLStageInputOutputDescriptor StageInputOutputDescriptor()
    {
        var result = new MTLStageInputOutputDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLStageInputOutputDescriptorSelector.StageInputOutputDescriptor));

        return result;
    }

}

file class MTLStageInputOutputDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetIndexBufferIndex = Selector.Register("setIndexBufferIndex:");
    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");
    public static readonly Selector StageInputOutputDescriptor = Selector.Register("stageInputOutputDescriptor");
}
