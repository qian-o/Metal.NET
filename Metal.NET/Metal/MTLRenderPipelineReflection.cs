namespace Metal.NET;

public class MTLRenderPipelineReflection(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLRenderPipelineReflection>
{
    public static MTLRenderPipelineReflection Create(nint nativePtr) => new(nativePtr);

    public MTLRenderPipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineReflectionBindings.Class))
    {
    }

    public NSArray FragmentArguments
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.FragmentArguments);
    }

    public NSArray FragmentBindings
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.FragmentBindings);
    }

    public NSArray MeshBindings
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.MeshBindings);
    }

    public NSArray ObjectBindings
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.ObjectBindings);
    }

    public NSArray TileArguments
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.TileArguments);
    }

    public NSArray TileBindings
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.TileBindings);
    }

    public NSArray VertexArguments
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.VertexArguments);
    }

    public NSArray VertexBindings
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
