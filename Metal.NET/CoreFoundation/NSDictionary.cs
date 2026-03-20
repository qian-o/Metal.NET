namespace Metal.NET;

public class NSDictionary(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSDictionary>
{
    #region INativeObject
    public static new NSDictionary Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSDictionary New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}
