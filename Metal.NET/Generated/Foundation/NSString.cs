namespace Metal.NET;

public partial class NSString(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSString>
{
    #region INativeObject
    public static new NSString Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSString New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString() : this(ObjectiveC.AllocInit(NSStringBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint Length
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, NSStringBindings.Length);
    }

    public double DoubleValue
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, NSStringBindings.DoubleValue);
    }

    public float FloatValue
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, NSStringBindings.FloatValue);
    }

    public int IntValue
    {
        get => ObjectiveC.MsgSendInt(NativePtr, NSStringBindings.IntValue);
    }

    public nint IntegerValue
    {
        get => ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.IntegerValue);
    }

    public long LongLongValue
    {
        get => ObjectiveC.MsgSendLong(NativePtr, NSStringBindings.LongLongValue);
    }

    public Bool8 BoolValue
    {
        get => ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.BoolValue);
    }

    public NSString UppercaseString
    {
        get => GetProperty(ref field, NSStringBindings.UppercaseString);
    }

    public NSString LowercaseString
    {
        get => GetProperty(ref field, NSStringBindings.LowercaseString);
    }

    public NSString CapitalizedString
    {
        get => GetProperty(ref field, NSStringBindings.CapitalizedString);
    }

    public NSString LocalizedUppercaseString
    {
        get => GetProperty(ref field, NSStringBindings.LocalizedUppercaseString);
    }

    public NSString LocalizedLowercaseString
    {
        get => GetProperty(ref field, NSStringBindings.LocalizedLowercaseString);
    }

    public NSString LocalizedCapitalizedString
    {
        get => GetProperty(ref field, NSStringBindings.LocalizedCapitalizedString);
    }

    public nuint FastestEncoding
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, NSStringBindings.FastestEncoding);
    }

    public nuint SmallestEncoding
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, NSStringBindings.SmallestEncoding);
    }

    public nuint DefaultCStringEncoding
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, NSStringBindings.DefaultCStringEncoding);
    }

    public NSString DecomposedStringWithCanonicalMapping
    {
        get => GetProperty(ref field, NSStringBindings.DecomposedStringWithCanonicalMapping);
    }

    public NSString PrecomposedStringWithCanonicalMapping
    {
        get => GetProperty(ref field, NSStringBindings.PrecomposedStringWithCanonicalMapping);
    }

    public NSString DecomposedStringWithCompatibilityMapping
    {
        get => GetProperty(ref field, NSStringBindings.DecomposedStringWithCompatibilityMapping);
    }

    public NSString PrecomposedStringWithCompatibilityMapping
    {
        get => GetProperty(ref field, NSStringBindings.PrecomposedStringWithCompatibilityMapping);
    }

    public Bool8 IsAbsolutePath
    {
        get => ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.IsAbsolutePath);
    }

    public NSString LastPathComponent
    {
        get => GetProperty(ref field, NSStringBindings.LastPathComponent);
    }

    public NSString StringByDeletingLastPathComponent
    {
        get => GetProperty(ref field, NSStringBindings.StringByDeletingLastPathComponent);
    }

    public NSString PathExtension
    {
        get => GetProperty(ref field, NSStringBindings.PathExtension);
    }

    public NSString StringByDeletingPathExtension
    {
        get => GetProperty(ref field, NSStringBindings.StringByDeletingPathExtension);
    }

    public NSString StringByAbbreviatingWithTildeInPath
    {
        get => GetProperty(ref field, NSStringBindings.StringByAbbreviatingWithTildeInPath);
    }

    public NSString StringByExpandingTildeInPath
    {
        get => GetProperty(ref field, NSStringBindings.StringByExpandingTildeInPath);
    }

    public NSString StringByStandardizingPath
    {
        get => GetProperty(ref field, NSStringBindings.StringByStandardizingPath);
    }

    public NSString StringByResolvingSymlinksInPath
    {
        get => GetProperty(ref field, NSStringBindings.StringByResolvingSymlinksInPath);
    }

    public NSString StringByRemovingPercentEncoding
    {
        get => GetProperty(ref field, NSStringBindings.StringByRemovingPercentEncoding);
    }

    public ushort CharacterAtIndex(nuint index)
    {
        return (ushort)ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.CharacterAtIndex, index);
    }

    public NSString SubstringFromIndex(nuint from)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.SubstringFromIndex, from);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString SubstringToIndex(nuint to)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.SubstringToIndex, to);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString SubstringWithRange(NSRange range)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.SubstringWithRange, range);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool IsEqualToString(NSString aString)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.IsEqualToString, aString.NativePtr);
    }

    public bool HasPrefix(NSString str)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.HasPrefix, str.NativePtr);
    }

    public bool HasSuffix(NSString str)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.HasSuffix, str.NativePtr);
    }

    public bool ContainsString(NSString str)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.ContainsString, str.NativePtr);
    }

    public bool LocalizedCaseInsensitiveContainsString(NSString str)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.LocalizedCaseInsensitiveContainsString, str.NativePtr);
    }

    public bool LocalizedStandardContainsString(NSString str)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.LocalizedStandardContainsString, str.NativePtr);
    }

    public NSRange LocalizedStandardRangeOfString(NSString str)
    {
        return ObjectiveC.MsgSendNSRange(NativePtr, NSStringBindings.LocalizedStandardRangeOfString, str.NativePtr);
    }

    public NSRange RangeOfString(NSString searchString)
    {
        return ObjectiveC.MsgSendNSRange(NativePtr, NSStringBindings.RangeOfString, searchString.NativePtr);
    }

    public NSRange RangeOfComposedCharacterSequenceAtIndex(nuint index)
    {
        return ObjectiveC.MsgSendNSRange(NativePtr, NSStringBindings.RangeOfComposedCharacterSequenceAtIndex, index);
    }

    public NSRange RangeOfComposedCharacterSequencesForRange(NSRange range)
    {
        return ObjectiveC.MsgSendNSRange(NativePtr, NSStringBindings.RangeOfComposedCharacterSequencesForRange, range);
    }

    public NSString StringByAppendingString(NSString aString)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.StringByAppendingString, aString.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString StringByAppendingFormat(NSString format)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.StringByAppendingFormat, format.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void GetLineStart(nint startPtr, nint lineEndPtr, nint contentsEndPtr, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, NSStringBindings.GetLineStartEndContentsEndForRange, startPtr, lineEndPtr, contentsEndPtr, range);
    }

    public NSRange LineRangeForRange(NSRange range)
    {
        return ObjectiveC.MsgSendNSRange(NativePtr, NSStringBindings.LineRangeForRange, range);
    }

    public void GetParagraphStart(nint startPtr, nint parEndPtr, nint contentsEndPtr, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, NSStringBindings.GetParagraphStartEndContentsEndForRange, startPtr, parEndPtr, contentsEndPtr, range);
    }

    public NSRange ParagraphRangeForRange(NSRange range)
    {
        return ObjectiveC.MsgSendNSRange(NativePtr, NSStringBindings.ParagraphRangeForRange, range);
    }

    public NSData DataUsingEncoding(nuint encoding, bool lossy)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.DataUsingEncodingAllowLossyConversion, encoding, lossy);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSData DataUsingEncoding(nuint encoding)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.DataUsingEncoding, encoding);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool CanBeConvertedToEncoding(nuint encoding)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.CanBeConvertedToEncoding, encoding);
    }

    public nint CStringUsingEncoding(nuint encoding)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.CStringUsingEncoding, encoding);
    }

    public bool GetCString(nint buffer, nuint maxBufferCount, nuint encoding)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.GetCStringMaxLengthEncoding, buffer, maxBufferCount, encoding);
    }

    public nuint MaximumLengthOfBytesUsingEncoding(nuint enc)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, NSStringBindings.MaximumLengthOfBytesUsingEncoding, enc);
    }

    public nuint LengthOfBytesUsingEncoding(nuint enc)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, NSStringBindings.LengthOfBytesUsingEncoding, enc);
    }

    public NSString StringByPaddingToLength(nuint newLength, NSString padString, nuint padIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.StringByPaddingToLengthWithStringStartingAtIndex, newLength, padString.NativePtr, padIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString StringByReplacingOccurrencesOfString(NSString target, NSString replacement)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.StringByReplacingOccurrencesOfStringWithString, target.NativePtr, replacement.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString StringByReplacingCharactersInRange(NSRange range, NSString replacement)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.StringByReplacingCharactersInRangeWithString, range, replacement.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool WriteToURL(NSURL url, bool useAuxiliaryFile, nuint enc, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.WriteToURLAtomicallyEncodingError, url.NativePtr, useAuxiliaryFile, enc, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool WriteToFile(NSString path, bool useAuxiliaryFile, nuint enc, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.WriteToFileAtomicallyEncodingError, path.NativePtr, useAuxiliaryFile, enc, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public NSObject PropertyList()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.PropertyList);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSDictionary PropertyListFromStringsFileFormat()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.PropertyListFromStringsFileFormat);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public nint CString()
    {
        return ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.CString);
    }

    public nint LossyCString()
    {
        return ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.LossyCString);
    }

    public nuint CStringLength()
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, NSStringBindings.CStringLength);
    }

    public void GetCString(nint bytes)
    {
        ObjectiveC.MsgSend(NativePtr, NSStringBindings.GetCString, bytes);
    }

    public void GetCString(nint bytes, nuint maxLength)
    {
        ObjectiveC.MsgSend(NativePtr, NSStringBindings.GetCStringMaxLength, bytes, maxLength);
    }

    public bool WriteToFile(NSString path, bool useAuxiliaryFile)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.WriteToFileAtomically, path.NativePtr, useAuxiliaryFile);
    }

    public bool WriteToURL(NSURL url, bool atomically)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.WriteToURLAtomically, url.NativePtr, atomically);
    }

    public NSString VariantFittingPresentationWidth(nint width)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.VariantFittingPresentationWidth, width);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString StringByAppendingPathComponent(NSString str)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.StringByAppendingPathComponent, str.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString StringByAppendingPathExtension(NSString str)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.StringByAppendingPathExtension, str.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool GetFileSystemRepresentation(nint cname, nuint max)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.GetFileSystemRepresentationMaxLength, cname, max);
    }

    public NSString StringByAddingPercentEscapesUsingEncoding(nuint enc)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.StringByAddingPercentEscapesUsingEncoding, enc);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString StringByReplacingPercentEscapesUsingEncoding(nuint enc)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.StringByReplacingPercentEscapesUsingEncoding, enc);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSString LocalizedNameOfStringEncoding(nuint encoding)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.LocalizedNameOfStringEncoding, encoding);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static nint String()
    {
        return ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.String);
    }

    public static nint StringWithString(NSString @string)
    {
        return ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithString, @string.NativePtr);
    }

    public static nint StringWithUTF8String(nint nullTerminatedCString)
    {
        return ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithUTF8String, nullTerminatedCString);
    }

    public static nint StringWithFormat(NSString format)
    {
        return ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithFormat, format.NativePtr);
    }

    public static nint LocalizedStringWithFormat(NSString format)
    {
        return ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.LocalizedStringWithFormat, format.NativePtr);
    }

    public static nint StringWithValidatedFormat(NSString format, NSString validFormatSpecifiers, out NSError error)
    {
        nint result = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithValidatedFormatValidFormatSpecifiersError, format.NativePtr, validFormatSpecifiers.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public static nint LocalizedStringWithValidatedFormat(NSString format, NSString validFormatSpecifiers, out NSError error)
    {
        nint result = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.LocalizedStringWithValidatedFormatValidFormatSpecifiersError, format.NativePtr, validFormatSpecifiers.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public static nint StringWithCString(nint cString, nuint enc)
    {
        return ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithCStringEncoding, cString, enc);
    }

    public static nint StringWithContentsOfURL(NSURL url, nuint enc, out NSError error)
    {
        nint result = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithContentsOfURLEncodingError, url.NativePtr, enc, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public static nint StringWithContentsOfFile(NSString path, nuint enc, out NSError error)
    {
        nint result = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithContentsOfFileEncodingError, path.NativePtr, enc, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public static NSObject StringWithContentsOfFile(NSString path)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithContentsOfFile, path.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSObject StringWithContentsOfURL(NSURL url)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithContentsOfURL, url.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSObject StringWithCString(nint bytes)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithCString, bytes);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSString InitWithUTF8String(nint nullTerminatedCString)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithUTF8String, nullTerminatedCString);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithString(NSString aString)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithString, aString.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithFormat(NSString format)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithFormat, format.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithFormatLocale(NSString format, NSObject locale)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithFormatLocale, format.NativePtr, locale.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithValidatedFormatValidFormatSpecifiersError(NSString format, NSString validFormatSpecifiers, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithValidatedFormatValidFormatSpecifiersError, format.NativePtr, validFormatSpecifiers.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithValidatedFormatValidFormatSpecifiersLocaleError(NSString format, NSString validFormatSpecifiers, NSObject locale, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithValidatedFormatValidFormatSpecifiersLocaleError, format.NativePtr, validFormatSpecifiers.NativePtr, locale.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithDataEncoding(NSData data, nuint encoding)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithDataEncoding, data.NativePtr, encoding);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithBytesLengthEncoding(nint bytes, nuint len, nuint encoding)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithBytesLengthEncoding, bytes, len, encoding);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithBytesNoCopyLengthEncodingFreeWhenDone(nint bytes, nuint len, nuint encoding, bool freeBuffer)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithBytesNoCopyLengthEncodingFreeWhenDone, bytes, len, encoding, freeBuffer);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithCStringEncoding(nint nullTerminatedCString, nuint encoding)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithCStringEncoding, nullTerminatedCString, encoding);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithContentsOfURLEncodingError(NSURL url, nuint enc, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithContentsOfURLEncodingError, url.NativePtr, enc, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithContentsOfFileEncodingError(NSString path, nuint enc, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithContentsOfFileEncodingError, path.NativePtr, enc, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithContentsOfFile(NSString path)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithContentsOfFile, path.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithContentsOfURL(NSURL url)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithContentsOfURL, url.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithCStringNoCopyLengthFreeWhenDone(nint bytes, nuint length, bool freeBuffer)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithCStringNoCopyLengthFreeWhenDone, bytes, length, freeBuffer);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithCStringLength(nint bytes, nuint length)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithCStringLength, bytes, length);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithCString(nint bytes)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithCString, bytes);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }
}

