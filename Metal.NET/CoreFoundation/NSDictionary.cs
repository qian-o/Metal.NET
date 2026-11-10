namespace Metal.NET;

public readonly struct NSDictionary(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(NSDictionary value) => new(value.NativePtr);

    public NSDictionary Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }
}
