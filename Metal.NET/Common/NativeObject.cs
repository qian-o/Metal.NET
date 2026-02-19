namespace Metal.NET;

/// <summary>
/// Base class for all Objective-C native object wrappers.
/// Every wrapper holds a +1 reference and releases it on dispose.
/// </summary>
public abstract class NativeObject(nint nativePtr) : IDisposable
{
    private bool released;

    protected NativeObject(nint nativePtr, bool retain) : this(nativePtr)
    {
        if (retain)
        {
            ObjectiveCRuntime.Retain(nativePtr);
        }
    }

    ~NativeObject()
    {
        Release();
    }

    /// <summary>
    /// The underlying Objective-C pointer.
    /// </summary>
    public nint NativePtr { get; } = nativePtr;

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    protected T? GetProperty<T>(ref T? field, Selector selector) where T : NativeObject
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, selector);

        if (nativePtr is 0)
        {
            return field = null;
        }

        if (field is null || field.NativePtr != nativePtr)
        {
            field = (T)Activator.CreateInstance(typeof(T), nativePtr, true)!;
        }

        return field;
    }

    protected void SetProperty<T>(ref T? field, Selector selector, T? value) where T : NativeObject
    {
        ObjectiveCRuntime.MsgSend(NativePtr, selector, value?.NativePtr ?? 0);

        field = value;
    }

    private void Release()
    {
        if (released)
        {
            return;
        }

        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }

        released = true;
    }
}
