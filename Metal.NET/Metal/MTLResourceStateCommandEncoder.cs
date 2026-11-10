namespace Metal.NET;

public readonly struct MTLResourceStateCommandEncoder(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLCommandEncoder(MTLResourceStateCommandEncoder value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLResourceStateCommandEncoder value) => new(value.NativePtr);

    public MTLResourceStateCommandEncoder Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLResourceStateCommandEncoderBindings.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLResourceStateCommandEncoderBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.SetLabel, value.NativePtr);
    }

    public void UpdateTextureMappings(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion regions, nint mipLevels, nint slices, nuint numRegions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMappings_Mode_Regions_MipLevels_Slices_NumRegions, texture.NativePtr, (nuint)mode, regions, mipLevels, slices, numRegions);
    }

    public void UpdateTextureMapping(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion region, nuint mipLevel, nuint slice)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMapping_Mode_Region_MipLevel_Slice, texture.NativePtr, (nuint)mode, region, mipLevel, slice);
    }

    public void UpdateTextureMapping(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMapping_Mode_IndirectBuffer_IndirectBufferOffset, texture.NativePtr, (nuint)mode, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void Update(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateFence, fence.NativePtr);
    }

    public void Wait(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.WaitForFence, fence.NativePtr);
    }

    public void MoveTextureMappings(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.MoveTextureMappingsFromTexture_SourceSlice_SourceLevel_SourceOrigin_SourceSize_ToTexture_DestinationSlice_DestinationLevel_DestinationOrigin, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void EndEncoding()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.EndEncoding);
    }

    public void Barrier(MTLStages afterQueueStages, MTLStages beforeStages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.BarrierAfterQueueStages_BeforeStages, (nuint)afterQueueStages, (nuint)beforeStages);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.InsertDebugSignpost, @string.NativePtr);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.PushDebugGroup, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.PopDebugGroup);
    }
}

file static class MTLResourceStateCommandEncoderBindings
{
    public static readonly Selector BarrierAfterQueueStages_BeforeStages = "barrierAfterQueueStages:beforeStages:";

    public static readonly Selector Device = "device";

    public static readonly Selector EndEncoding = "endEncoding";

    public static readonly Selector InsertDebugSignpost = "insertDebugSignpost:";

    public static readonly Selector Label = "label";

    public static readonly Selector MoveTextureMappingsFromTexture_SourceSlice_SourceLevel_SourceOrigin_SourceSize_ToTexture_DestinationSlice_DestinationLevel_DestinationOrigin = "moveTextureMappingsFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector UpdateFence = "updateFence:";

    public static readonly Selector UpdateTextureMapping_Mode_IndirectBuffer_IndirectBufferOffset = "updateTextureMapping:mode:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector UpdateTextureMapping_Mode_Region_MipLevel_Slice = "updateTextureMapping:mode:region:mipLevel:slice:";

    public static readonly Selector UpdateTextureMappings_Mode_Regions_MipLevels_Slices_NumRegions = "updateTextureMappings:mode:regions:mipLevels:slices:numRegions:";

    public static readonly Selector WaitForFence = "waitForFence:";
}
