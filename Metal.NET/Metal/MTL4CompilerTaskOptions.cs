namespace Metal.NET;

public class MTL4CompilerTaskOptions(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4CompilerTaskOptions>
{
    public static MTL4CompilerTaskOptions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4CompilerTaskOptions Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTL4CompilerTaskOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CompilerTaskOptionsBindings.Class), NativeObjectOwnership.Managed)
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
