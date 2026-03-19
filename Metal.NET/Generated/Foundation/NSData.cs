namespace Metal.NET;

public partial class NSData(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSData>
{
    #region INativeObject
    public static new NSData Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSData New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSData() : this(ObjectiveC.AllocInit(NSDataBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint Length
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, NSDataBindings.Length);
    }

    public void GetBytes(nint buffer, nuint length)
    {
        ObjectiveC.MsgSend(NativePtr, NSDataBindings.GetBytesLength, buffer, length);
    }

    public void GetBytes(nint buffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, NSDataBindings.GetBytesRange, buffer, range);
    }

    public bool IsEqualToData(NSData other)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSDataBindings.IsEqualToData, other.NativePtr);
    }

    public NSData SubdataWithRange(NSRange range)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSDataBindings.SubdataWithRange, range);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool WriteToFile(NSString path, bool useAuxiliaryFile)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSDataBindings.WriteToFileAtomically, path.NativePtr, useAuxiliaryFile);
    }

    public bool WriteToURL(NSURL url, bool atomically)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSDataBindings.WriteToURLAtomically, url.NativePtr, atomically);
    }

    public static nint Data()
    {
        return ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.Data);
    }

    public static nint DataWithBytes(nint bytes, nuint length)
    {
        return ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.DataWithBytesLength, bytes, length);
    }

    public static nint DataWithBytesNoCopy(nint bytes, nuint length)
    {
        return ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.DataWithBytesNoCopyLength, bytes, length);
    }

    public static nint DataWithBytesNoCopy(nint bytes, nuint length, bool b)
    {
        return ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.DataWithBytesNoCopyLengthFreeWhenDone, bytes, length, b);
    }

    public static nint DataWithContentsOfFile(NSString path)
    {
        return ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.DataWithContentsOfFile, path.NativePtr);
    }

    public static nint DataWithContentsOfURL(NSURL url)
    {
        return ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.DataWithContentsOfURL, url.NativePtr);
    }

    public nint InitWithBytes(nint bytes, nuint length)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, NSDataBindings.InitWithBytesLength, bytes, length);
    }

    public nint InitWithBytesNoCopy(nint bytes, nuint length)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, NSDataBindings.InitWithBytesNoCopyLength, bytes, length);
    }

    public nint InitWithBytesNoCopy(nint bytes, nuint length, bool b)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, NSDataBindings.InitWithBytesNoCopyLengthFreeWhenDone, bytes, length, b);
    }

    public nint InitWithContentsOfFile(NSString path)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, NSDataBindings.InitWithContentsOfFile, path.NativePtr);
    }

    public nint InitWithContentsOfURL(NSURL url)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, NSDataBindings.InitWithContentsOfURL, url.NativePtr);
    }

    public nint InitWithData(NSData data)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, NSDataBindings.InitWithData, data.NativePtr);
    }

    public static nint DataWithData(NSData data)
    {
        return ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.DataWithData, data.NativePtr);
    }

    public void GetBytes(nint buffer)
    {
        ObjectiveC.MsgSend(NativePtr, NSDataBindings.GetBytes, buffer);
    }

    public static NSObject DataWithContentsOfMappedFile(NSString path)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.DataWithContentsOfMappedFile, path.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSObject InitWithContentsOfMappedFile(NSString path)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSDataBindings.InitWithContentsOfMappedFile, path.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSObject InitWithBase64Encoding(NSString base64String)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSDataBindings.InitWithBase64Encoding, base64String.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString Base64Encoding()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSDataBindings.Base64Encoding);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class NSDataBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSData");

    public static readonly Selector Base64Encoding = "base64Encoding";

    public static readonly Selector Data = "data";

    public static readonly Selector DataWithBytesLength = "dataWithBytes:length:";

    public static readonly Selector DataWithBytesNoCopyLength = "dataWithBytesNoCopy:length:";

    public static readonly Selector DataWithBytesNoCopyLengthFreeWhenDone = "dataWithBytesNoCopy:length:freeWhenDone:";

    public static readonly Selector DataWithContentsOfFile = "dataWithContentsOfFile:";

    public static readonly Selector DataWithContentsOfMappedFile = "dataWithContentsOfMappedFile:";

    public static readonly Selector DataWithContentsOfURL = "dataWithContentsOfURL:";

    public static readonly Selector DataWithData = "dataWithData:";

    public static readonly Selector GetBytes = "getBytes:";

    public static readonly Selector GetBytesLength = "getBytes:length:";

    public static readonly Selector GetBytesRange = "getBytes:range:";

    public static readonly Selector InitWithBase64Encoding = "initWithBase64Encoding:";

    public static readonly Selector InitWithBytesLength = "initWithBytes:length:";

    public static readonly Selector InitWithBytesNoCopyLength = "initWithBytesNoCopy:length:";

    public static readonly Selector InitWithBytesNoCopyLengthFreeWhenDone = "initWithBytesNoCopy:length:freeWhenDone:";

    public static readonly Selector InitWithContentsOfFile = "initWithContentsOfFile:";

    public static readonly Selector InitWithContentsOfMappedFile = "initWithContentsOfMappedFile:";

    public static readonly Selector InitWithContentsOfURL = "initWithContentsOfURL:";

    public static readonly Selector InitWithData = "initWithData:";

    public static readonly Selector IsEqualToData = "isEqualToData:";

    public static readonly Selector Length = "length";

    public static readonly Selector SubdataWithRange = "subdataWithRange:";

    public static readonly Selector WriteToFileAtomically = "writeToFile:atomically:";

    public static readonly Selector WriteToURLAtomically = "writeToURL:atomically:";
}
