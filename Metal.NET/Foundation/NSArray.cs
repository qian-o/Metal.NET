namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSArray pointer.
/// </summary>
public class NSArray : IDisposable
{
    private static readonly Selector selCount = Selector.Register("count");
    private static readonly Selector selObjectAtIndex = Selector.Register("objectAtIndex:");

    public NSArray(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~NSArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint Count => ObjectiveCRuntime.nuint_objc_msgSend(NativePtr, selCount);

    public static implicit operator nint(NSArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator NSArray(nint value)
    {
        return new(value);
    }

    public nint ObjectAtIndex(int index)
    {
        return ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, selObjectAtIndex, index);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}
