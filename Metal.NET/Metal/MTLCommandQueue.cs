namespace Metal.NET;

public readonly struct MTLCommandQueue(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLCommandQueue value) => new(value.NativePtr);

    public MTLCommandQueue Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCommandQueueBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLCommandQueueBindings.SetLabel, value.NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLCommandQueueBindings.Device));
    }

    public MTLCommandBuffer MakeCommandBuffer()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandQueueBindings.CommandBuffer);

        return new(nativePtr);
    }

    public MTLCommandBuffer MakeCommandBuffer(MTLCommandBufferDescriptor descriptor)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandQueueBindings.CommandBufferWithDescriptor, descriptor.NativePtr);

        return new(nativePtr);
    }

    public MTLCommandBuffer MakeCommandBufferWithUnretainedReferences()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLCommandQueueBindings.CommandBufferWithUnretainedReferences);

        return new(nativePtr);
    }

    /// <summary>
    /// Deprecated: Use MTLCaptureScope instead
    /// </summary>
    [Obsolete("Use MTLCaptureScope instead")]
    public void InsertDebugCaptureBoundary()
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandQueueBindings.InsertDebugCaptureBoundary);
    }

    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandQueueBindings.AddResidencySet, residencySet.NativePtr);
    }

    public unsafe void AddResidencySets(ReadOnlySpan<MTLResidencySet> residencySets)
    {
        fixed (MTLResidencySet* pResidencySets = residencySets)
        {
            ObjectiveC.MsgSend(NativePtr, MTLCommandQueueBindings.AddResidencySets_Count, (nint)pResidencySets, (nuint)residencySets.Length);
        }
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveC.MsgSend(NativePtr, MTLCommandQueueBindings.RemoveResidencySet, residencySet.NativePtr);
    }

    public unsafe void RemoveResidencySets(ReadOnlySpan<MTLResidencySet> residencySets)
    {
        fixed (MTLResidencySet* pResidencySets = residencySets)
        {
            ObjectiveC.MsgSend(NativePtr, MTLCommandQueueBindings.RemoveResidencySets_Count, (nint)pResidencySets, (nuint)residencySets.Length);
        }
    }
}

file static class MTLCommandQueueBindings
{
    public static readonly Selector AddResidencySet = "addResidencySet:";

    public static readonly Selector AddResidencySets_Count = "addResidencySets:count:";

    public static readonly Selector CommandBuffer = "commandBuffer";

    public static readonly Selector CommandBufferWithDescriptor = "commandBufferWithDescriptor:";

    public static readonly Selector CommandBufferWithUnretainedReferences = "commandBufferWithUnretainedReferences";

    public static readonly Selector Device = "device";

    public static readonly Selector InsertDebugCaptureBoundary = "insertDebugCaptureBoundary";

    public static readonly Selector Label = "label";

    public static readonly Selector RemoveResidencySet = "removeResidencySet:";

    public static readonly Selector RemoveResidencySets_Count = "removeResidencySets:count:";

    public static readonly Selector SetLabel = "setLabel:";
}
