namespace Metal.NET;

public class MTL4CommitOptions : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommitOptions");

    public MTL4CommitOptions(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTL4CommitOptions() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTL4CommitOptions()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4CommitOptions value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CommitOptions(nint value)
    {
        return new(value);
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

file class MTL4CommitOptionsSelector
{
}
