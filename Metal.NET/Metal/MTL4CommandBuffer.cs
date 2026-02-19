namespace Metal.NET;

public class MTL4CommandBuffer(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4ComputeCommandEncoder? ComputeCommandEncoder
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferBindings.ComputeCommandEncoder);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4ComputeCommandEncoder(ptr);
            }

            return field;
        }
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferBindings.Device);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLDevice(ptr);
            }

            return field;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTL4MachineLearningCommandEncoder? MachineLearningCommandEncoder
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferBindings.MachineLearningCommandEncoder);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4MachineLearningCommandEncoder(ptr);
            }

            return field;
        }
    }

    public void BeginCommandBuffer(MTL4CommandAllocator allocator)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.BeginCommandBuffer, allocator.NativePtr);
    }

    public void BeginCommandBuffer(MTL4CommandAllocator allocator, MTL4CommandBufferOptions options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.BeginCommandBuffer, allocator.NativePtr, options.NativePtr);
    }

    public void EndCommandBuffer()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.EndCommandBuffer);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.PushDebugGroup, @string.NativePtr);
    }

    public MTL4RenderCommandEncoder? RenderCommandEncoder(MTL4RenderPassDescriptor descriptor)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferBindings.RenderCommandEncoder, descriptor.NativePtr);
        return ptr is not 0 ? new MTL4RenderCommandEncoder(ptr) : null;
    }

    public MTL4RenderCommandEncoder? RenderCommandEncoder(MTL4RenderPassDescriptor descriptor, MTL4RenderEncoderOptions options)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandBufferBindings.RenderCommandEncoder, descriptor.NativePtr, (nuint)options);
        return ptr is not 0 ? new MTL4RenderCommandEncoder(ptr) : null;
    }

    public void ResolveCounterHeap(MTL4CounterHeap counterHeap, NSRange range, MTL4BufferRange bufferRange, MTLFence fenceToWait, MTLFence fenceToUpdate)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.ResolveCounterHeap, counterHeap.NativePtr, range, bufferRange, fenceToWait.NativePtr, fenceToUpdate.NativePtr);
    }

    public void UseResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.UseResidencySet, residencySet.NativePtr);
    }

    public void WriteTimestampIntoHeap(MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandBufferBindings.WriteTimestampIntoHeap, counterHeap.NativePtr, index);
    }
}

file static class MTL4CommandBufferBindings
{
    public static readonly Selector BeginCommandBuffer = Selector.Register("beginCommandBufferWithAllocator:");

    public static readonly Selector ComputeCommandEncoder = Selector.Register("computeCommandEncoder");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector EndCommandBuffer = Selector.Register("endCommandBuffer");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector MachineLearningCommandEncoder = Selector.Register("machineLearningCommandEncoder");

    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");

    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");

    public static readonly Selector RenderCommandEncoder = Selector.Register("renderCommandEncoderWithDescriptor:");

    public static readonly Selector ResolveCounterHeap = Selector.Register("resolveCounterHeap:withRange:intoBuffer:waitFence:updateFence:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector UseResidencySet = Selector.Register("useResidencySet:");

    public static readonly Selector WriteTimestampIntoHeap = Selector.Register("writeTimestampIntoHeap:atIndex:");
}
