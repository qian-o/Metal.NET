namespace Metal.NET;

public partial class NSNumber(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSNumber>
{
    #region INativeObject
    public static new NSNumber Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSNumber New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSNumber() : this(ObjectiveC.AllocInit(NSNumberBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public sbyte CharValue
    {
        get => (sbyte)ObjectiveC.MsgSendNInt(NativePtr, NSNumberBindings.CharValue);
    }

    public byte UnsignedCharValue
    {
        get => (byte)ObjectiveC.MsgSendNInt(NativePtr, NSNumberBindings.UnsignedCharValue);
    }

    public short ShortValue
    {
        get => (short)ObjectiveC.MsgSendNInt(NativePtr, NSNumberBindings.ShortValue);
    }

    public ushort UnsignedShortValue
    {
        get => (ushort)ObjectiveC.MsgSendNInt(NativePtr, NSNumberBindings.UnsignedShortValue);
    }

    public int IntValue
    {
        get => ObjectiveC.MsgSendInt(NativePtr, NSNumberBindings.IntValue);
    }

    public uint UnsignedIntValue
    {
        get => ObjectiveC.MsgSendUInt(NativePtr, NSNumberBindings.UnsignedIntValue);
    }

    public nint LongValue
    {
        get => ObjectiveC.MsgSendNInt(NativePtr, NSNumberBindings.LongValue);
    }

    public nuint UnsignedLongValue
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, NSNumberBindings.UnsignedLongValue);
    }

    public long LongLongValue
    {
        get => ObjectiveC.MsgSendLong(NativePtr, NSNumberBindings.LongLongValue);
    }

    public ulong UnsignedLongLongValue
    {
        get => ObjectiveC.MsgSendULong(NativePtr, NSNumberBindings.UnsignedLongLongValue);
    }

    public float FloatValue
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, NSNumberBindings.FloatValue);
    }

    public double DoubleValue
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, NSNumberBindings.DoubleValue);
    }

    public Bool8 BoolValue
    {
        get => ObjectiveC.MsgSendBool(NativePtr, NSNumberBindings.BoolValue);
    }

    public nint IntegerValue
    {
        get => ObjectiveC.MsgSendNInt(NativePtr, NSNumberBindings.IntegerValue);
    }

    public nuint UnsignedIntegerValue
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, NSNumberBindings.UnsignedIntegerValue);
    }

    public NSString StringValue
    {
        get => GetProperty(ref field, NSNumberBindings.StringValue);
    }

    public NSComparisonResult Compare(NSNumber otherNumber)
    {
        return (NSComparisonResult)ObjectiveC.MsgSendLong(NativePtr, NSNumberBindings.Compare, otherNumber.NativePtr);
    }

    public bool IsEqualToNumber(NSNumber number)
    {
        return ObjectiveC.MsgSendBool(NativePtr, NSNumberBindings.IsEqualToNumber, number.NativePtr);
    }

    public NSString DescriptionWithLocale(NSObject locale)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSNumberBindings.DescriptionWithLocale, locale.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithChar(sbyte value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithChar, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithUnsignedChar(byte value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithUnsignedChar, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithShort(short value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithShort, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithUnsignedShort(ushort value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithUnsignedShort, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithInt(int value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithInt, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithUnsignedInt(uint value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithUnsignedInt, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithLong(nint value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithLong, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithUnsignedLong(nuint value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithUnsignedLong, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithLongLong(long value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithLongLong, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithUnsignedLongLong(ulong value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithUnsignedLongLong, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithFloat(float value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithFloat, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithDouble(double value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithDouble, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithBool(bool value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithBool, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithInteger(nint value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithInteger, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithUnsignedInteger(nuint value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithUnsignedInteger, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static NSNumber InitWithChar(sbyte value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithChar, value);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSNumber InitWithUnsignedChar(byte value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithUnsignedChar, value);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSNumber InitWithShort(short value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithShort, value);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSNumber InitWithUnsignedShort(ushort value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithUnsignedShort, value);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSNumber InitWithInt(int value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithInt, value);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSNumber InitWithUnsignedInt(uint value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithUnsignedInt, value);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSNumber InitWithLong(nint value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithLong, value);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSNumber InitWithUnsignedLong(nuint value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithUnsignedLong, value);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSNumber InitWithLongLong(long value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithLongLong, value);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSNumber InitWithUnsignedLongLong(ulong value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithUnsignedLongLong, value);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSNumber InitWithFloat(float value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithFloat, value);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSNumber InitWithDouble(double value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithDouble, value);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSNumber InitWithBool(bool value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithBool, value);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSNumber InitWithInteger(nint value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithInteger, value);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }

    public static NSNumber InitWithUnsignedInteger(nuint value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithUnsignedInteger, value);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }
}

file static class NSNumberBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSNumber");

    public static readonly Selector BoolValue = "boolValue";

    public static readonly Selector CharValue = "charValue";

    public static readonly Selector Compare = "compare:";

    public static readonly Selector DescriptionWithLocale = "descriptionWithLocale:";

    public static readonly Selector DoubleValue = "doubleValue";

    public static readonly Selector FloatValue = "floatValue";

    public static readonly Selector InitWithBool = "initWithBool:";

    public static readonly Selector InitWithChar = "initWithChar:";

    public static readonly Selector InitWithDouble = "initWithDouble:";

    public static readonly Selector InitWithFloat = "initWithFloat:";

    public static readonly Selector InitWithInt = "initWithInt:";

    public static readonly Selector InitWithInteger = "initWithInteger:";

    public static readonly Selector InitWithLong = "initWithLong:";

    public static readonly Selector InitWithLongLong = "initWithLongLong:";

    public static readonly Selector InitWithShort = "initWithShort:";

    public static readonly Selector InitWithUnsignedChar = "initWithUnsignedChar:";

    public static readonly Selector InitWithUnsignedInt = "initWithUnsignedInt:";

    public static readonly Selector InitWithUnsignedInteger = "initWithUnsignedInteger:";

    public static readonly Selector InitWithUnsignedLong = "initWithUnsignedLong:";

    public static readonly Selector InitWithUnsignedLongLong = "initWithUnsignedLongLong:";

    public static readonly Selector InitWithUnsignedShort = "initWithUnsignedShort:";

    public static readonly Selector IntegerValue = "integerValue";

    public static readonly Selector IntValue = "intValue";

    public static readonly Selector IsEqualToNumber = "isEqualToNumber:";

    public static readonly Selector LongLongValue = "longLongValue";

    public static readonly Selector LongValue = "longValue";

    public static readonly Selector NumberWithBool = "numberWithBool:";

    public static readonly Selector NumberWithChar = "numberWithChar:";

    public static readonly Selector NumberWithDouble = "numberWithDouble:";

    public static readonly Selector NumberWithFloat = "numberWithFloat:";

    public static readonly Selector NumberWithInt = "numberWithInt:";

    public static readonly Selector NumberWithInteger = "numberWithInteger:";

    public static readonly Selector NumberWithLong = "numberWithLong:";

    public static readonly Selector NumberWithLongLong = "numberWithLongLong:";

    public static readonly Selector NumberWithShort = "numberWithShort:";

    public static readonly Selector NumberWithUnsignedChar = "numberWithUnsignedChar:";

    public static readonly Selector NumberWithUnsignedInt = "numberWithUnsignedInt:";

    public static readonly Selector NumberWithUnsignedInteger = "numberWithUnsignedInteger:";

    public static readonly Selector NumberWithUnsignedLong = "numberWithUnsignedLong:";

    public static readonly Selector NumberWithUnsignedLongLong = "numberWithUnsignedLongLong:";

    public static readonly Selector NumberWithUnsignedShort = "numberWithUnsignedShort:";

    public static readonly Selector ShortValue = "shortValue";

    public static readonly Selector StringValue = "stringValue";

    public static readonly Selector UnsignedCharValue = "unsignedCharValue";

    public static readonly Selector UnsignedIntegerValue = "unsignedIntegerValue";

    public static readonly Selector UnsignedIntValue = "unsignedIntValue";

    public static readonly Selector UnsignedLongLongValue = "unsignedLongLongValue";

    public static readonly Selector UnsignedLongValue = "unsignedLongValue";

    public static readonly Selector UnsignedShortValue = "unsignedShortValue";
}
