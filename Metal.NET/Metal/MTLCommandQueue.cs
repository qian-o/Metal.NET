namespace Metal.NET;

/// <summary>
/// An instance you use to create, submit, and schedule command buffers to a specific GPU device to run the commands within those buffers.
/// </summary>
public class MTLCommandQueue(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLCommandQueue>
{
    #region INativeObject
    public static new MTLCommandQueue Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLCommandQueue New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying the command queue - Properties

    /// <summary>
    /// The GPU device that creates the command queue.
    /// </summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLCommandQueueBindings.Device);
    }

    /// <summary>
    /// An optional name that can help you identify the command queue.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLCommandQueueBindings.Label);
        set => SetProperty(ref field, MTLCommandQueueBindings.SetLabel, value);
    }
    #endregion

    #region Creating command buffers - Methods

    /// <summary>
    /// Returns a command buffer from the command queue that you configure with a descriptor.
    /// </summary>
    public MTLCommandBuffer CommandBuffer()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandQueueBindings.CommandBuffer);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Returns a command buffer from the command queue that you configure with a descriptor.
    /// </summary>
    public MTLCommandBuffer CommandBufferWithDescriptor(MTLCommandBufferDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandQueueBindings.CommandBufferWithDescriptor, descriptor.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Returns a command buffer from the command queue that doesn’t maintain strong references to resources.
    /// </summary>
    public MTLCommandBuffer CommandBufferWithUnretainedReferences()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandQueueBindings.CommandBufferWithUnretainedReferences);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Attaching residency sets - Methods

    /// <summary>
    /// Applies a residency set to a queue, which Metal applies to the queue’s command buffers as you commit them.
    /// </summary>
    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandQueueBindings.AddResidencySet, residencySet.NativePtr);
    }

    /// <summary>
    /// Applies multiple residency sets to a queue, which Metal applies to the queue’s command buffers as you commit them.
    /// </summary>
    public unsafe void AddResidencySets(MTLResidencySet[] residencySets)
    {
        nint* pResidencySets = stackalloc nint[residencySets.Length];
        for (int i = 0; i < residencySets.Length; i++)
        {
            pResidencySets[i] = residencySets[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLCommandQueueBindings.AddResidencySets, (nint)pResidencySets, (nuint)residencySets.Length);
    }
    #endregion

    #region Detaching residency sets - Methods

    /// <summary>
    /// Removes a residency set from a command queue’s list, which means Metal doesn’t apply it to the queue’s command buffers as you commit them.
    /// </summary>
    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandQueueBindings.RemoveResidencySet, residencySet.NativePtr);
    }

    /// <summary>
    /// Removes multiple residency sets from a command queue’s list, which means Metal doesn’t apply them to the queue’s command buffers as you commit them.
    /// </summary>
    public unsafe void RemoveResidencySets(MTLResidencySet[] residencySets)
    {
        nint* pResidencySets = stackalloc nint[residencySets.Length];
        for (int i = 0; i < residencySets.Length; i++)
        {
            pResidencySets[i] = residencySets[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLCommandQueueBindings.RemoveResidencySets, (nint)pResidencySets, (nuint)residencySets.Length);
    }
    #endregion

    #region Deprecated - Methods

    /// <summary>
    /// Informs Xcode about when GPU Frame Capture starts and stops.
    /// </summary>
    [Obsolete("Use MTLCaptureManager and MTLCaptureScope instead. See Naming resources and commands for more information.")]
    public void InsertDebugCaptureBoundary()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandQueueBindings.InsertDebugCaptureBoundary);
    }
    #endregion
}

file static class MTLCommandQueueBindings
{
    public static readonly Selector AddResidencySet = "addResidencySet:";

    public static readonly Selector AddResidencySets = "addResidencySets:count:";

    public static readonly Selector CommandBuffer = "commandBuffer";

    public static readonly Selector CommandBufferWithDescriptor = "commandBufferWithDescriptor:";

    public static readonly Selector CommandBufferWithUnretainedReferences = "commandBufferWithUnretainedReferences";

    public static readonly Selector Device = "device";

    public static readonly Selector InsertDebugCaptureBoundary = "insertDebugCaptureBoundary";

    public static readonly Selector Label = "label";

    public static readonly Selector RemoveResidencySet = "removeResidencySet:";

    public static readonly Selector RemoveResidencySets = "removeResidencySets:count:";

    public static readonly Selector SetLabel = "setLabel:";
}
