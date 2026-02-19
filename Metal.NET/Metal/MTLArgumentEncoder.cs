namespace Metal.NET;

public class MTLArgumentEncoder(nint nativePtr) : NativeObject(nativePtr)
{
    public nuint Alignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentEncoderBindings.Alignment);
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderBindings.Device);

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

    public nuint EncodedLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentEncoderBindings.EncodedLength);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderBindings.Label);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public nint ConstantData(nuint index)
    {
        return ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderBindings.ConstantData, index);
    }

    public MTLArgumentEncoder? NewArgumentEncoder(nuint index)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentEncoderBindings.NewArgumentEncoder, index);
        return ptr is not 0 ? new MTLArgumentEncoder(ptr) : null;
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetAccelerationStructure, accelerationStructure.NativePtr, index);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetArgumentBuffer, argumentBuffer.NativePtr, offset);
    }

    public void SetArgumentBuffer(MTLBuffer argumentBuffer, nuint startOffset, nuint arrayElement)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetArgumentBuffer, argumentBuffer.NativePtr, startOffset, arrayElement);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetBuffer, buffer.NativePtr, offset, index);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipeline, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetComputePipelineState, pipeline.NativePtr, index);
    }

    public void SetDepthStencilState(MTLDepthStencilState depthStencilState, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetDepthStencilState, depthStencilState.NativePtr, index);
    }

    public void SetIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIndirectCommandBuffer, indirectCommandBuffer.NativePtr, index);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetIntersectionFunctionTable, intersectionFunctionTable.NativePtr, index);
    }

    public void SetRenderPipelineState(MTLRenderPipelineState pipeline, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetRenderPipelineState, pipeline.NativePtr, index);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetSamplerState, sampler.NativePtr, index);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetTexture, texture.NativePtr, index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentEncoderBindings.SetVisibleFunctionTable, visibleFunctionTable.NativePtr, index);
    }
}

file static class MTLArgumentEncoderBindings
{
    public static readonly Selector Alignment = Selector.Register("alignment");

    public static readonly Selector ConstantData = Selector.Register("constantDataAtIndex:");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector EncodedLength = Selector.Register("encodedLength");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector NewArgumentEncoder = Selector.Register("newArgumentEncoderForBufferAtIndex:");

    public static readonly Selector SetAccelerationStructure = Selector.Register("setAccelerationStructure:atIndex:");

    public static readonly Selector SetArgumentBuffer = Selector.Register("setArgumentBuffer:offset:");

    public static readonly Selector SetBuffer = Selector.Register("setBuffer:offset:atIndex:");

    public static readonly Selector SetComputePipelineState = Selector.Register("setComputePipelineState:atIndex:");

    public static readonly Selector SetDepthStencilState = Selector.Register("setDepthStencilState:atIndex:");

    public static readonly Selector SetIndirectCommandBuffer = Selector.Register("setIndirectCommandBuffer:atIndex:");

    public static readonly Selector SetIntersectionFunctionTable = Selector.Register("setIntersectionFunctionTable:atIndex:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetRenderPipelineState = Selector.Register("setRenderPipelineState:atIndex:");

    public static readonly Selector SetSamplerState = Selector.Register("setSamplerState:atIndex:");

    public static readonly Selector SetTexture = Selector.Register("setTexture:atIndex:");

    public static readonly Selector SetVisibleFunctionTable = Selector.Register("setVisibleFunctionTable:atIndex:");
}
