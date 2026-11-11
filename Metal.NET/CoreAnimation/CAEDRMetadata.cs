namespace Metal.NET;

public readonly struct CAEDRMetadata(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(CAEDRMetadata value) => new(value.NativePtr);

    public CAEDRMetadata Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }
}

file static class CAEDRMetadataBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("CAEDRMetadata");
}
