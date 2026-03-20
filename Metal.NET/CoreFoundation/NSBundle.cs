namespace Metal.NET;

public class NSBundle(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSBundle>
{
    #region INativeObject
    public static new NSBundle Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSBundle New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}
