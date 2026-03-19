namespace Metal.NET;

public partial class NSBundle(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSBundle>
{
    #region INativeObject
    public static new NSBundle Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSBundle New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSBundle() : this(ObjectiveC.AllocInit(NSBundleBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public NSBundle MainBundle
    {
        get => GetProperty(ref field, NSBundleBindings.MainBundle);
    }

    public Bool8 IsLoaded
    {
        get => ObjectiveC.MsgSendBool(NativePtr, NSBundleBindings.IsLoaded);
    }

    public NSURL BundleURL
    {
        get => GetProperty(ref field, NSBundleBindings.BundleURL);
    }

    public NSURL ResourceURL
    {
        get => GetProperty(ref field, NSBundleBindings.ResourceURL);
    }

    public NSURL ExecutableURL
    {
        get => GetProperty(ref field, NSBundleBindings.ExecutableURL);
    }

    public NSURL PrivateFrameworksURL
    {
        get => GetProperty(ref field, NSBundleBindings.PrivateFrameworksURL);
    }

    public NSURL SharedFrameworksURL
    {
        get => GetProperty(ref field, NSBundleBindings.SharedFrameworksURL);
    }

    public NSURL SharedSupportURL
    {
        get => GetProperty(ref field, NSBundleBindings.SharedSupportURL);
    }

    public NSURL BuiltInPlugInsURL
    {
        get => GetProperty(ref field, NSBundleBindings.BuiltInPlugInsURL);
    }

    public NSURL AppStoreReceiptURL
    {
        get => GetProperty(ref field, NSBundleBindings.AppStoreReceiptURL);
    }

    public NSString BundlePath
    {
        get => GetProperty(ref field, NSBundleBindings.BundlePath);
    }

    public NSString ResourcePath
    {
        get => GetProperty(ref field, NSBundleBindings.ResourcePath);
    }

    public NSString ExecutablePath
    {
        get => GetProperty(ref field, NSBundleBindings.ExecutablePath);
    }

    public NSString PrivateFrameworksPath
    {
        get => GetProperty(ref field, NSBundleBindings.PrivateFrameworksPath);
    }

    public NSString SharedFrameworksPath
    {
        get => GetProperty(ref field, NSBundleBindings.SharedFrameworksPath);
    }

    public NSString SharedSupportPath
    {
        get => GetProperty(ref field, NSBundleBindings.SharedSupportPath);
    }

    public NSString BuiltInPlugInsPath
    {
        get => GetProperty(ref field, NSBundleBindings.BuiltInPlugInsPath);
    }

    public NSString BundleIdentifier
    {
        get => GetProperty(ref field, NSBundleBindings.BundleIdentifier);
    }

    public NSDictionary InfoDictionary
    {
        get => GetProperty(ref field, NSBundleBindings.InfoDictionary);
    }

    public NSDictionary LocalizedInfoDictionary
    {
        get => GetProperty(ref field, NSBundleBindings.LocalizedInfoDictionary);
    }

    public NSString DevelopmentLocalization
    {
        get => GetProperty(ref field, NSBundleBindings.DevelopmentLocalization);
    }

    public bool Load()
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSBundleBindings.Load);
    }

    public bool Unload()
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSBundleBindings.Unload);
    }

    public bool PreflightAndReturnError(out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, NSBundleBindings.PreflightAndReturnError, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool LoadAndReturnError(out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, NSBundleBindings.LoadAndReturnError, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public NSURL URLForAuxiliaryExecutable(NSString executableName)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSBundleBindings.URLForAuxiliaryExecutable, executableName.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString PathForAuxiliaryExecutable(NSString executableName)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSBundleBindings.PathForAuxiliaryExecutable, executableName.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSURL URLForResource(NSString name, NSString ext)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSBundleBindings.URLForResource_WithExtension, name.NativePtr, ext.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSURL URLForResource(NSString name, NSString ext, NSString subpath)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSBundleBindings.URLForResource_WithExtension_Subdirectory, name.NativePtr, ext.NativePtr, subpath.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSURL URLForResource(NSString name, NSString ext, NSString subpath, NSString localizationName)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSBundleBindings.URLForResource_WithExtension_Subdirectory_Localization, name.NativePtr, ext.NativePtr, subpath.NativePtr, localizationName.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString PathForResource(NSString name, NSString ext)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSBundleBindings.PathForResource_OfType, name.NativePtr, ext.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString PathForResource(NSString name, NSString ext, NSString subpath, NSString localizationName)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSBundleBindings.PathForResource_OfType_InDirectory_ForLocalization, name.NativePtr, ext.NativePtr, subpath.NativePtr, localizationName.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString LocalizedStringForKey(NSString key, NSString value, NSString tableName)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSBundleBindings.LocalizedStringForKey_Value_Table, key.NativePtr, value.NativePtr, tableName.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSObject ObjectForInfoDictionaryKey(NSString key)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSBundleBindings.ObjectForInfoDictionaryKey, key.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public double PreservationPriorityForTag(NSString tag)
    {
        return ObjectiveC.MsgSendDouble(NativePtr, NSBundleBindings.PreservationPriorityForTag, tag.NativePtr);
    }

    public static nint BundleWithPath(NSString path)
    {
        return ObjectiveC.MsgSendNInt(NSBundleBindings.Class, NSBundleBindings.BundleWithPath, path.NativePtr);
    }

    public static nint BundleWithURL(NSURL url)
    {
        return ObjectiveC.MsgSendNInt(NSBundleBindings.Class, NSBundleBindings.BundleWithURL, url.NativePtr);
    }

    public static NSBundle BundleWithIdentifier(NSString identifier)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSBundleBindings.Class, NSBundleBindings.BundleWithIdentifier, identifier.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSURL URLForResource(NSString name, NSString ext, NSString subpath, NSURL bundleURL)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSBundleBindings.Class, NSBundleBindings.URLForResource_WithExtension_Subdirectory_InBundleWithURL, name.NativePtr, ext.NativePtr, subpath.NativePtr, bundleURL.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSString PathForResource(NSString name, NSString ext, NSString bundlePath)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSBundleBindings.Class, NSBundleBindings.PathForResource_OfType_InDirectory, name.NativePtr, ext.NativePtr, bundlePath.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSBundle InitWithPath(NSString path)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSBundleBindings.Class), NSBundleBindings.InitWithPath, path.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSBundle InitWithURL(NSURL url)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSBundleBindings.Class), NSBundleBindings.InitWithURL, url.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }
}

