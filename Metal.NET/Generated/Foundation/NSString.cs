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

    public NSStringEncoding FastestEncoding
    {
        get => (NSStringEncoding)ObjectiveC.MsgSendULong(NativePtr, NSStringBindings.FastestEncoding);
    }

    public NSStringEncoding SmallestEncoding
    {
        get => (NSStringEncoding)ObjectiveC.MsgSendULong(NativePtr, NSStringBindings.SmallestEncoding);
    }

    public NSStringEncoding DefaultCStringEncoding
    {
        get => (NSStringEncoding)ObjectiveC.MsgSendULong(NativePtr, NSStringBindings.DefaultCStringEncoding);
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

    public Bool8 AbsolutePath
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

    public NSComparisonResult Compare(NSString @string)
    {
        return (NSComparisonResult)ObjectiveC.MsgSendLong(NativePtr, NSStringBindings.Compare, @string.NativePtr);
    }

    public NSComparisonResult Compare(NSString @string, NSStringCompareOptions mask)
    {
        return (NSComparisonResult)ObjectiveC.MsgSendLong(NativePtr, NSStringBindings.Compare_Options, @string.NativePtr, (nuint)mask);
    }

    public NSComparisonResult Compare(NSString @string, NSStringCompareOptions mask, NSRange rangeOfReceiverToCompare)
    {
        return (NSComparisonResult)ObjectiveC.MsgSendLong(NativePtr, NSStringBindings.Compare_Options_Range, @string.NativePtr, (nuint)mask, rangeOfReceiverToCompare);
    }

    public NSComparisonResult Compare(NSString @string, NSStringCompareOptions mask, NSRange rangeOfReceiverToCompare, NSObject locale)
    {
        return (NSComparisonResult)ObjectiveC.MsgSendLong(NativePtr, NSStringBindings.Compare_Options_Range_Locale, @string.NativePtr, (nuint)mask, rangeOfReceiverToCompare, locale.NativePtr);
    }

    public NSComparisonResult CaseInsensitiveCompare(NSString @string)
    {
        return (NSComparisonResult)ObjectiveC.MsgSendLong(NativePtr, NSStringBindings.CaseInsensitiveCompare, @string.NativePtr);
    }

    public NSComparisonResult LocalizedCompare(NSString @string)
    {
        return (NSComparisonResult)ObjectiveC.MsgSendLong(NativePtr, NSStringBindings.LocalizedCompare, @string.NativePtr);
    }

    public NSComparisonResult LocalizedCaseInsensitiveCompare(NSString @string)
    {
        return (NSComparisonResult)ObjectiveC.MsgSendLong(NativePtr, NSStringBindings.LocalizedCaseInsensitiveCompare, @string.NativePtr);
    }

    public NSComparisonResult LocalizedStandardCompare(NSString @string)
    {
        return (NSComparisonResult)ObjectiveC.MsgSendLong(NativePtr, NSStringBindings.LocalizedStandardCompare, @string.NativePtr);
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

    public NSString CommonPrefixWithString(NSString str, NSStringCompareOptions mask)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.CommonPrefixWithString_Options, str.NativePtr, (nuint)mask);

        return new(nativePtr, NativeObjectOwnership.Owned);
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

    public NSRange RangeOfString(NSString searchString, NSStringCompareOptions mask)
    {
        return ObjectiveC.MsgSendNSRange(NativePtr, NSStringBindings.RangeOfString_Options, searchString.NativePtr, (nuint)mask);
    }

    public NSRange RangeOfString(NSString searchString, NSStringCompareOptions mask, NSRange rangeOfReceiverToSearch)
    {
        return ObjectiveC.MsgSendNSRange(NativePtr, NSStringBindings.RangeOfString_Options_Range, searchString.NativePtr, (nuint)mask, rangeOfReceiverToSearch);
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

    public unsafe void GetLineStart(nuint[] startPtr, nuint[] lineEndPtr, nuint[] contentsEndPtr, NSRange range)
    {
        nuint* pStartPtr = stackalloc nuint[startPtr.Length];
        for (int i = 0; i < startPtr.Length; i++)
        {
            pStartPtr[i] = startPtr[i];
        }

        nuint* pLineEndPtr = stackalloc nuint[lineEndPtr.Length];
        for (int i = 0; i < lineEndPtr.Length; i++)
        {
            pLineEndPtr[i] = lineEndPtr[i];
        }

        nuint* pContentsEndPtr = stackalloc nuint[contentsEndPtr.Length];
        for (int i = 0; i < contentsEndPtr.Length; i++)
        {
            pContentsEndPtr[i] = contentsEndPtr[i];
        }

        ObjectiveC.MsgSend(NativePtr, NSStringBindings.GetLineStart_End_ContentsEnd_ForRange, (nint)pStartPtr, (nint)pLineEndPtr, (nint)pContentsEndPtr, range);
    }

    public NSRange LineRangeForRange(NSRange range)
    {
        return ObjectiveC.MsgSendNSRange(NativePtr, NSStringBindings.LineRangeForRange, range);
    }

    public unsafe void GetParagraphStart(nuint[] startPtr, nuint[] parEndPtr, nuint[] contentsEndPtr, NSRange range)
    {
        nuint* pStartPtr = stackalloc nuint[startPtr.Length];
        for (int i = 0; i < startPtr.Length; i++)
        {
            pStartPtr[i] = startPtr[i];
        }

        nuint* pParEndPtr = stackalloc nuint[parEndPtr.Length];
        for (int i = 0; i < parEndPtr.Length; i++)
        {
            pParEndPtr[i] = parEndPtr[i];
        }

        nuint* pContentsEndPtr = stackalloc nuint[contentsEndPtr.Length];
        for (int i = 0; i < contentsEndPtr.Length; i++)
        {
            pContentsEndPtr[i] = contentsEndPtr[i];
        }

        ObjectiveC.MsgSend(NativePtr, NSStringBindings.GetParagraphStart_End_ContentsEnd_ForRange, (nint)pStartPtr, (nint)pParEndPtr, (nint)pContentsEndPtr, range);
    }

    public NSRange ParagraphRangeForRange(NSRange range)
    {
        return ObjectiveC.MsgSendNSRange(NativePtr, NSStringBindings.ParagraphRangeForRange, range);
    }

    public NSData DataUsingEncoding(NSStringEncoding encoding, bool lossy)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.DataUsingEncoding_AllowLossyConversion, (nuint)encoding, lossy);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSData DataUsingEncoding(NSStringEncoding encoding)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.DataUsingEncoding, (nuint)encoding);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool CanBeConvertedToEncoding(NSStringEncoding encoding)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.CanBeConvertedToEncoding, (nuint)encoding);
    }

    public nint CStringUsingEncoding(NSStringEncoding encoding)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.CStringUsingEncoding, (nuint)encoding);
    }

    public bool GetCString(nint buffer, nuint maxBufferCount, NSStringEncoding encoding)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.GetCString_MaxLength_Encoding, buffer, maxBufferCount, (nuint)encoding);
    }

    public nuint MaximumLengthOfBytesUsingEncoding(NSStringEncoding enc)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, NSStringBindings.MaximumLengthOfBytesUsingEncoding, (nuint)enc);
    }

    public nuint LengthOfBytesUsingEncoding(NSStringEncoding enc)
    {
        return ObjectiveC.MsgSendNUInt(NativePtr, NSStringBindings.LengthOfBytesUsingEncoding, (nuint)enc);
    }

    public NSString StringByPaddingToLength(nuint newLength, NSString padString, nuint padIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.StringByPaddingToLength_WithString_StartingAtIndex, newLength, padString.NativePtr, padIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString StringByReplacingOccurrencesOfString(NSString target, NSString replacement, NSStringCompareOptions options, NSRange searchRange)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.StringByReplacingOccurrencesOfString_WithString_Options_Range, target.NativePtr, replacement.NativePtr, (nuint)options, searchRange);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString StringByReplacingOccurrencesOfString(NSString target, NSString replacement)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.StringByReplacingOccurrencesOfString_WithString, target.NativePtr, replacement.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString StringByReplacingCharactersInRange(NSRange range, NSString replacement)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.StringByReplacingCharactersInRange_WithString, range, replacement.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public bool WriteToURL(NSURL url, bool useAuxiliaryFile, NSStringEncoding enc, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.WriteToURL_Atomically_Encoding_Error, url.NativePtr, useAuxiliaryFile, (nuint)enc, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool WriteToFile(NSString path, bool useAuxiliaryFile, NSStringEncoding enc, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.WriteToFile_Atomically_Encoding_Error, path.NativePtr, useAuxiliaryFile, (nuint)enc, out nint errorPtr);

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
        ObjectiveC.MsgSend(NativePtr, NSStringBindings.GetCString_MaxLength, bytes, maxLength);
    }

    public bool WriteToFile(NSString path, bool useAuxiliaryFile)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.WriteToFile_Atomically, path.NativePtr, useAuxiliaryFile);
    }

    public bool WriteToURL(NSURL url, bool atomically)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.WriteToURL_Atomically, url.NativePtr, atomically);
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

    public nuint CompletePathIntoString(NSString outputName, bool flag, NSString[] outputArray, NSString[] filterTypes)
    {
        nint pOutputArray = NSArray.FromArray(outputArray);
        nint pFilterTypes = NSArray.FromArray(filterTypes);

        return ObjectiveC.MsgSendNUInt(NativePtr, NSStringBindings.CompletePathIntoString_CaseSensitive_MatchesIntoArray_FilterTypes, outputName.NativePtr, flag, pOutputArray, pFilterTypes);
    }

    public bool GetFileSystemRepresentation(nint cname, nuint max)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSStringBindings.GetFileSystemRepresentation_MaxLength, cname, max);
    }

    public NSString StringByAddingPercentEscapesUsingEncoding(NSStringEncoding enc)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.StringByAddingPercentEscapesUsingEncoding, (nuint)enc);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public NSString StringByReplacingPercentEscapesUsingEncoding(NSStringEncoding enc)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSStringBindings.StringByReplacingPercentEscapesUsingEncoding, (nuint)enc);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSString LocalizedNameOfStringEncoding(NSStringEncoding encoding)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.LocalizedNameOfStringEncoding, (nuint)encoding);

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
        nint result = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithValidatedFormat_ValidFormatSpecifiers_Error, format.NativePtr, validFormatSpecifiers.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public static nint LocalizedStringWithValidatedFormat(NSString format, NSString validFormatSpecifiers, out NSError error)
    {
        nint result = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.LocalizedStringWithValidatedFormat_ValidFormatSpecifiers_Error, format.NativePtr, validFormatSpecifiers.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public static nint StringWithCString(nint cString, NSStringEncoding enc)
    {
        return ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithCString_Encoding, cString, (nuint)enc);
    }

    public static nint StringWithContentsOfURL(NSURL url, NSStringEncoding enc, out NSError error)
    {
        nint result = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithContentsOfURL_Encoding_Error, url.NativePtr, (nuint)enc, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public static nint StringWithContentsOfFile(NSString path, NSStringEncoding enc, out NSError error)
    {
        nint result = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithContentsOfFile_Encoding_Error, path.NativePtr, (nuint)enc, out nint errorPtr);

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

    public static NSObject StringWithCString(nint bytes, nuint length)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithCString_Length, bytes, length);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSObject StringWithCString(nint bytes)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.StringWithCString, bytes);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSString PathWithComponents(NSString[] components)
    {
        nint pComponents = NSArray.FromArray(components);

        nint nativePtr = ObjectiveC.MsgSendNInt(NSStringBindings.Class, NSStringBindings.PathWithComponents, pComponents);

        ObjectiveC.Release(pComponents);

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

    public static NSString InitWithFormat_Locale(NSString format, NSObject locale)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithFormat_Locale, format.NativePtr, locale.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithValidatedFormat_ValidFormatSpecifiers_Error(NSString format, NSString validFormatSpecifiers, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithValidatedFormat_ValidFormatSpecifiers_Error, format.NativePtr, validFormatSpecifiers.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithValidatedFormat_ValidFormatSpecifiers_Locale_Error(NSString format, NSString validFormatSpecifiers, NSObject locale, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithValidatedFormat_ValidFormatSpecifiers_Locale_Error, format.NativePtr, validFormatSpecifiers.NativePtr, locale.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithData_Encoding(NSData data, NSStringEncoding encoding)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithData_Encoding, data.NativePtr, (nuint)encoding);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithBytes_Length_Encoding(nint bytes, nuint len, NSStringEncoding encoding)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithBytes_Length_Encoding, bytes, len, (nuint)encoding);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithBytesNoCopy_Length_Encoding_FreeWhenDone(nint bytes, nuint len, NSStringEncoding encoding, bool freeBuffer)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithBytesNoCopy_Length_Encoding_FreeWhenDone, bytes, len, (nuint)encoding, freeBuffer);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithCString_Encoding(nint nullTerminatedCString, NSStringEncoding encoding)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithCString_Encoding, nullTerminatedCString, (nuint)encoding);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithContentsOfURL_Encoding_Error(NSURL url, NSStringEncoding enc, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithContentsOfURL_Encoding_Error, url.NativePtr, (nuint)enc, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithContentsOfFile_Encoding_Error(NSString path, NSStringEncoding enc, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithContentsOfFile_Encoding_Error, path.NativePtr, (nuint)enc, out nint errorPtr);

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

    public static NSString InitWithCStringNoCopy_Length_FreeWhenDone(nint bytes, nuint length, bool freeBuffer)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithCStringNoCopy_Length_FreeWhenDone, bytes, length, freeBuffer);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSString InitWithCString_Length(nint bytes, nuint length)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSStringBindings.Class), NSStringBindings.InitWithCString_Length, bytes, length);

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

    public static readonly Selector CaseInsensitiveCompare = "caseInsensitiveCompare:";

    public static readonly Selector CharacterAtIndex = "characterAtIndex:";

    public static readonly Selector CommonPrefixWithString_Options = "commonPrefixWithString:options:";

    public static readonly Selector Compare = "compare:";

    public static readonly Selector Compare_Options = "compare:options:";

    public static readonly Selector Compare_Options_Range = "compare:options:range:";

    public static readonly Selector Compare_Options_Range_Locale = "compare:options:range:locale:";

    public static readonly Selector CompletePathIntoString_CaseSensitive_MatchesIntoArray_FilterTypes = "completePathIntoString:caseSensitive:matchesIntoArray:filterTypes:";

    public static readonly Selector ContainsString = "containsString:";

    public static readonly Selector CString = "cString";

    public static readonly Selector CStringLength = "cStringLength";

    public static readonly Selector CStringUsingEncoding = "cStringUsingEncoding:";

    public static readonly Selector DataUsingEncoding = "dataUsingEncoding:";

    public static readonly Selector DataUsingEncoding_AllowLossyConversion = "dataUsingEncoding:allowLossyConversion:";

    public static readonly Selector DecomposedStringWithCanonicalMapping = "decomposedStringWithCanonicalMapping";

    public static readonly Selector DecomposedStringWithCompatibilityMapping = "decomposedStringWithCompatibilityMapping";

    public static readonly Selector DefaultCStringEncoding = "defaultCStringEncoding";

    public static readonly Selector DoubleValue = "doubleValue";

    public static readonly Selector FastestEncoding = "fastestEncoding";

    public static readonly Selector FloatValue = "floatValue";

    public static readonly Selector GetCString = "getCString:";

    public static readonly Selector GetCString_MaxLength = "getCString:maxLength:";

    public static readonly Selector GetCString_MaxLength_Encoding = "getCString:maxLength:encoding:";

    public static readonly Selector GetFileSystemRepresentation_MaxLength = "getFileSystemRepresentation:maxLength:";

    public static readonly Selector GetLineStart_End_ContentsEnd_ForRange = "getLineStart:end:contentsEnd:forRange:";

    public static readonly Selector GetParagraphStart_End_ContentsEnd_ForRange = "getParagraphStart:end:contentsEnd:forRange:";

    public static readonly Selector HasPrefix = "hasPrefix:";

    public static readonly Selector HasSuffix = "hasSuffix:";

    public static readonly Selector InitWithBytes_Length_Encoding = "initWithBytes:length:encoding:";

    public static readonly Selector InitWithBytesNoCopy_Length_Encoding_FreeWhenDone = "initWithBytesNoCopy:length:encoding:freeWhenDone:";

    public static readonly Selector InitWithContentsOfFile = "initWithContentsOfFile:";

    public static readonly Selector InitWithContentsOfFile_Encoding_Error = "initWithContentsOfFile:encoding:error:";

    public static readonly Selector InitWithContentsOfURL = "initWithContentsOfURL:";

    public static readonly Selector InitWithContentsOfURL_Encoding_Error = "initWithContentsOfURL:encoding:error:";

    public static readonly Selector InitWithCString = "initWithCString:";

    public static readonly Selector InitWithCString_Encoding = "initWithCString:encoding:";

    public static readonly Selector InitWithCString_Length = "initWithCString:length:";

    public static readonly Selector InitWithCStringNoCopy_Length_FreeWhenDone = "initWithCStringNoCopy:length:freeWhenDone:";

    public static readonly Selector InitWithData_Encoding = "initWithData:encoding:";

    public static readonly Selector InitWithFormat = "initWithFormat:";

    public static readonly Selector InitWithFormat_Locale = "initWithFormat:locale:";

    public static readonly Selector InitWithString = "initWithString:";

    public static readonly Selector InitWithUTF8String = "initWithUTF8String:";

    public static readonly Selector InitWithValidatedFormat_ValidFormatSpecifiers_Error = "initWithValidatedFormat:validFormatSpecifiers:error:";

    public static readonly Selector InitWithValidatedFormat_ValidFormatSpecifiers_Locale_Error = "initWithValidatedFormat:validFormatSpecifiers:locale:error:";

    public static readonly Selector IntegerValue = "integerValue";

    public static readonly Selector IntValue = "intValue";

    public static readonly Selector IsAbsolutePath = "isAbsolutePath";

    public static readonly Selector IsEqualToString = "isEqualToString:";

    public static readonly Selector LastPathComponent = "lastPathComponent";

    public static readonly Selector Length = "length";

    public static readonly Selector LengthOfBytesUsingEncoding = "lengthOfBytesUsingEncoding:";

    public static readonly Selector LineRangeForRange = "lineRangeForRange:";

    public static readonly Selector LocalizedCapitalizedString = "localizedCapitalizedString";

    public static readonly Selector LocalizedCaseInsensitiveCompare = "localizedCaseInsensitiveCompare:";

    public static readonly Selector LocalizedCaseInsensitiveContainsString = "localizedCaseInsensitiveContainsString:";

    public static readonly Selector LocalizedCompare = "localizedCompare:";

    public static readonly Selector LocalizedLowercaseString = "localizedLowercaseString";

    public static readonly Selector LocalizedNameOfStringEncoding = "localizedNameOfStringEncoding:";

    public static readonly Selector LocalizedStandardCompare = "localizedStandardCompare:";

    public static readonly Selector LocalizedStandardContainsString = "localizedStandardContainsString:";

    public static readonly Selector LocalizedStandardRangeOfString = "localizedStandardRangeOfString:";

    public static readonly Selector LocalizedStringWithFormat = "localizedStringWithFormat:";

    public static readonly Selector LocalizedStringWithValidatedFormat_ValidFormatSpecifiers_Error = "localizedStringWithValidatedFormat:validFormatSpecifiers:error:";

    public static readonly Selector LocalizedUppercaseString = "localizedUppercaseString";

    public static readonly Selector LongLongValue = "longLongValue";

    public static readonly Selector LossyCString = "lossyCString";

    public static readonly Selector LowercaseString = "lowercaseString";

    public static readonly Selector MaximumLengthOfBytesUsingEncoding = "maximumLengthOfBytesUsingEncoding:";

    public static readonly Selector ParagraphRangeForRange = "paragraphRangeForRange:";

    public static readonly Selector PathExtension = "pathExtension";

    public static readonly Selector PathWithComponents = "pathWithComponents:";

    public static readonly Selector PrecomposedStringWithCanonicalMapping = "precomposedStringWithCanonicalMapping";

    public static readonly Selector PrecomposedStringWithCompatibilityMapping = "precomposedStringWithCompatibilityMapping";

    public static readonly Selector PropertyList = "propertyList";

    public static readonly Selector PropertyListFromStringsFileFormat = "propertyListFromStringsFileFormat";

    public static readonly Selector RangeOfComposedCharacterSequenceAtIndex = "rangeOfComposedCharacterSequenceAtIndex:";

    public static readonly Selector RangeOfComposedCharacterSequencesForRange = "rangeOfComposedCharacterSequencesForRange:";

    public static readonly Selector RangeOfString = "rangeOfString:";

    public static readonly Selector RangeOfString_Options = "rangeOfString:options:";

    public static readonly Selector RangeOfString_Options_Range = "rangeOfString:options:range:";

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

    public static readonly Selector StringByPaddingToLength_WithString_StartingAtIndex = "stringByPaddingToLength:withString:startingAtIndex:";

    public static readonly Selector StringByRemovingPercentEncoding = "stringByRemovingPercentEncoding";

    public static readonly Selector StringByReplacingCharactersInRange_WithString = "stringByReplacingCharactersInRange:withString:";

    public static readonly Selector StringByReplacingOccurrencesOfString_WithString = "stringByReplacingOccurrencesOfString:withString:";

    public static readonly Selector StringByReplacingOccurrencesOfString_WithString_Options_Range = "stringByReplacingOccurrencesOfString:withString:options:range:";

    public static readonly Selector StringByReplacingPercentEscapesUsingEncoding = "stringByReplacingPercentEscapesUsingEncoding:";

    public static readonly Selector StringByResolvingSymlinksInPath = "stringByResolvingSymlinksInPath";

    public static readonly Selector StringByStandardizingPath = "stringByStandardizingPath";

    public static readonly Selector StringWithContentsOfFile = "stringWithContentsOfFile:";

    public static readonly Selector StringWithContentsOfFile_Encoding_Error = "stringWithContentsOfFile:encoding:error:";

    public static readonly Selector StringWithContentsOfURL = "stringWithContentsOfURL:";

    public static readonly Selector StringWithContentsOfURL_Encoding_Error = "stringWithContentsOfURL:encoding:error:";

    public static readonly Selector StringWithCString = "stringWithCString:";

    public static readonly Selector StringWithCString_Encoding = "stringWithCString:encoding:";

    public static readonly Selector StringWithCString_Length = "stringWithCString:length:";

    public static readonly Selector StringWithFormat = "stringWithFormat:";

    public static readonly Selector StringWithString = "stringWithString:";

    public static readonly Selector StringWithUTF8String = "stringWithUTF8String:";

    public static readonly Selector StringWithValidatedFormat_ValidFormatSpecifiers_Error = "stringWithValidatedFormat:validFormatSpecifiers:error:";

    public static readonly Selector SubstringFromIndex = "substringFromIndex:";

    public static readonly Selector SubstringToIndex = "substringToIndex:";

    public static readonly Selector SubstringWithRange = "substringWithRange:";

    public static readonly Selector UppercaseString = "uppercaseString";

    public static readonly Selector VariantFittingPresentationWidth = "variantFittingPresentationWidth:";

    public static readonly Selector WriteToFile_Atomically = "writeToFile:atomically:";

    public static readonly Selector WriteToFile_Atomically_Encoding_Error = "writeToFile:atomically:encoding:error:";

    public static readonly Selector WriteToURL_Atomically = "writeToURL:atomically:";

    public static readonly Selector WriteToURL_Atomically_Encoding_Error = "writeToURL:atomically:encoding:error:";
}
