namespace Metal.NET;

public class MTLFunctionReflection : IDisposable
{
    public MTLFunctionReflection(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFunctionReflection()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray Bindings
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionReflectionSelector.Bindings));
    }

    public static implicit operator nint(MTLFunctionReflection value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionReflection(nint value)
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

file class MTLFunctionReflectionSelector
{
    public static readonly Selector Bindings = Selector.Register("bindings");
}
