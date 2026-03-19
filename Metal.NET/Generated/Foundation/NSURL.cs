namespace Metal.NET;

public partial class NSURL(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSURL>
{
    #region INativeObject
    public static new NSURL Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSURL New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSURL() : this(ObjectiveC.AllocInit(NSURLBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public NSData DataRepresentation
    {
        get => GetProperty(ref field, NSURLBindings.DataRepresentation);
    }

    public NSString AbsoluteString
    {
        get => GetProperty(ref field, NSURLBindings.AbsoluteString);
    }

    public NSString RelativeString
    {
        get => GetProperty(ref field, NSURLBindings.RelativeString);
    }

    public NSURL BaseURL
    {
        get => GetProperty(ref field, NSURLBindings.BaseURL);
    }

    public NSURL AbsoluteURL
    {
        get => GetProperty(ref field, NSURLBindings.AbsoluteURL);
    }

    public NSString Scheme
    {
        get => GetProperty(ref field, NSURLBindings.Scheme);
    }

    public NSString ResourceSpecifier
    {
        get => GetProperty(ref field, NSURLBindings.ResourceSpecifier);
    }

    public NSString Host
    {
        get => GetProperty(ref field, NSURLBindings.Host);
    }

    public NSNumber Port
    {
        get => GetProperty(ref field, NSURLBindings.Port);
    }

    public NSString User
    {
        get => GetProperty(ref field, NSURLBindings.User);
    }

    public NSString Password
    {
        get => GetProperty(ref field, NSURLBindings.Password);
    }

    public NSString Path
    {
        get => GetProperty(ref field, NSURLBindings.Path);
    }

    public NSString Fragment
    {
        get => GetProperty(ref field, NSURLBindings.Fragment);
    }

    public NSString ParameterString
    {
        get => GetProperty(ref field, NSURLBindings.ParameterString);
    }

    public NSString Query
    {
        get => GetProperty(ref field, NSURLBindings.Query);
    }

    public NSString RelativePath
    {
        get => GetProperty(ref field, NSURLBindings.RelativePath);
    }

    public Bool8 HasDirectoryPath
    {
        get => ObjectiveC.MsgSendBool(NativePtr, NSURLBindings.HasDirectoryPath);
    }

    public Bool8 IsFileURL
    {
        get => ObjectiveC.MsgSendBool(NativePtr, NSURLBindings.IsFileURL);
    }

    public NSURL StandardizedURL
    {
        get => GetProperty(ref field, NSURLBindings.StandardizedURL);
    }

    public NSURL FilePathURL
    {
        get => GetProperty(ref field, NSURLBindings.FilePathURL);
    }

    public NSString LastPathComponent
    {
        get => GetProperty(ref field, NSURLBindings.LastPathComponent);
    }

    public NSString PathExtension
    {
        get => GetProperty(ref field, NSURLBindings.PathExtension);
    }

    public NSURL URLByDeletingLastPathComponent
    {
        get => GetProperty(ref field, NSURLBindings.URLByDeletingLastPathComponent);
    }

    public NSURL URLByDeletingPathExtension
    {
        get => GetProperty(ref field, NSURLBindings.URLByDeletingPathExtension);
    }

    public NSURL URLByStandardizingPath
    {
        get => GetProperty(ref field, NSURLBindings.URLByStandardizingPath);
    }

    public NSURL URLByResolvingSymlinksInPath
    {
        get => GetProperty(ref field, NSURLBindings.URLByResolvingSymlinksInPath);
    }

    public bool GetFileSystemRepresentation(nint buffer, nuint maxBufferLength)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSURLBindings.GetFileSystemRepresentation_MaxLength, buffer, maxBufferLength);
    }

    public bool IsFileReferenceURL()
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSURLBindings.IsFileReferenceURL);
    }

    public NSURL FileReferenceURL()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSURLBindings.FileReferenceURL);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void RemoveAllCachedResourceValues()
    {
        ObjectiveC.MsgSend(NativePtr, NSURLBindings.RemoveAllCachedResourceValues);
    }

    public bool StartAccessingSecurityScopedResource()
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSURLBindings.StartAccessingSecurityScopedResource);
    }

    public void StopAccessingSecurityScopedResource()
    {
        ObjectiveC.MsgSend(NativePtr, NSURLBindings.StopAccessingSecurityScopedResource);
    }

    public bool CheckPromisedItemIsReachableAndReturnError(out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, NSURLBindings.CheckPromisedItemIsReachableAndReturnError, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public NSURL URLByAppendingPathComponent(NSString pathComponent)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSURLBindings.URLByAppendingPathComponent, pathComponent.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSURL URLByAppendingPathComponent(NSString pathComponent, bool isDirectory)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSURLBindings.URLByAppendingPathComponent_IsDirectory, pathComponent.NativePtr, isDirectory);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSURL URLByAppendingPathExtension(NSString pathExtension)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSURLBindings.URLByAppendingPathExtension, pathExtension.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool CheckResourceIsReachableAndReturnError(out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, NSURLBindings.CheckResourceIsReachableAndReturnError, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public NSData ResourceDataUsingCache(bool shouldUseCache)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSURLBindings.ResourceDataUsingCache, shouldUseCache);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void LoadResourceDataNotifyingClient(NSObject client, bool shouldUseCache)
    {
        ObjectiveC.MsgSend(NativePtr, NSURLBindings.LoadResourceDataNotifyingClient_UsingCache, client.NativePtr, shouldUseCache);
    }

    public NSObject PropertyForKey(NSString propertyKey)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSURLBindings.PropertyForKey, propertyKey.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool SetResourceData(NSData data)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSURLBindings.SetResourceData, data.NativePtr);
    }

    public bool SetProperty(NSObject property, NSString propertyKey)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSURLBindings.SetProperty_ForKey, property.NativePtr, propertyKey.NativePtr);
    }

    public static NSURL FileURLWithPath(NSString path, bool isDir, NSURL baseURL)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSURLBindings.Class, NSURLBindings.FileURLWithPath_IsDirectory_RelativeToURL, path.NativePtr, isDir, baseURL.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSURL FileURLWithPath(NSString path, NSURL baseURL)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSURLBindings.Class, NSURLBindings.FileURLWithPath_RelativeToURL, path.NativePtr, baseURL.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSURL FileURLWithPath(NSString path, bool isDir)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSURLBindings.Class, NSURLBindings.FileURLWithPath_IsDirectory, path.NativePtr, isDir);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSURL FileURLWithPath(NSString path)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSURLBindings.Class, NSURLBindings.FileURLWithPath, path.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSURL FileURLWithFileSystemRepresentation(nint path, bool isDir, NSURL baseURL)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSURLBindings.Class, NSURLBindings.FileURLWithFileSystemRepresentation_IsDirectory_RelativeToURL, path, isDir, baseURL.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static nint URLWithString(NSString uRLString)
    {
        return ObjectiveC.MsgSendNInt(NSURLBindings.Class, NSURLBindings.URLWithString, uRLString.NativePtr);
    }

    public static nint URLWithString(NSString uRLString, NSURL baseURL)
    {
        return ObjectiveC.MsgSendNInt(NSURLBindings.Class, NSURLBindings.URLWithString_RelativeToURL, uRLString.NativePtr, baseURL.NativePtr);
    }

    public static nint URLWithString(NSString uRLString, bool encodingInvalidCharacters)
    {
        return ObjectiveC.MsgSendNInt(NSURLBindings.Class, NSURLBindings.URLWithString_EncodingInvalidCharacters, uRLString.NativePtr, encodingInvalidCharacters);
    }

    public static NSURL URLWithDataRepresentation(NSData data, NSURL baseURL)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSURLBindings.Class, NSURLBindings.URLWithDataRepresentation_RelativeToURL, data.NativePtr, baseURL.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSURL AbsoluteURLWithDataRepresentation(NSData data, NSURL baseURL)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSURLBindings.Class, NSURLBindings.AbsoluteURLWithDataRepresentation_RelativeToURL, data.NativePtr, baseURL.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSData BookmarkDataWithContentsOfURL(NSURL bookmarkFileURL, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSURLBindings.Class, NSURLBindings.BookmarkDataWithContentsOfURL_Error, bookmarkFileURL.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSURL FileURLWithPathComponents(NSString[] components)
    {
        nint pComponents = NSArray.FromArray(components);

        nint nativePtr = ObjectiveC.MsgSendNInt(NSURLBindings.Class, NSURLBindings.FileURLWithPathComponents, pComponents);

        ObjectiveC.Release(pComponents);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSURL InitWithScheme_Host_Path(NSString scheme, NSString host, NSString path)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSURLBindings.Class), NSURLBindings.InitWithScheme_Host_Path, scheme.NativePtr, host.NativePtr, path.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSURL InitFileURLWithPath_IsDirectory_RelativeToURL(NSString path, bool isDir, NSURL baseURL)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSURLBindings.Class), NSURLBindings.InitFileURLWithPath_IsDirectory_RelativeToURL, path.NativePtr, isDir, baseURL.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSURL InitFileURLWithPath_RelativeToURL(NSString path, NSURL baseURL)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSURLBindings.Class), NSURLBindings.InitFileURLWithPath_RelativeToURL, path.NativePtr, baseURL.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSURL InitFileURLWithPath_IsDirectory(NSString path, bool isDir)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSURLBindings.Class), NSURLBindings.InitFileURLWithPath_IsDirectory, path.NativePtr, isDir);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSURL InitFileURLWithPath(NSString path)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSURLBindings.Class), NSURLBindings.InitFileURLWithPath, path.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSURL InitFileURLWithFileSystemRepresentation_IsDirectory_RelativeToURL(nint path, bool isDir, NSURL baseURL)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSURLBindings.Class), NSURLBindings.InitFileURLWithFileSystemRepresentation_IsDirectory_RelativeToURL, path, isDir, baseURL.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSURL InitWithString(NSString uRLString)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSURLBindings.Class), NSURLBindings.InitWithString, uRLString.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSURL InitWithString_RelativeToURL(NSString uRLString, NSURL baseURL)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSURLBindings.Class), NSURLBindings.InitWithString_RelativeToURL, uRLString.NativePtr, baseURL.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSURL InitWithString_EncodingInvalidCharacters(NSString uRLString, bool encodingInvalidCharacters)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSURLBindings.Class), NSURLBindings.InitWithString_EncodingInvalidCharacters, uRLString.NativePtr, encodingInvalidCharacters);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSURL InitWithDataRepresentation_RelativeToURL(NSData data, NSURL baseURL)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSURLBindings.Class), NSURLBindings.InitWithDataRepresentation_RelativeToURL, data.NativePtr, baseURL.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSURL InitAbsoluteURLWithDataRepresentation_RelativeToURL(NSData data, NSURL baseURL)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSURLBindings.Class), NSURLBindings.InitAbsoluteURLWithDataRepresentation_RelativeToURL, data.NativePtr, baseURL.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }
}

