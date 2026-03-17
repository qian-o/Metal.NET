namespace Metal.NET;

/// <summary>
/// A dynamically linkable representation of compiled shader code for a specific Metal device object.
/// </summary>
public class MTLDynamicLibrary(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLDynamicLibrary>
{
    #region INativeObject
    public static new MTLDynamicLibrary Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLDynamicLibrary New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying the library - Properties

    /// <summary>
    /// The Metal device object that created the dynamic library.
    /// </summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLDynamicLibraryBindings.Device);
    }

    /// <summary>
    /// A file path for this dynamic library.
    /// </summary>
    public NSString InstallName
    {
        get => GetProperty(ref field, MTLDynamicLibraryBindings.InstallName);
    }

    /// <summary>
    /// A string that identifies the library.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLDynamicLibraryBindings.Label);
        set => SetProperty(ref field, MTLDynamicLibraryBindings.SetLabel, value);
    }
    #endregion

    #region Saving a dynamic library to a file - Methods

    /// <summary>
    /// Writes the contents of the dynamic library to a file.
    /// </summary>
    public bool SerializeToURL(NSURL url, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLDynamicLibraryBindings.SerializeToURL, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }
    #endregion
}

file static class MTLDynamicLibraryBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector InstallName = "installName";

    public static readonly Selector Label = "label";

    public static readonly Selector SerializeToURL = "serializeToURL:error:";

    public static readonly Selector SetLabel = "setLabel:";
}
