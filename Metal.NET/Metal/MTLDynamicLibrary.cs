namespace Metal.NET;

public class MTLDynamicLibrary(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLDynamicLibrary>
{
    #region INativeObject
    public static MTLDynamicLibrary Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLDynamicLibrary New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

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
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLDynamicLibraryBindings.SerializeToURL, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

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
