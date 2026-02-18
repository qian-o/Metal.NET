namespace Metal.NET;

public class MTLDynamicLibrary(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibrarySelector.Device));
    }

    public NSString? InstallName
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibrarySelector.InstallName));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibrarySelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDynamicLibrarySelector.SetLabel, value?.NativePtr ?? 0);
    }

    public bool SerializeToURL(NSURL url, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDynamicLibrarySelector.SerializeToURL, url.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return result;
    }
}

file static class MTLDynamicLibrarySelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector InstallName = Selector.Register("installName");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SerializeToURL = Selector.Register("serializeToURL:error:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
