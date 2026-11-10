namespace Metal.NET;

public readonly struct NSObject(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public NSObject Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }
}

