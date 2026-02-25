namespace Metal.NET;

public class MTL4CompilerTaskOptions(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4CompilerTaskOptions>
{
    public static MTL4CompilerTaskOptions Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static MTL4CompilerTaskOptions Null => Create(0, false);
    public static MTL4CompilerTaskOptions Empty => Null;

    public MTL4CompilerTaskOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CompilerTaskOptionsBindings.Class), true)
    {
    }

    public MTL4Archive[] LookupArchives
    {
        get => GetArrayProperty<MTL4Archive>(MTL4CompilerTaskOptionsBindings.LookupArchives);
        set => SetArrayProperty(MTL4CompilerTaskOptionsBindings.SetLookupArchives, value);
    }
}

file static class MTL4CompilerTaskOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CompilerTaskOptions");

    public static readonly Selector LookupArchives = "lookupArchives";

    public static readonly Selector SetLookupArchives = "setLookupArchives:";
}
