namespace Metal.NET;

public partial class MTL4MachineLearningCommandEncoder : NativeObject
{
    public MTL4MachineLearningCommandEncoder(nint nativePtr) : base(nativePtr)
    {
    }

    public void DispatchNetwork(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderSelector.DispatchNetwork, heap.NativePtr);
    }
}

file static class MTL4MachineLearningCommandEncoderSelector
{
    public static readonly Selector DispatchNetwork = Selector.Register("dispatchNetworkWithIntermediatesHeap:");
}
