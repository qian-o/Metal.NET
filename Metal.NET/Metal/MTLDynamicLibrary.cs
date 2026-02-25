namespace Metal.NET;

public class MTLDynamicLibrary(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLDynamicLibrary>
{
    public static MTLDynamicLibrary Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLDynamicLibrary Null => new(0, false);

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLDynamicLibraryBindings.Device);
    }

    public NSString InstallName
    {
        get => GetProperty(ref field, MTLDynamicLibraryBindings.InstallName);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLDynamicLibraryBindings.Label);
        set => SetProperty(ref field, MTLDynamicLibraryBindings.SetLabel, value);
    }

    public bool SerializeToURL(NSURL url, out NSError error)
    {
        bool result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDynamicLibraryBindings.SerializeToURL, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, false);

        return result;
    }
}

file static class MTLDynamicLibraryBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector InstallName = "installName";

    public static readonly Selector Label = "label";

    public static readonly Selector SerializeToURL = "serializeToURL:error:";

    public static readonly Selector SetLabel = "setLabel:";
}