file static class NSStringBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSString");

    public static readonly Selector BoolValue = "boolValue";

    public static readonly Selector CanBeConvertedToEncoding = "canBeConvertedToEncoding:";

    public static readonly Selector CapitalizedString = "capitalizedString";

    public static readonly Selector CharacterAtIndex = "characterAtIndex:";

    public static readonly Selector ContainsString = "containsString:";

    public static readonly Selector CString = "cString";

    public static readonly Selector CStringLength = "cStringLength";

    public static readonly Selector CStringUsingEncoding = "cStringUsingEncoding:";

    public static readonly Selector DataUsingEncoding = "dataUsingEncoding:";

    public static readonly Selector DataUsingEncodingAllowLossyConversion = "dataUsingEncoding:allowLossyConversion:";

    public static readonly Selector DecomposedStringWithCanonicalMapping = "decomposedStringWithCanonicalMapping";

    public static readonly Selector DecomposedStringWithCompatibilityMapping = "decomposedStringWithCompatibilityMapping";

    public static readonly Selector DefaultCStringEncoding = "defaultCStringEncoding";

    public static readonly Selector DoubleValue = "doubleValue";

    public static readonly Selector FastestEncoding = "fastestEncoding";

    public static readonly Selector FloatValue = "floatValue";

    public static readonly Selector GetCString = "getCString:";

    public static readonly Selector GetCStringMaxLength = "getCString:maxLength:";

    public static readonly Selector GetCStringMaxLengthEncoding = "getCString:maxLength:encoding:";

    public static readonly Selector GetFileSystemRepresentationMaxLength = "getFileSystemRepresentation:maxLength:";

    public static readonly Selector GetLineStartEndContentsEndForRange = "getLineStart:end:contentsEnd:forRange:";

    public static readonly Selector GetParagraphStartEndContentsEndForRange = "getParagraphStart:end:contentsEnd:forRange:";

    public static readonly Selector HasPrefix = "hasPrefix:";

    public static readonly Selector HasSuffix = "hasSuffix:";

    public static readonly Selector InitWithBytesLengthEncoding = "initWithBytes:length:encoding:";

    public static readonly Selector InitWithBytesNoCopyLengthEncodingFreeWhenDone = "initWithBytesNoCopy:length:encoding:freeWhenDone:";

    public static readonly Selector InitWithContentsOfFile = "initWithContentsOfFile:";

    public static readonly Selector InitWithContentsOfFileEncodingError = "initWithContentsOfFile:encoding:error:";

    public static readonly Selector InitWithContentsOfURL = "initWithContentsOfURL:";

    public static readonly Selector InitWithContentsOfURLEncodingError = "initWithContentsOfURL:encoding:error:";

    public static readonly Selector InitWithCString = "initWithCString:";

    public static readonly Selector InitWithCStringEncoding = "initWithCString:encoding:";

    public static readonly Selector InitWithCStringLength = "initWithCString:length:";

    public static readonly Selector InitWithCStringNoCopyLengthFreeWhenDone = "initWithCStringNoCopy:length:freeWhenDone:";

    public static readonly Selector InitWithDataEncoding = "initWithData:encoding:";

    public static readonly Selector InitWithFormat = "initWithFormat:";

    public static readonly Selector InitWithFormatLocale = "initWithFormat:locale:";

    public static readonly Selector InitWithString = "initWithString:";

    public static readonly Selector InitWithUTF8String = "initWithUTF8String:";

    public static readonly Selector InitWithValidatedFormatValidFormatSpecifiersError = "initWithValidatedFormat:validFormatSpecifiers:error:";

    public static readonly Selector InitWithValidatedFormatValidFormatSpecifiersLocaleError = "initWithValidatedFormat:validFormatSpecifiers:locale:error:";

    public static readonly Selector IntegerValue = "integerValue";

    public static readonly Selector IntValue = "intValue";

    public static readonly Selector IsAbsolutePath = "isAbsolutePath";

    public static readonly Selector IsEqualToString = "isEqualToString:";

    public static readonly Selector LastPathComponent = "lastPathComponent";

    public static readonly Selector Length = "length";

    public static readonly Selector LengthOfBytesUsingEncoding = "lengthOfBytesUsingEncoding:";

    public static readonly Selector LineRangeForRange = "lineRangeForRange:";

    public static readonly Selector LocalizedCapitalizedString = "localizedCapitalizedString";

    public static readonly Selector LocalizedCaseInsensitiveContainsString = "localizedCaseInsensitiveContainsString:";

    public static readonly Selector LocalizedLowercaseString = "localizedLowercaseString";

    public static readonly Selector LocalizedNameOfStringEncoding = "localizedNameOfStringEncoding:";

    public static readonly Selector LocalizedStandardContainsString = "localizedStandardContainsString:";

    public static readonly Selector LocalizedStandardRangeOfString = "localizedStandardRangeOfString:";

    public static readonly Selector LocalizedStringWithFormat = "localizedStringWithFormat:";

    public static readonly Selector LocalizedStringWithValidatedFormatValidFormatSpecifiersError = "localizedStringWithValidatedFormat:validFormatSpecifiers:error:";

    public static readonly Selector LocalizedUppercaseString = "localizedUppercaseString";

    public static readonly Selector LongLongValue = "longLongValue";

    public static readonly Selector LossyCString = "lossyCString";

    public static readonly Selector LowercaseString = "lowercaseString";

    public static readonly Selector MaximumLengthOfBytesUsingEncoding = "maximumLengthOfBytesUsingEncoding:";

    public static readonly Selector ParagraphRangeForRange = "paragraphRangeForRange:";

    public static readonly Selector PathExtension = "pathExtension";

    public static readonly Selector PrecomposedStringWithCanonicalMapping = "precomposedStringWithCanonicalMapping";

    public static readonly Selector PrecomposedStringWithCompatibilityMapping = "precomposedStringWithCompatibilityMapping";

    public static readonly Selector PropertyList = "propertyList";

    public static readonly Selector PropertyListFromStringsFileFormat = "propertyListFromStringsFileFormat";

    public static readonly Selector RangeOfComposedCharacterSequenceAtIndex = "rangeOfComposedCharacterSequenceAtIndex:";

    public static readonly Selector RangeOfComposedCharacterSequencesForRange = "rangeOfComposedCharacterSequencesForRange:";

    public static readonly Selector RangeOfString = "rangeOfString:";

    public static readonly Selector SmallestEncoding = "smallestEncoding";

    public static readonly Selector String = "string";

    public static readonly Selector StringByAbbreviatingWithTildeInPath = "stringByAbbreviatingWithTildeInPath";

    public static readonly Selector StringByAddingPercentEscapesUsingEncoding = "stringByAddingPercentEscapesUsingEncoding:";

    public static readonly Selector StringByAppendingFormat = "stringByAppendingFormat:";

    public static readonly Selector StringByAppendingPathComponent = "stringByAppendingPathComponent:";

    public static readonly Selector StringByAppendingPathExtension = "stringByAppendingPathExtension:";

    public static readonly Selector StringByAppendingString = "stringByAppendingString:";

    public static readonly Selector StringByDeletingLastPathComponent = "stringByDeletingLastPathComponent";

    public static readonly Selector StringByDeletingPathExtension = "stringByDeletingPathExtension";

    public static readonly Selector StringByExpandingTildeInPath = "stringByExpandingTildeInPath";

    public static readonly Selector StringByPaddingToLengthWithStringStartingAtIndex = "stringByPaddingToLength:withString:startingAtIndex:";

    public static readonly Selector StringByRemovingPercentEncoding = "stringByRemovingPercentEncoding";

    public static readonly Selector StringByReplacingCharactersInRangeWithString = "stringByReplacingCharactersInRange:withString:";

    public static readonly Selector StringByReplacingOccurrencesOfStringWithString = "stringByReplacingOccurrencesOfString:withString:";

    public static readonly Selector StringByReplacingPercentEscapesUsingEncoding = "stringByReplacingPercentEscapesUsingEncoding:";

    public static readonly Selector StringByResolvingSymlinksInPath = "stringByResolvingSymlinksInPath";

    public static readonly Selector StringByStandardizingPath = "stringByStandardizingPath";

    public static readonly Selector StringWithContentsOfFile = "stringWithContentsOfFile:";

    public static readonly Selector StringWithContentsOfFileEncodingError = "stringWithContentsOfFile:encoding:error:";

    public static readonly Selector StringWithContentsOfURL = "stringWithContentsOfURL:";

    public static readonly Selector StringWithContentsOfURLEncodingError = "stringWithContentsOfURL:encoding:error:";

    public static readonly Selector StringWithCString = "stringWithCString:";

    public static readonly Selector StringWithCStringEncoding = "stringWithCString:encoding:";

    public static readonly Selector StringWithFormat = "stringWithFormat:";

    public static readonly Selector StringWithString = "stringWithString:";

    public static readonly Selector StringWithUTF8String = "stringWithUTF8String:";

    public static readonly Selector StringWithValidatedFormatValidFormatSpecifiersError = "stringWithValidatedFormat:validFormatSpecifiers:error:";

    public static readonly Selector SubstringFromIndex = "substringFromIndex:";

    public static readonly Selector SubstringToIndex = "substringToIndex:";

    public static readonly Selector SubstringWithRange = "substringWithRange:";

    public static readonly Selector UppercaseString = "uppercaseString";

    public static readonly Selector VariantFittingPresentationWidth = "variantFittingPresentationWidth:";

    public static readonly Selector WriteToFileAtomically = "writeToFile:atomically:";

    public static readonly Selector WriteToFileAtomicallyEncodingError = "writeToFile:atomically:encoding:error:";

    public static readonly Selector WriteToURLAtomically = "writeToURL:atomically:";

    public static readonly Selector WriteToURLAtomicallyEncodingError = "writeToURL:atomically:encoding:error:";
}
