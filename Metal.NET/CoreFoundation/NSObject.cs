namespace Metal.NET;

public static class NSObjectExtensions
{
    extension<T>(T @this) where T : NSObject, INativeObject<T>
    {
        public T Retain()
        {
            return T.New(ObjectiveC.Retain(@this.NativePtr), NativeObjectOwnership.Managed);
        }
    }
}

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
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, selector);

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

    protected override void ReleaseNative()
    {
        ObjectiveC.Release(NativePtr);
    }
}
