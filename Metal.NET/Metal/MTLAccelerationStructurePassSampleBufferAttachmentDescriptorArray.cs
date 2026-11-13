namespace Metal.NET;

public readonly struct MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray value) => new(value.NativePtr);

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor this[nuint attachmentIndex]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings.Object, attachmentIndex);

            return new(nativePtr);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings.SetObject, value.NativePtr, attachmentIndex);
        }
    }
}

file static class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArrayBindings
{
    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
