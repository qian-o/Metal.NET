namespace Metal.NET;

public class MTLDynamicLibrary(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get => GetProperty<MTLDevice>(ref field, MTLDynamicLibraryBindings.Device);
    }

    public NSString? InstallName
    {
        get => GetProperty<NSString>(ref field, MTLDynamicLibraryBindings.InstallName);
    }

    public NSString? Label
    {
        get => GetProperty<NSString>(ref field, MTLDynamicLibraryBindings.Label);
        set => SetProperty(ref field, MTLDynamicLibraryBindings.SetLabel, value);
    }

    public bool SerializeToURL(NSURL url, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDynamicLibraryBindings.SerializeToURL, url.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
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
