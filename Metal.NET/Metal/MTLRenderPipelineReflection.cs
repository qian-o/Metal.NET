namespace Metal.NET;

public class MTLRenderPipelineReflection : IDisposable
{
    public MTLRenderPipelineReflection(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRenderPipelineReflection()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray FragmentArguments => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.FragmentArguments));

    public NSArray FragmentBindings => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.FragmentBindings));

    public NSArray MeshBindings => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.MeshBindings));

    public NSArray ObjectBindings => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.ObjectBindings));

    public NSArray TileArguments => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.TileArguments));

    public NSArray TileBindings => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.TileBindings));

    public NSArray VertexArguments => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.VertexArguments));

    public NSArray VertexBindings => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.VertexBindings));

    public static implicit operator nint(MTLRenderPipelineReflection value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPipelineReflection(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

}

file class MTLRenderPipelineReflectionSelector
{
    public static readonly Selector FragmentArguments = Selector.Register("fragmentArguments");

    public static readonly Selector FragmentBindings = Selector.Register("fragmentBindings");

    public static readonly Selector MeshBindings = Selector.Register("meshBindings");

    public static readonly Selector ObjectBindings = Selector.Register("objectBindings");

    public static readonly Selector TileArguments = Selector.Register("tileArguments");

    public static readonly Selector TileBindings = Selector.Register("tileBindings");

    public static readonly Selector VertexArguments = Selector.Register("vertexArguments");

    public static readonly Selector VertexBindings = Selector.Register("vertexBindings");
}
