namespace Metal.NET;

public class MTLDynamicLibrary : IDisposable
{
    public MTLDynamicLibrary(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLDynamicLibrary()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLDynamicLibrary value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLDynamicLibrary(nint value)
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

    public Bool8 SerializeToURL(NSURL url, out NSError? error)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibrarySelector.SerializeToURLError, url.NativePtr, out nint errorPtr) is not 0;

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLDynamicLibrarySelector.SetLabel, label.NativePtr);
    }

}

file class MTLDynamicLibrarySelector
{
    public static readonly Selector SerializeToURLError = Selector.Register("serializeToURL:error:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
