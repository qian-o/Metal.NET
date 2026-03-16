namespace Metal.NET;

/// <summary>A description of how to dispatch execution of pass commands and GPU performance sampling.</summary>
public class MTLComputePassDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLComputePassDescriptor>
{
    #region INativeObject
    public static new MTLComputePassDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLComputePassDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLComputePassDescriptor() : this(ObjectiveC.AllocInit(MTLComputePassDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring the dispatch mechanism - Properties

    /// <summary>The strategy for dispatching any compute commands encoded in the compute pass.</summary>
    public MTLDispatchType DispatchType
    {
        get => (MTLDispatchType)ObjectiveC.MsgSendULong(NativePtr, MTLComputePassDescriptorBindings.DispatchType);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePassDescriptorBindings.SetDispatchType, (nuint)value);
    }
    #endregion

    #region Specifying sample buffers for GPU counters - Properties

    /// <summary>The sample buffers that the compute pass can access.</summary>
    public MTLComputePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLComputePassDescriptorBindings.SampleBufferAttachments);
    }
    #endregion

    public static MTLComputePassDescriptor ComputePassDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLComputePassDescriptorBindings.Class, MTLComputePassDescriptorBindings.ComputePassDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLComputePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLComputePassDescriptor");

    public static readonly Selector ComputePassDescriptor = "computePassDescriptor";

    public static readonly Selector DispatchType = "dispatchType";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";

    public static readonly Selector SetDispatchType = "setDispatchType:";
}
