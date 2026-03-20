namespace Metal.NET;

public class NSError(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSError>
{
    #region INativeObject
    public static new NSError Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSError New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}
