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

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibrarySelector.Device));
    }

    public NSString InstallName
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibrarySelector.InstallName));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibrarySelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDynamicLibrarySelector.SetLabel, value.NativePtr);
    }

    public Bool8 SerializeToURL(NSURL url, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDynamicLibrarySelector.SerializeToURLError, url.NativePtr, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

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
}

file class MTLDynamicLibrarySelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector InstallName = Selector.Register("installName");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SerializeToURLError = Selector.Register("serializeToURL:error:");
}
