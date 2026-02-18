namespace Metal.NET;

public class MTL4MachineLearningCommandEncoder(nint nativePtr) : MTL4CommandEncoder(nativePtr)
{

    public void DispatchNetwork(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderSelector.DispatchNetwork, heap.NativePtr);
    }
}

file static class MTL4MachineLearningCommandEncoderSelector
{
    public static readonly Selector DispatchNetwork = Selector.Register("dispatchNetworkWithIntermediatesHeap:");
}
