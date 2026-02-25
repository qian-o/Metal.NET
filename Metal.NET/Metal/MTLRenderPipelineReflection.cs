namespace Metal.NET;

public class MTLRenderPipelineReflection(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLRenderPipelineReflection>
{
    public static MTLRenderPipelineReflection Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLRenderPipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineReflectionBindings.Class), true)
    {
    }

    public NSArray<MTLArgument> FragmentArguments
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.FragmentArguments);
    }

    public NSArray<MTLBinding> FragmentBindings
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.FragmentBindings);
    }

    public NSArray<MTLBinding> MeshBindings
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.MeshBindings);
    }

    public NSArray<MTLBinding> ObjectBindings
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.ObjectBindings);
    }

    public NSArray<MTLArgument> TileArguments
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.TileArguments);
    }

    public NSArray<MTLBinding> TileBindings
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.TileBindings);
    }

    public NSArray<MTLArgument> VertexArguments
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.VertexArguments);
    }

    public NSArray<MTLBinding> VertexBindings
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.VertexBindings);
    }
}

file static class MTLRenderPipelineReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPipelineReflection");

    public static readonly Selector FragmentArguments = "fragmentArguments";

    public static readonly Selector FragmentBindings = "fragmentBindings";

    public static readonly Selector MeshBindings = "meshBindings";

    public static readonly Selector ObjectBindings = "objectBindings";

    public static readonly Selector TileArguments = "tileArguments";

    public static readonly Selector TileBindings = "tileBindings";

    public static readonly Selector VertexArguments = "vertexArguments";

    public static readonly Selector VertexBindings = "vertexBindings";
}
