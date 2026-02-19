namespace Metal.NET;

public class MTLIndirectComputeCommand(nint nativePtr) : NativeObject(nativePtr)
{
    public void ClearBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.ClearBarrier);
    }

    public void ConcurrentDispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.ConcurrentDispatchThreadgroups, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void ConcurrentDispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.ConcurrentDispatchThreads, threadsPerGrid, threadsPerThreadgroup);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.Reset);
    }

    public void SetBarrier()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetBarrier);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetImageblockWidth, width, height);
    }

    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetKernelBuffer, buffer.NativePtr, offset, index);
    }

    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetKernelBuffer, buffer.NativePtr, offset, stride, index);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectComputeCommandBindings.SetThreadgroupMemoryLength, length, index);
    }
}

file static class MTLIndirectComputeCommandBindings
{
    public static readonly Selector ClearBarrier = Selector.Register("clearBarrier");

    public static readonly Selector ConcurrentDispatchThreadgroups = Selector.Register("concurrentDispatchThreadgroups:threadsPerThreadgroup:");

    public static readonly Selector ConcurrentDispatchThreads = Selector.Register("concurrentDispatchThreads:threadsPerThreadgroup:");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetBarrier = Selector.Register("setBarrier");

    public static readonly Selector SetImageblockWidth = Selector.Register("setImageblockWidth:height:");

    public static readonly Selector SetKernelBuffer = Selector.Register("setKernelBuffer:offset:atIndex:");

    public static readonly Selector SetThreadgroupMemoryLength = Selector.Register("setThreadgroupMemoryLength:atIndex:");
}
