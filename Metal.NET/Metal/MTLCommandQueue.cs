namespace Metal.NET;

public class MTLCommandQueue(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLCommandBuffer? CommandBuffer
    {
        get => GetNullableObject<MTLCommandBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueSelector.CommandBuffer));
    }

    public MTLCommandBuffer? CommandBufferWithUnretainedReferences
    {
        get => GetNullableObject<MTLCommandBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueSelector.CommandBufferWithUnretainedReferences));
    }

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueSelector.Device));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueSelector.AddResidencySet, residencySet.NativePtr);
    }

    public MTLCommandBuffer? CommandBufferWithDescriptor(MTLCommandBufferDescriptor descriptor)
    {
        return GetNullableObject<MTLCommandBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueSelector.CommandBuffer, descriptor.NativePtr));
    }

    public void InsertDebugCaptureBoundary()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueSelector.InsertDebugCaptureBoundary);
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueSelector.RemoveResidencySet, residencySet.NativePtr);
    }
}

file static class MTLCommandQueueSelector
{
    public static readonly Selector AddResidencySet = Selector.Register("addResidencySet:");

    public static readonly Selector CommandBuffer = Selector.Register("commandBuffer");

    public static readonly Selector CommandBufferWithUnretainedReferences = Selector.Register("commandBufferWithUnretainedReferences");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector InsertDebugCaptureBoundary = Selector.Register("insertDebugCaptureBoundary");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector RemoveResidencySet = Selector.Register("removeResidencySet:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