file static class NSURLBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSURL");

    public static readonly Selector AbsoluteString = "absoluteString";

    public static readonly Selector AbsoluteURL = "absoluteURL";

    public static readonly Selector AbsoluteURLWithDataRepresentation_RelativeToURL = "absoluteURLWithDataRepresentation:relativeToURL:";

    public static readonly Selector BaseURL = "baseURL";

    public static readonly Selector BookmarkDataWithContentsOfURL_Error = "bookmarkDataWithContentsOfURL:error:";

    public static readonly Selector CheckPromisedItemIsReachableAndReturnError = "checkPromisedItemIsReachableAndReturnError:";

    public static readonly Selector CheckResourceIsReachableAndReturnError = "checkResourceIsReachableAndReturnError:";

    public static readonly Selector DataRepresentation = "dataRepresentation";

    public static readonly Selector FilePathURL = "filePathURL";

    public static readonly Selector FileReferenceURL = "fileReferenceURL";

    public static readonly Selector FileURLWithFileSystemRepresentation_IsDirectory_RelativeToURL = "fileURLWithFileSystemRepresentation:isDirectory:relativeToURL:";

    public static readonly Selector FileURLWithPath = "fileURLWithPath:";

    public static readonly Selector FileURLWithPath_IsDirectory = "fileURLWithPath:isDirectory:";

    public static readonly Selector FileURLWithPath_IsDirectory_RelativeToURL = "fileURLWithPath:isDirectory:relativeToURL:";

    public static readonly Selector FileURLWithPath_RelativeToURL = "fileURLWithPath:relativeToURL:";

    public static readonly Selector FileURLWithPathComponents = "fileURLWithPathComponents:";

    public static readonly Selector Fragment = "fragment";

    public static readonly Selector GetFileSystemRepresentation_MaxLength = "getFileSystemRepresentation:maxLength:";

    public static readonly Selector HasDirectoryPath = "hasDirectoryPath";

    public static readonly Selector Host = "host";

    public static readonly Selector InitAbsoluteURLWithDataRepresentation_RelativeToURL = "initAbsoluteURLWithDataRepresentation:relativeToURL:";

    public static readonly Selector InitFileURLWithFileSystemRepresentation_IsDirectory_RelativeToURL = "initFileURLWithFileSystemRepresentation:isDirectory:relativeToURL:";

    public static readonly Selector InitFileURLWithPath = "initFileURLWithPath:";

    public static readonly Selector InitFileURLWithPath_IsDirectory = "initFileURLWithPath:isDirectory:";

    public static readonly Selector InitFileURLWithPath_IsDirectory_RelativeToURL = "initFileURLWithPath:isDirectory:relativeToURL:";

    public static readonly Selector InitFileURLWithPath_RelativeToURL = "initFileURLWithPath:relativeToURL:";

    public static readonly Selector InitWithDataRepresentation_RelativeToURL = "initWithDataRepresentation:relativeToURL:";

    public static readonly Selector InitWithScheme_Host_Path = "initWithScheme:host:path:";

    public static readonly Selector InitWithString = "initWithString:";

    public static readonly Selector InitWithString_EncodingInvalidCharacters = "initWithString:encodingInvalidCharacters:";

    public static readonly Selector InitWithString_RelativeToURL = "initWithString:relativeToURL:";

    public static readonly Selector IsFileReferenceURL = "isFileReferenceURL";

    public static readonly Selector IsFileURL = "isFileURL";

    public static readonly Selector LastPathComponent = "lastPathComponent";

    public static readonly Selector LoadResourceDataNotifyingClient_UsingCache = "loadResourceDataNotifyingClient:usingCache:";

    public static readonly Selector ParameterString = "parameterString";

    public static readonly Selector Password = "password";

    public static readonly Selector Path = "path";

    public static readonly Selector PathExtension = "pathExtension";

    public static readonly Selector Port = "port";

    public static readonly Selector PropertyForKey = "propertyForKey:";

    public static readonly Selector Query = "query";

    public static readonly Selector RelativePath = "relativePath";

    public static readonly Selector RelativeString = "relativeString";

    public static readonly Selector RemoveAllCachedResourceValues = "removeAllCachedResourceValues";

    public static readonly Selector ResourceDataUsingCache = "resourceDataUsingCache:";

    public static readonly Selector ResourceSpecifier = "resourceSpecifier";

    public static readonly Selector Scheme = "scheme";

    public static readonly Selector SetProperty_ForKey = "setProperty:forKey:";

    public static readonly Selector SetResourceData = "setResourceData:";

    public static readonly Selector StandardizedURL = "standardizedURL";

    public static readonly Selector StartAccessingSecurityScopedResource = "startAccessingSecurityScopedResource";

    public static readonly Selector StopAccessingSecurityScopedResource = "stopAccessingSecurityScopedResource";

    public static readonly Selector URLByAppendingPathComponent = "URLByAppendingPathComponent:";

    public static readonly Selector URLByAppendingPathComponent_IsDirectory = "URLByAppendingPathComponent:isDirectory:";

    public static readonly Selector URLByAppendingPathExtension = "URLByAppendingPathExtension:";

    public static readonly Selector URLByDeletingLastPathComponent = "URLByDeletingLastPathComponent";

    public static readonly Selector URLByDeletingPathExtension = "URLByDeletingPathExtension";

    public static readonly Selector URLByResolvingSymlinksInPath = "URLByResolvingSymlinksInPath";

    public static readonly Selector URLByStandardizingPath = "URLByStandardizingPath";

    public static readonly Selector URLWithDataRepresentation_RelativeToURL = "URLWithDataRepresentation:relativeToURL:";

    public static readonly Selector URLWithString = "URLWithString:";

    public static readonly Selector URLWithString_EncodingInvalidCharacters = "URLWithString:encodingInvalidCharacters:";

    public static readonly Selector URLWithString_RelativeToURL = "URLWithString:relativeToURL:";

    public static readonly Selector User = "user";
}
