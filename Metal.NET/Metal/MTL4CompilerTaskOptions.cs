namespace Metal.NET;

public class MTL4CompilerTaskOptions(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4CompilerTaskOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CompilerTaskOptionsBindings.Class))
    {
    }

    public NSArray? LookupArchives
    {
        get => GetProperty(ref field, MTL4CompilerTaskOptionsBindings.LookupArchives);
        set => SetProperty(ref field, MTL4CompilerTaskOptionsBindings.SetLookupArchives, value);
    }
}

file static class MTL4CompilerTaskOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CompilerTaskOptions");

    public static readonly Selector LookupArchives = "lookupArchives";

    public static readonly Selector SetLookupArchives = "setLookupArchives:";
}
