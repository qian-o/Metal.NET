namespace Metal.NET;

public readonly struct MTLTextureViewPool(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLResourceViewPool(MTLTextureViewPool value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLTextureViewPool value) => new(value.NativePtr);

    public MTLTextureViewPool() : this(ObjectiveC.AllocInit(MTLTextureViewPoolBindings.Class))
    {
    }

    public MTLTextureViewPool Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLResourceID BaseResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.BaseResourceID);
    }

    public nuint ResourceViewCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureViewPoolBindings.ResourceViewCount);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTextureViewPoolBindings.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTextureViewPoolBindings.Label));
    }

    public MTLResourceID SetTextureView(MTLTexture texture, nuint index)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.SetTextureView_AtIndex, texture.NativePtr, index);
    }

    public MTLResourceID SetTextureView(MTLTexture texture, MTLTextureViewDescriptor descriptor, nuint index)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.SetTextureView_Descriptor_AtIndex, texture.NativePtr, descriptor.NativePtr, index);
    }

    public MTLResourceID SetTextureView(MTLBuffer buffer, MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow, nuint index)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.SetTextureViewFromBuffer_Descriptor_Offset_BytesPerRow_AtIndex, buffer.NativePtr, descriptor.NativePtr, offset, bytesPerRow, index);
    }

    public MTLResourceID CopyResourceViewsFromPool(MTLResourceViewPool sourcePool, NSRange sourceRange, nuint destinationIndex)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.CopyResourceViewsFromPool_SourceRange_DestinationIndex, sourcePool.NativePtr, sourceRange, destinationIndex);
    }
}

file static class MTLTextureViewPoolBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTextureViewPool");

    public static readonly Selector BaseResourceID = "baseResourceID";

    public static readonly Selector CopyResourceViewsFromPool_SourceRange_DestinationIndex = "copyResourceViewsFromPool:sourceRange:destinationIndex:";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector ResourceViewCount = "resourceViewCount";

    public static readonly Selector SetTextureView_AtIndex = "setTextureView:atIndex:";

    public static readonly Selector SetTextureView_Descriptor_AtIndex = "setTextureView:descriptor:atIndex:";

    public static readonly Selector SetTextureViewFromBuffer_Descriptor_Offset_BytesPerRow_AtIndex = "setTextureViewFromBuffer:descriptor:offset:bytesPerRow:atIndex:";
}
