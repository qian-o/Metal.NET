namespace Metal.NET;

public readonly struct MTLRenderPipelineReflection(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLRenderPipelineReflection value) => new(value.NativePtr);

    public MTLRenderPipelineReflection Retain()
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

    public NSArray<MTLBinding> VertexBindings
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineReflectionBindings.VertexBindings));
    }

    public NSArray<MTLBinding> FragmentBindings
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineReflectionBindings.FragmentBindings));
    }

    public NSArray<MTLBinding> TileBindings
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineReflectionBindings.TileBindings));
    }

    public NSArray<MTLBinding> ObjectBindings
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineReflectionBindings.ObjectBindings));
    }

    public NSArray<MTLBinding> MeshBindings
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineReflectionBindings.MeshBindings));
    }

    /// <summary>
    /// Deprecated: Use vertexBindings instead
    /// </summary>
    [Obsolete("Use vertexBindings instead")]
    public NSArray<MTLArgument> VertexArguments
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineReflectionBindings.VertexArguments));
    }

    /// <summary>
    /// Deprecated: Use fragmentBindings instead
    /// </summary>
    [Obsolete("Use fragmentBindings instead")]
    public NSArray<MTLArgument> FragmentArguments
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineReflectionBindings.FragmentArguments));
    }

    /// <summary>
    /// Deprecated: Use tileBindings instead
    /// </summary>
    [Obsolete("Use tileBindings instead")]
    public NSArray<MTLArgument> TileArguments
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineReflectionBindings.TileArguments));
    }
}

file static class MTLRenderPipelineReflectionBindings
{
    public static readonly Selector FragmentArguments = "fragmentArguments";

    public static readonly Selector FragmentBindings = "fragmentBindings";

    public static readonly Selector MeshBindings = "meshBindings";

    public static readonly Selector ObjectBindings = "objectBindings";

    public static readonly Selector TileArguments = "tileArguments";

    public static readonly Selector TileBindings = "tileBindings";

    public static readonly Selector VertexArguments = "vertexArguments";

    public static readonly Selector VertexBindings = "vertexBindings";
}
