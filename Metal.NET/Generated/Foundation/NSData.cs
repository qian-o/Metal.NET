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
        ObjectiveC.MsgSend(NativePtr, NSDataBindings.GetBytes_Length, buffer, length);
    }

    public void GetBytes(nint buffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, NSDataBindings.GetBytes_Range, buffer, range);
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
        return ObjectiveC.MsgSendBool(NativePtr, NSDataBindings.WriteToFile_Atomically, path.NativePtr, useAuxiliaryFile);
    }

    public bool WriteToURL(NSURL url, bool atomically)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSDataBindings.WriteToURL_Atomically, url.NativePtr, atomically);
    }

    public void GetBytes(nint buffer)
    {
        ObjectiveC.MsgSend(NativePtr, NSDataBindings.GetBytes, buffer);
    }

    public NSString Base64Encoding()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSDataBindings.Base64Encoding);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static nint Data()
    {
        return ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.Data);
    }

    public static nint DataWithBytes(nint bytes, nuint length)
    {
        return ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.DataWithBytes_Length, bytes, length);
    }

    public static nint DataWithBytesNoCopy(nint bytes, nuint length)
    {
        return ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.DataWithBytesNoCopy_Length, bytes, length);
    }

    public static nint DataWithBytesNoCopy(nint bytes, nuint length, bool b)
    {
        return ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.DataWithBytesNoCopy_Length_FreeWhenDone, bytes, length, b);
    }

    public static nint DataWithContentsOfFile(NSString path)
    {
        return ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.DataWithContentsOfFile, path.NativePtr);
    }

    public static nint DataWithContentsOfURL(NSURL url)
    {
        return ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.DataWithContentsOfURL, url.NativePtr);
    }

    public static nint DataWithData(NSData data)
    {
        return ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.DataWithData, data.NativePtr);
    }

    public static NSObject DataWithContentsOfMappedFile(NSString path)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSDataBindings.Class, NSDataBindings.DataWithContentsOfMappedFile, path.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSData InitWithBytes(nint bytes, nuint length)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSDataBindings.Class), NSDataBindings.InitWithBytes_Length, bytes, length);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSData InitWithBytesNoCopy(nint bytes, nuint length)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSDataBindings.Class), NSDataBindings.InitWithBytesNoCopy_Length, bytes, length);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSData InitWithBytesNoCopy(nint bytes, nuint length, bool b)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSDataBindings.Class), NSDataBindings.InitWithBytesNoCopy_Length_FreeWhenDone, bytes, length, b);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSData InitWithBytesNoCopy(nint bytes, nuint length, MTLNewBufferWithBytesNoCopyDeallocator deallocator)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSDataBindings.Class), NSDataBindings.InitWithBytesNoCopy_Length_Deallocator, bytes, length, deallocator.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSData InitWithContentsOfFile(NSString path)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSDataBindings.Class), NSDataBindings.InitWithContentsOfFile, path.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSData InitWithContentsOfURL(NSURL url)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSDataBindings.Class), NSDataBindings.InitWithContentsOfURL, url.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSData InitWithData(NSData data)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSDataBindings.Class), NSDataBindings.InitWithData, data.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSData InitWithContentsOfMappedFile(NSString path)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSDataBindings.Class), NSDataBindings.InitWithContentsOfMappedFile, path.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSData InitWithBase64Encoding(NSString base64String)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSDataBindings.Class), NSDataBindings.InitWithBase64Encoding, base64String.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }
}

file static class NSDataBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSData");

    public static readonly Selector Base64Encoding = "base64Encoding";

    public static readonly Selector Data = "data";

    public static readonly Selector DataWithBytes_Length = "dataWithBytes:length:";

    public static readonly Selector DataWithBytesNoCopy_Length = "dataWithBytesNoCopy:length:";

    public static readonly Selector DataWithBytesNoCopy_Length_FreeWhenDone = "dataWithBytesNoCopy:length:freeWhenDone:";

    public static readonly Selector DataWithContentsOfFile = "dataWithContentsOfFile:";

    public static readonly Selector DataWithContentsOfMappedFile = "dataWithContentsOfMappedFile:";

    public static readonly Selector DataWithContentsOfURL = "dataWithContentsOfURL:";

    public static readonly Selector DataWithData = "dataWithData:";

    public static readonly Selector GetBytes = "getBytes:";

    public static readonly Selector GetBytes_Length = "getBytes:length:";

    public static readonly Selector GetBytes_Range = "getBytes:range:";

    public static readonly Selector InitWithBase64Encoding = "initWithBase64Encoding:";

    public static readonly Selector InitWithBytes_Length = "initWithBytes:length:";

    public static readonly Selector InitWithBytesNoCopy_Length = "initWithBytesNoCopy:length:";

    public static readonly Selector InitWithBytesNoCopy_Length_Deallocator = "initWithBytesNoCopy:length:deallocator:";

    public static readonly Selector InitWithBytesNoCopy_Length_FreeWhenDone = "initWithBytesNoCopy:length:freeWhenDone:";

    public static readonly Selector InitWithContentsOfFile = "initWithContentsOfFile:";

    public static readonly Selector InitWithContentsOfMappedFile = "initWithContentsOfMappedFile:";

    public static readonly Selector InitWithContentsOfURL = "initWithContentsOfURL:";

    public static readonly Selector InitWithData = "initWithData:";

    public static readonly Selector IsEqualToData = "isEqualToData:";

    public static readonly Selector Length = "length";

    public static readonly Selector SubdataWithRange = "subdataWithRange:";

    public static readonly Selector WriteToFile_Atomically = "writeToFile:atomically:";

    public static readonly Selector WriteToURL_Atomically = "writeToURL:atomically:";
}
