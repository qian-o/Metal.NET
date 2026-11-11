namespace Metal.NET;

public readonly struct MTLTilePipelineColorAttachmentDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLTilePipelineColorAttachmentDescriptor value) => new(value.NativePtr);

    public MTLTilePipelineColorAttachmentDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }
}

file static class MTLTilePipelineColorAttachmentDescriptorBindings
{
}
