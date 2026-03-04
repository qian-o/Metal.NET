namespace Metal.NET;

public class MTL4CompilerTaskOptions(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTL4CompilerTaskOptions>
{
    #region INativeObject
    public static MTL4CompilerTaskOptions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4CompilerTaskOptions New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4CompilerTaskOptions() : this(ObjectiveC.AllocInit(MTL4CompilerTaskOptionsBindings.Class), NativeObjectOwnership.Managed)
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
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CompilerTaskOptions");

    public static readonly Selector LookupArchives = "lookupArchives";

    public static readonly Selector SetLookupArchives = "setLookupArchives:";
}
