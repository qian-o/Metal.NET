namespace Metal.NET;

public class MTLRenderPipelineReflection(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRenderPipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineReflectionSelector.Class))
    {
    }

    public NSArray? FragmentArguments
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.FragmentArguments));
    }

    public NSArray? FragmentBindings
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.FragmentBindings));
    }

    public NSArray? MeshBindings
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.MeshBindings));
    }

    public NSArray? ObjectBindings
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.ObjectBindings));
    }

    public NSArray? TileArguments
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.TileArguments));
    }

    public NSArray? TileBindings
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.TileBindings));
    }

    public NSArray? VertexArguments
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.VertexArguments));
    }

    public NSArray? VertexBindings
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionSelector.VertexBindings));
    }
}

file static class MTLRenderPipelineReflectionSelector
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
