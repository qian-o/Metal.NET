namespace Metal.NET;

public enum NSComparisonResult : long
{
    Ascending = -1,

    Same = 0,

    Descending = 1
}

[Flags]
public enum NSStringCompareOptions : ulong
{
    CaseInsensitiveSearch = 1,

    LiteralSearch = 2,

    BackwardsSearch = 4,

    AnchoredSearch = 8,

    NumericSearch = 64,

    DiacriticInsensitiveSearch = 128,

    WidthInsensitiveSearch = 256,

    ForcedOrderingSearch = 512,

    RegularExpressionSearch = 1024
}

public enum NSStringEncoding : ulong
{
    ASCIIStringEncoding = 1,

    NEXTSTEPStringEncoding = 2,

    JapaneseEUCStringEncoding = 3,

    UTF8StringEncoding = 4,

    ISOLatin1StringEncoding = 5,

    SymbolStringEncoding = 6,

    NonLossyASCIIStringEncoding = 7,

    ShiftJISStringEncoding = 8,

    ISOLatin2StringEncoding = 9,

    UnicodeStringEncoding = 10,

    WindowsCP1251StringEncoding = 11,

    WindowsCP1252StringEncoding = 12,

    WindowsCP1253StringEncoding = 13,

    WindowsCP1254StringEncoding = 14,

    WindowsCP1250StringEncoding = 15,

    ISO2022JPStringEncoding = 21,

    MacOSRomanStringEncoding = 30,

    UTF16StringEncoding = 10,

    UTF16BigEndianStringEncoding = 2415919360,

    UTF16LittleEndianStringEncoding = 2483028224,

    UTF32StringEncoding = 2348810496,

    UTF32BigEndianStringEncoding = 2550137088,

    UTF32LittleEndianStringEncoding = 2617245952
}
