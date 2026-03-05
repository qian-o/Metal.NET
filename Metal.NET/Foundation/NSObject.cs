namespace Metal.NET;

public class NSObject(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSObject>
{
    #region INativeObject
    public static NSObject Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSObject New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    protected T GetProperty<T>(ref T? field, Selector selector) where T : NativeObject, INativeObject<T>
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, selector);

        if (field is null || field.NativePtr != nativePtr)
        {
            field = T.New(nativePtr, NativeObjectOwnership.Borrowed);
        }

        return field;
    }

    protected void SetProperty<T>(ref T? field, Selector selector, T value) where T : NativeObject, INativeObject<T>
    {
        ObjectiveC.MsgSend(NativePtr, selector, value.NativePtr);

        field = T.New(value.NativePtr, NativeObjectOwnership.Borrowed);
    }

    protected T[] GetArrayProperty<T>(Selector selector) where T : NativeObject, INativeObject<T>
    {
        nint arrayPtr = ObjectiveC.MsgSendPtr(NativePtr, selector);

        return NSArray.ToArray<T>(arrayPtr);
    }

    protected void SetArrayProperty<T>(Selector selector, T[] value) where T : NativeObject
    {
        nint arrayPtr = NSArray.FromArray(value);

        ObjectiveC.MsgSend(NativePtr, selector, arrayPtr);

        ObjectiveC.Release(arrayPtr);
    }

    protected override void ReleaseNative()
    {
        ObjectiveC.Release(NativePtr);
    }
}
