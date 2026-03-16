namespace Metal.NET;

/// <summary>Encodes machine learning model inference commands for a single pass.</summary>
public class MTL4MachineLearningCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTL4CommandEncoder(nativePtr, ownership), INativeObject<MTL4MachineLearningCommandEncoder>
{
    #region INativeObject
    public static new MTL4MachineLearningCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4MachineLearningCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Configuring the pass - Methods

    /// <summary>Configures the encoder with a machine learning pipeline state instance.</summary>
    public void SetPipelineState(MTL4MachineLearningPipelineState pipelineState)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.SetPipelineState, pipelineState.NativePtr);
    }

    /// <summary>Sets an argument table for the command encoder’s machine learning shader stage.</summary>
    public void SetArgumentTable(MTL4ArgumentTable argumentTable)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.SetArgumentTable, argumentTable.NativePtr);
    }
    #endregion

    #region Running machine learning networks - Methods

    /// <summary>Dispatches a machine learning network using the current pipeline state and argument table.</summary>
    public void DispatchNetwork(MTLHeap heap)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.DispatchNetwork, heap.NativePtr);
    }
    #endregion
}

file static class MTL4MachineLearningCommandEncoderBindings
{
    public static readonly Selector DispatchNetwork = "dispatchNetworkWithIntermediatesHeap:";

    public static readonly Selector SetArgumentTable = "setArgumentTable:";

    public static readonly Selector SetPipelineState = "setPipelineState:";
}
