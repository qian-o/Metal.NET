namespace Metal.NET;

/// <summary>An interface you can use to encode argument data into an argument buffer.</summary>
public class MTLArgumentEncoder(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLArgumentEncoder>
{
    #region INativeObject
    public static new MTLArgumentEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLArgumentEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Creating an argument buffer - Properties

    /// <summary>The number of bytes required to store the encoded resources of an argument buffer.</summary>
    public nuint EncodedLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentEncoderBindings.EncodedLength);
    }
    #endregion

    #region Querying alignment - Properties

    /// <summary>The alignment, in bytes, required for storing the encoded resources of an argument buffer.</summary>
    public nuint Alignment
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentEncoderBindings.Alignment);
    }
    #endregion

    #region Identifying the argument encoder - Properties

    /// <summary>A string that identifies the argument buffer.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLArgumentEncoderBindings.Label);
        set => SetProperty(ref field, MTLArgumentEncoderBindings.SetLabel, value);
    }

    /// <summary>The device object that created the argument encoder.</summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLArgumentEncoderBindings.Device);
    }
    #endregion

    #region Creating an argument buffer - Methods

    /// <summary>Specifies the position in a buffer where the encoder writes argument data.</summary>
    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetArgumentBuffer, argumentBuffer.NativePtr, offset);
    }

    /// <summary>Specifies the position in a buffer where the encoder writes argument data.</summary>
    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint startOffset, nuint arrayElement)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetArgumentBufferstartOffsetarrayElement, argumentBuffer.NativePtr, startOffset, arrayElement);
    }
    #endregion

    #region Encoding buffers - Methods

    /// <summary>Encodes a reference to a buffer into the argument buffer.</summary>
    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetBuffer, buffer.NativePtr, offset, index);
    }
    #endregion

    #region Encoding textures - Methods

    /// <summary>Encodes a reference to a texture into the argument buffer.</summary>
    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetTexture, texture.NativePtr, index);
    }
    #endregion

    #region Encoding samplers - Methods

    /// <summary>Encodes a sampler into the argument buffer.</summary>
    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetSamplerState, sampler.NativePtr, index);
    }
    #endregion

    #region Encoding pipeline states - Methods

    /// <summary>Encodes a reference to a render pipeline state into the argument buffer.</summary>
    public void SetRenderPipelineState(MTLRenderPipelineState pipeline, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetRenderPipelineState, pipeline.NativePtr, index);
    }

    /// <summary>Encodes a reference to a compute pipeline state into the argument buffer.</summary>
    public void SetComputePipelineState(MTLComputePipelineState pipeline, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetComputePipelineState, pipeline.NativePtr, index);
    }
    #endregion

    #region Encoding inlined constant data - Methods

    /// <summary>Returns a pointer to an inline, constant-data argument within the argument buffer.</summary>
    public nint ConstantData(nuint index)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentEncoderBindings.ConstantData, index);
    }
    #endregion

    #region Encoding indirect command buffers - Methods

    /// <summary>Encodes a reference to an indirect command buffer into the argument buffer.</summary>
    public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIndirectCommandBuffer, indirectCommandBuffer.NativePtr, index);
    }
    #endregion

    #region Encoding acceleration structures - Methods

    /// <summary>Encodes a reference to an acceleration structure into the argument buffer.</summary>
    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetAccelerationStructure, accelerationStructure.NativePtr, index);
    }
    #endregion

    #region Encoding function tables - Methods

    /// <summary>Encodes a reference to a visible-function table into the argument buffer.</summary>
    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetVisibleFunctionTable, visibleFunctionTable.NativePtr, index);
    }

    /// <summary>Encodes a reference to a ray-tracing intersection-function table into the argument buffer.</summary>
    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIntersectionFunctionTable, intersectionFunctionTable.NativePtr, index);
    }
    #endregion

    #region Instance Methods - Methods

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetDepthStencilState, depthStencilState.NativePtr, index);
    }
    #endregion

    public MTLArgumentEncoder NewArgumentEncoder(nuint index)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentEncoderBindings.NewArgumentEncoder, index);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLArgumentEncoderBindings
{
    public static readonly Selector Alignment = "alignment";

    public static readonly Selector ConstantData = "constantDataAtIndex:";

    public static readonly Selector Device = "device";

    public static readonly Selector EncodedLength = "encodedLength";

    public static readonly Selector Label = "label";

    public static readonly Selector NewArgumentEncoder = "newArgumentEncoderForBufferAtIndex:";

    public static readonly Selector SetAccelerationStructure = "setAccelerationStructure:atIndex:";

    public static readonly Selector SetArgumentBuffer = "setArgumentBuffer:offset:";

    public static readonly Selector SetArgumentBufferstartOffsetarrayElement = "setArgumentBuffer:startOffset:arrayElement:";

    public static readonly Selector SetBuffer = "setBuffer:offset:atIndex:";

    public static readonly Selector SetComputePipelineState = "setComputePipelineState:atIndex:";

    public static readonly Selector SetDepthStencilState = "setDepthStencilState:atIndex:";

    public static readonly Selector SetIndirectCommandBuffer = "setIndirectCommandBuffer:atIndex:";

    public static readonly Selector SetIntersectionFunctionTable = "setIntersectionFunctionTable:atIndex:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetRenderPipelineState = "setRenderPipelineState:atIndex:";

    public static readonly Selector SetSamplerState = "setSamplerState:atIndex:";

    public static readonly Selector SetTexture = "setTexture:atIndex:";

    public static readonly Selector SetVisibleFunctionTable = "setVisibleFunctionTable:atIndex:";
}
