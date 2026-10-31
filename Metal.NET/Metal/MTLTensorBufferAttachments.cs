namespace Metal.NET;

public class MTLTensorBufferAttachments(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLTensorBufferAttachments>
{
    #region INativeObject
    public static new MTLTensorBufferAttachments Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTensorBufferAttachments New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public void SetBuffer(MTLBuffer buffer, nuint offset, MTLTensorPlaneType plane)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBufferAttachmentsBindings.SetBuffer_Offset_ForPlane, buffer.NativePtr, offset, (nint)plane);
    }

    public MTLBuffer Buffer(MTLTensorPlaneType plane)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTensorBufferAttachmentsBindings.BufferForPlane, (nint)plane);

        return new(nativePtr, NativeObjectOwnership.Owned);
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
    public static readonly Selector BufferForPlane = "bufferForPlane:";

    public static readonly Selector OffsetForPlane = "offsetForPlane:";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetBuffer_Offset_ForPlane = "setBuffer:offset:forPlane:";
}
