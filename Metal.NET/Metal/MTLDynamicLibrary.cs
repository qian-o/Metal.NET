namespace Metal.NET;

public readonly struct MTLDynamicLibrary(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibraryBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public NSString? InstallName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibraryBindings.InstallName);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibraryBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDynamicLibraryBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public bool SerializeToURL(NSURL url, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDynamicLibraryBindings.SerializeToURL, url.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return result;
    }
}

file static class MTLDynamicLibraryBindings
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector InstallName = Selector.Register("installName");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SerializeToURL = Selector.Register("serializeToURL:error:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
