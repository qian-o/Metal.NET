namespace Metal.NET;

public class MTLRenderPipelineReflection(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLRenderPipelineReflection>
{
    public static MTLRenderPipelineReflection Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static MTLRenderPipelineReflection Null => Create(0, false);
    public static MTLRenderPipelineReflection Empty => Null;

    public MTLRenderPipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineReflectionBindings.Class), true)
    {
    }

    public MTLArgument[] FragmentArguments
    {
        get => GetArrayProperty<MTLArgument>(MTLRenderPipelineReflectionBindings.FragmentArguments);
    }

    public MTLBinding[] FragmentBindings
    {
        get => GetArrayProperty<MTLBinding>(MTLRenderPipelineReflectionBindings.FragmentBindings);
    }

    public MTLBinding[] MeshBindings
    {
        get => GetArrayProperty<MTLBinding>(MTLRenderPipelineReflectionBindings.MeshBindings);
    }

    public MTLBinding[] ObjectBindings
    {
        get => GetArrayProperty<MTLBinding>(MTLRenderPipelineReflectionBindings.ObjectBindings);
    }

    public MTLArgument[] TileArguments
    {
        get => GetArrayProperty<MTLArgument>(MTLRenderPipelineReflectionBindings.TileArguments);
    }

    public MTLBinding[] TileBindings
    {
        get => GetArrayProperty<MTLBinding>(MTLRenderPipelineReflectionBindings.TileBindings);
    }

    public MTLArgument[] VertexArguments
    {
        get => GetArrayProperty<MTLArgument>(MTLRenderPipelineReflectionBindings.VertexArguments);
    }

    public MTLBinding[] VertexBindings
    {
        get => GetArrayProperty<MTLBinding>(MTLRenderPipelineReflectionBindings.VertexBindings);
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
