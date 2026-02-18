namespace Metal.NET;

public partial class MTLDynamicLibrary : NativeObject
{
    public MTLDynamicLibrary(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibrarySelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? InstallName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibrarySelector.InstallName);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibrarySelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDynamicLibrarySelector.SetLabel, value?.NativePtr ?? 0);
    }

    public bool SerializeToURL(NSURL url, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDynamicLibrarySelector.SerializeToURL, url.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new(errorPtr) : null;
        return result;
    }
}

file static class MTLDynamicLibrarySelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector InstallName = Selector.Register("installName");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SerializeToURL = Selector.Register("serializeToURL:::");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
