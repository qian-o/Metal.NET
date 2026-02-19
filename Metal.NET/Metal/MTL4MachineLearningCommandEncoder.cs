namespace Metal.NET;

public class MTL4MachineLearningCommandEncoder(nint nativePtr) : MTL4CommandEncoder(nativePtr)
{
    public void DispatchNetwork(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.DispatchNetwork, heap.NativePtr);
    }
}

file static class MTL4MachineLearningCommandEncoderBindings
{
    public static readonly Selector DispatchNetwork = "dispatchNetworkWithIntermediatesHeap:";
}
