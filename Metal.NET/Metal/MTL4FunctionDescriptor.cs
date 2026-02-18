namespace Metal.NET;

public class MTL4FunctionDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4FunctionDescriptor");

    public MTL4FunctionDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTL4FunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTL4FunctionDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4FunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4FunctionDescriptor(nint value)
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

file class MTL4FunctionDescriptorSelector
{
}
