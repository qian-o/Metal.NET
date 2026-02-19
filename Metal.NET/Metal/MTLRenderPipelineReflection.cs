namespace Metal.NET;

public readonly struct MTLRenderPipelineReflection(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLRenderPipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineReflectionBindings.Class))
    {
    }

    public NSArray? FragmentArguments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.FragmentArguments);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }

    public NSArray? FragmentBindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.FragmentBindings);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }

    public NSArray? MeshBindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.MeshBindings);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }

    public NSArray? ObjectBindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.ObjectBindings);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }

    public NSArray? TileArguments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.TileArguments);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }

    public NSArray? TileBindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.TileBindings);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }

    public NSArray? VertexArguments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.VertexArguments);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }

    public NSArray? VertexBindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.VertexBindings);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }
}

file static class MTLRenderPipelineReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPipelineReflection");

    public static readonly Selector FragmentArguments = Selector.Register("fragmentArguments");

    public static readonly Selector FragmentBindings = Selector.Register("fragmentBindings");

    public static readonly Selector MeshBindings = Selector.Register("meshBindings");

    public static readonly Selector ObjectBindings = Selector.Register("objectBindings");

    public static readonly Selector TileArguments = Selector.Register("tileArguments");

    public static readonly Selector TileBindings = Selector.Register("tileBindings");

    public static readonly Selector VertexArguments = Selector.Register("vertexArguments");

    public static readonly Selector VertexBindings = Selector.Register("vertexBindings");
}
