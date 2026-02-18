namespace Metal.NET;

public partial class MTLRenderPipelineReflection : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPipelineReflection");

    public MTLRenderPipelineReflection(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? FragmentArguments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.FragmentArguments);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSArray? FragmentBindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.FragmentBindings);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSArray? MeshBindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.MeshBindings);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSArray? ObjectBindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.ObjectBindings);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSArray? TileArguments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.TileArguments);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSArray? TileBindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.TileBindings);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSArray? VertexArguments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.VertexArguments);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSArray? VertexBindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.VertexBindings);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTLRenderPipelineReflectionSelector
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
