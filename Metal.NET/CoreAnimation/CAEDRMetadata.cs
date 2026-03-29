namespace Metal.NET;

public class CAEDRMetadata(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<CAEDRMetadata>
{
    #region INativeObject
    public static new CAEDRMetadata Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new CAEDRMetadata New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class CAEDRMetadataBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("CAEDRMetadata");
}
