namespace Metal.NET;

public readonly struct MTL4MachineLearningCommandEncoder(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public void DispatchNetwork(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.DispatchNetwork, heap.NativePtr);
    }
}

file static class MTL4MachineLearningCommandEncoderBindings
{
    public static readonly Selector DispatchNetwork = Selector.Register("dispatchNetworkWithIntermediatesHeap:");
}
