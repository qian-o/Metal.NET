namespace Metal.NET;

public partial class MTLDynamicLibrary(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLDynamicLibrary>
{
    #region INativeObject
    public static new MTLDynamicLibrary Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLDynamicLibrary New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTLDynamicLibraryBindings
{
}
