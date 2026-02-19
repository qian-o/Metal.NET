namespace Metal.NET;

public class MTLCommandQueue(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLCommandBuffer? CommandBuffer
    {
        get => GetProperty(ref field, MTLCommandQueueBindings.CommandBuffer);
    }

    public MTLCommandBuffer? CommandBufferWithUnretainedReferences
    {
        get => GetProperty(ref field, MTLCommandQueueBindings.CommandBufferWithUnretainedReferences);
    }

    public MTLDevice? Device
    {
        get => GetProperty(ref field, MTLCommandQueueBindings.Device);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTLCommandQueueBindings.Label);
        set => SetProperty(ref field, MTLCommandQueueBindings.SetLabel, value);
    }

    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueBindings.AddResidencySet, residencySet.NativePtr);
    }

    public MTLCommandBuffer? CommandBufferWithDescriptor(MTLCommandBufferDescriptor descriptor)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueBindings.CommandBufferWithDescriptor, descriptor.NativePtr);

        if (nativePtr is 0)
        {
            return null;
        }

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr);
    }

    public void InsertDebugCaptureBoundary()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueBindings.InsertDebugCaptureBoundary);
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandQueueBindings.RemoveResidencySet, residencySet.NativePtr);
    }
}

file static class MTLCommandQueueBindings
{
    public static readonly Selector AddResidencySet = "addResidencySet:";

    public static readonly Selector CommandBuffer = "commandBuffer";

    public static readonly Selector CommandBufferWithDescriptor = "commandBufferWithDescriptor:";

    public static readonly Selector CommandBufferWithUnretainedReferences = "commandBufferWithUnretainedReferences";

    public static readonly Selector Device = "device";

    public static readonly Selector InsertDebugCaptureBoundary = "insertDebugCaptureBoundary";

    public static readonly Selector Label = "label";

    public static readonly Selector RemoveResidencySet = "removeResidencySet:";

    public static readonly Selector SetLabel = "setLabel:";
}
