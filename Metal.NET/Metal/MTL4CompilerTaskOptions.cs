namespace Metal.NET;

/// <summary>
/// The configuration options that control the behavior of a compilation task for a Metal 4 compiler instance.
/// </summary>
public class MTL4CompilerTaskOptions(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CompilerTaskOptions>
{
    #region INativeObject
    public static new MTL4CompilerTaskOptions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CompilerTaskOptions New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4CompilerTaskOptions() : this(ObjectiveC.AllocInit(MTL4CompilerTaskOptionsBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// An array of archive instances that can potentially accelerate a compilation task.
    /// </summary>
    public MTL4Archive[] LookupArchives
    {
        get => GetArrayProperty<MTL4Archive>(MTL4CompilerTaskOptionsBindings.LookupArchives);
        set => SetArrayProperty(MTL4CompilerTaskOptionsBindings.SetLookupArchives, value);
    }
    #endregion
}

file static class MTL4CompilerTaskOptionsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CompilerTaskOptions");

    public static readonly Selector LookupArchives = "lookupArchives";

    public static readonly Selector SetLookupArchives = "setLookupArchives:";
}
