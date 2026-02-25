namespace Metal.NET;

public class MTLRenderPipelineReflection(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLRenderPipelineReflection>
{
    public static MTLRenderPipelineReflection Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLRenderPipelineReflection Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLRenderPipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineReflectionBindings.Class), NativeObjectOwnership.Managed)
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
