namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSArray pointer.
/// </summary>
public class NSArray : IDisposable
{
    public nint NativePtr { get; }

    public NSArray(nint ptr) => NativePtr = ptr;

    public static implicit operator nint(NSArray a) => a.NativePtr;
    public static implicit operator NSArray(nint ptr) => new(ptr);

    public bool IsNull => NativePtr == 0;

    private static readonly Selector s_count = Selector.Register("count");
    private static readonly Selector s_objectAtIndex = Selector.Register("objectAtIndex:");

    public nuint Count => ObjectiveCRuntime.nuint_objc_msgSend(NativePtr, s_count);

    public nint ObjectAtIndex(nuint index)
        => ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, s_objectAtIndex, (nint)index);

    ~NSArray() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }
}
