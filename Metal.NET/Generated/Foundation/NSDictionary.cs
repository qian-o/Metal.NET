namespace Metal.NET;

public partial class NSDictionary(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSDictionary>
{
    #region INativeObject
    public static new NSDictionary Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSDictionary New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSDictionary() : this(ObjectiveC.AllocInit(NSDictionaryBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint Count
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, NSDictionaryBindings.Count);
    }

    public NSString DescriptionInStringsFileFormat
    {
        get => GetProperty(ref field, NSDictionaryBindings.DescriptionInStringsFileFormat);
    }

    public NSString DescriptionWithLocale(NSObject locale)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSDictionaryBindings.DescriptionWithLocale, locale.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString DescriptionWithLocale(NSObject locale, nuint level)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSDictionaryBindings.DescriptionWithLocale_Indent, locale.NativePtr, level);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool WriteToURL(NSURL url, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, NSDictionaryBindings.WriteToURL_Error, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool WriteToFile(NSString path, bool useAuxiliaryFile)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSDictionaryBindings.WriteToFile_Atomically, path.NativePtr, useAuxiliaryFile);
    }

    public bool WriteToURL(NSURL url, bool atomically)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSDictionaryBindings.WriteToURL_Atomically, url.NativePtr, atomically);
    }

    public ulong FileSize()
    {
        return ObjectiveC.MsgSendULong(NativePtr, NSDictionaryBindings.FileSize);
    }

    public NSString FileType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSDictionaryBindings.FileType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public nuint FilePosixPermissions()
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, NSDictionaryBindings.FilePosixPermissions);
    }

    public NSString FileOwnerAccountName()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSDictionaryBindings.FileOwnerAccountName);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString FileGroupOwnerAccountName()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSDictionaryBindings.FileGroupOwnerAccountName);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public nint FileSystemNumber()
    {
        return ObjectiveC.MsgSendNInt(NativePtr, NSDictionaryBindings.FileSystemNumber);
    }

    public nuint FileSystemFileNumber()
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, NSDictionaryBindings.FileSystemFileNumber);
    }

    public bool FileExtensionHidden()
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSDictionaryBindings.FileExtensionHidden);
    }

    public uint FileHFSCreatorCode()
    {
        return ObjectiveC.MsgSendUInt(NativePtr, NSDictionaryBindings.FileHFSCreatorCode);
    }

    public uint FileHFSTypeCode()
    {
        return ObjectiveC.MsgSendUInt(NativePtr, NSDictionaryBindings.FileHFSTypeCode);
    }

    public bool FileIsImmutable()
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSDictionaryBindings.FileIsImmutable);
    }

    public bool FileIsAppendOnly()
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSDictionaryBindings.FileIsAppendOnly);
    }

    public NSNumber FileOwnerAccountID()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSDictionaryBindings.FileOwnerAccountID);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSNumber FileGroupOwnerAccountID()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSDictionaryBindings.FileGroupOwnerAccountID);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static nint Dictionary()
    {
        return ObjectiveC.MsgSendNInt(NSDictionaryBindings.Class, NSDictionaryBindings.Dictionary);
    }

    public static nint DictionaryWithObjectsAndKeys(NSObject firstObject)
    {
        return ObjectiveC.MsgSendNInt(NSDictionaryBindings.Class, NSDictionaryBindings.DictionaryWithObjectsAndKeys, firstObject.NativePtr);
    }

    public static NSObject SharedKeySetForKeys(NSObject[] keys)
    {
        nint pKeys = NSArray.FromArray(keys);

        nint nativePtr = ObjectiveC.MsgSendNInt(NSDictionaryBindings.Class, NSDictionaryBindings.SharedKeySetForKeys, pKeys);

        ObjectiveC.Release(pKeys);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSDictionary InitWithContentsOfFile(NSString path)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSDictionaryBindings.Class), NSDictionaryBindings.InitWithContentsOfFile, path.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSDictionary InitWithContentsOfURL(NSURL url)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSDictionaryBindings.Class), NSDictionaryBindings.InitWithContentsOfURL, url.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSDictionary InitWithObjectsAndKeys(NSObject firstObject)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSDictionaryBindings.Class), NSDictionaryBindings.InitWithObjectsAndKeys, firstObject.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSDictionary InitWithContentsOfURL_Error(NSURL url, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSDictionaryBindings.Class), NSDictionaryBindings.InitWithContentsOfURL_Error, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }
}

file static class NSDictionaryBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSDictionary");

    public static readonly Selector Count = "count";

    public static readonly Selector DescriptionInStringsFileFormat = "descriptionInStringsFileFormat";

    public static readonly Selector DescriptionWithLocale = "descriptionWithLocale:";

    public static readonly Selector DescriptionWithLocale_Indent = "descriptionWithLocale:indent:";

    public static readonly Selector Dictionary = "dictionary";

    public static readonly Selector DictionaryWithObjectsAndKeys = "dictionaryWithObjectsAndKeys:";

    public static readonly Selector FileExtensionHidden = "fileExtensionHidden";

    public static readonly Selector FileGroupOwnerAccountID = "fileGroupOwnerAccountID";

    public static readonly Selector FileGroupOwnerAccountName = "fileGroupOwnerAccountName";

    public static readonly Selector FileHFSCreatorCode = "fileHFSCreatorCode";

    public static readonly Selector FileHFSTypeCode = "fileHFSTypeCode";

    public static readonly Selector FileIsAppendOnly = "fileIsAppendOnly";

    public static readonly Selector FileIsImmutable = "fileIsImmutable";

    public static readonly Selector FileOwnerAccountID = "fileOwnerAccountID";

    public static readonly Selector FileOwnerAccountName = "fileOwnerAccountName";

    public static readonly Selector FilePosixPermissions = "filePosixPermissions";

    public static readonly Selector FileSize = "fileSize";

    public static readonly Selector FileSystemFileNumber = "fileSystemFileNumber";

    public static readonly Selector FileSystemNumber = "fileSystemNumber";

    public static readonly Selector FileType = "fileType";

    public static readonly Selector InitWithContentsOfFile = "initWithContentsOfFile:";

    public static readonly Selector InitWithContentsOfURL = "initWithContentsOfURL:";

    public static readonly Selector InitWithContentsOfURL_Error = "initWithContentsOfURL:error:";

    public static readonly Selector InitWithObjectsAndKeys = "initWithObjectsAndKeys:";

    public static readonly Selector SharedKeySetForKeys = "sharedKeySetForKeys:";

    public static readonly Selector WriteToFile_Atomically = "writeToFile:atomically:";

    public static readonly Selector WriteToURL_Atomically = "writeToURL:atomically:";

    public static readonly Selector WriteToURL_Error = "writeToURL:error:";
}
