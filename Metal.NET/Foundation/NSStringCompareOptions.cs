namespace Metal.NET;

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
