namespace Metal.NET;

public class MTLDynamicLibrary(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibraryBindings.Device);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLDevice(ptr);
            }

            return field;
        }
    }

    public NSString? InstallName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibraryBindings.InstallName);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDynamicLibraryBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLDynamicLibraryBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
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
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector InstallName = Selector.Register("installName");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SerializeToURL = Selector.Register("serializeToURL:error:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