file static class NSBundleBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSBundle");

    public static readonly Selector AppStoreReceiptURL = "appStoreReceiptURL";

    public static readonly Selector BuiltInPlugInsPath = "builtInPlugInsPath";

    public static readonly Selector BuiltInPlugInsURL = "builtInPlugInsURL";

    public static readonly Selector BundleIdentifier = "bundleIdentifier";

    public static readonly Selector BundlePath = "bundlePath";

    public static readonly Selector BundleURL = "bundleURL";

    public static readonly Selector BundleWithIdentifier = "bundleWithIdentifier:";

    public static readonly Selector BundleWithPath = "bundleWithPath:";

    public static readonly Selector BundleWithURL = "bundleWithURL:";

    public static readonly Selector DevelopmentLocalization = "developmentLocalization";

    public static readonly Selector ExecutablePath = "executablePath";

    public static readonly Selector ExecutableURL = "executableURL";

    public static readonly Selector InfoDictionary = "infoDictionary";

    public static readonly Selector InitWithPath = "initWithPath:";

    public static readonly Selector InitWithURL = "initWithURL:";

    public static readonly Selector IsLoaded = "isLoaded";

    public static readonly Selector Load = "load";

    public static readonly Selector LoadAndReturnError = "loadAndReturnError:";

    public static readonly Selector LocalizedInfoDictionary = "localizedInfoDictionary";

    public static readonly Selector LocalizedStringForKey_Value_Table = "localizedStringForKey:value:table:";

    public static readonly Selector MainBundle = "mainBundle";

    public static readonly Selector ObjectForInfoDictionaryKey = "objectForInfoDictionaryKey:";

    public static readonly Selector PathForAuxiliaryExecutable = "pathForAuxiliaryExecutable:";

    public static readonly Selector PathForResource_OfType = "pathForResource:ofType:";

    public static readonly Selector PathForResource_OfType_InDirectory = "pathForResource:ofType:inDirectory:";

    public static readonly Selector PathForResource_OfType_InDirectory_ForLocalization = "pathForResource:ofType:inDirectory:forLocalization:";

    public static readonly Selector PreflightAndReturnError = "preflightAndReturnError:";

    public static readonly Selector PreservationPriorityForTag = "preservationPriorityForTag:";

    public static readonly Selector PrivateFrameworksPath = "privateFrameworksPath";

    public static readonly Selector PrivateFrameworksURL = "privateFrameworksURL";

    public static readonly Selector ResourcePath = "resourcePath";

    public static readonly Selector ResourceURL = "resourceURL";

    public static readonly Selector SharedFrameworksPath = "sharedFrameworksPath";

    public static readonly Selector SharedFrameworksURL = "sharedFrameworksURL";

    public static readonly Selector SharedSupportPath = "sharedSupportPath";

    public static readonly Selector SharedSupportURL = "sharedSupportURL";

    public static readonly Selector Unload = "unload";

    public static readonly Selector URLForAuxiliaryExecutable = "URLForAuxiliaryExecutable:";

    public static readonly Selector URLForResource_WithExtension = "URLForResource:withExtension:";

    public static readonly Selector URLForResource_WithExtension_Subdirectory = "URLForResource:withExtension:subdirectory:";

    public static readonly Selector URLForResource_WithExtension_Subdirectory_InBundleWithURL = "URLForResource:withExtension:subdirectory:inBundleWithURL:";

    public static readonly Selector URLForResource_WithExtension_Subdirectory_Localization = "URLForResource:withExtension:subdirectory:localization:";
}
