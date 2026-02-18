namespace Metal.NET;

public class MTLFunctionStitchingAttributeAlwaysInline : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingAttributeAlwaysInline");

    public MTLFunctionStitchingAttributeAlwaysInline(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLFunctionStitchingAttributeAlwaysInline() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLFunctionStitchingAttributeAlwaysInline()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunctionStitchingAttributeAlwaysInline value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionStitchingAttributeAlwaysInline(nint value)
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

file class MTLFunctionStitchingAttributeAlwaysInlineSelector
{
}
