namespace Metal.NET;

public readonly struct MTLTensorBufferAttachments(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLTensorBufferAttachments value) => new(value.NativePtr);

    public MTLTensorBufferAttachments() : this(ObjectiveC.AllocInit(MTLTensorBufferAttachmentsBindings.Class))
    {
    }

    public MTLTensorBufferAttachments Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, MTLTensorPlaneType plane)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBufferAttachmentsBindings.SetBuffer_Offset_ForPlane, buffer.NativePtr, offset, (nint)plane);
    }

    public MTLBuffer Buffer(MTLTensorPlaneType plane)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTensorBufferAttachmentsBindings.BufferForPlane, (nint)plane);

        return new(nativePtr);
    }

    public nuint Offset(MTLTensorPlaneType plane)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, MTLTensorBufferAttachmentsBindings.OffsetForPlane, (nint)plane);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBufferAttachmentsBindings.Reset);
    }
}

file static class MTLTensorBufferAttachmentsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTensorBufferAttachments");

    public static readonly Selector BufferForPlane = "bufferForPlane:";

    public static readonly Selector OffsetForPlane = "offsetForPlane:";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetBuffer_Offset_ForPlane = "setBuffer:offset:forPlane:";
}
