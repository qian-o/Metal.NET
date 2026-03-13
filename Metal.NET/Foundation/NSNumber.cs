namespace Metal.NET;

public class NSNumber(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSNumber>
{
    #region INativeObject
    public static new NSNumber Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSNumber New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public bool BoolValue
    {
        get => ObjectiveC.MsgSendBool(NativePtr, NSNumberBindings.BoolValue);
    }

    public int IntValue
    {
        get => ObjectiveC.MsgSendInt(NativePtr, NSNumberBindings.IntValue);
    }

    public uint UnsignedIntValue
    {
        get => ObjectiveC.MsgSendUInt(NativePtr, NSNumberBindings.UnsignedIntValue);
    }

    public long LongValue
    {
        get => ObjectiveC.MsgSendLong(NativePtr, NSNumberBindings.LongLongValue);
    }

    public ulong UnsignedLongValue
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

    public nint IntegerValue
    {
        get => ObjectiveC.MsgSendNInt(NativePtr, NSNumberBindings.IntegerValue);
    }

    public nuint UnsignedIntegerValue
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, NSNumberBindings.UnsignedIntegerValue);
    }

    public static implicit operator NSNumber(bool value)
    {
        return new(ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithBool, value), NativeObjectOwnership.Managed);
    }

    public static implicit operator NSNumber(int value)
    {
        return new(ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithInt, value), NativeObjectOwnership.Managed);
    }

    public static implicit operator NSNumber(uint value)
    {
        return new(ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithUnsignedInt, value), NativeObjectOwnership.Managed);
    }

    public static implicit operator NSNumber(long value)
    {
        return new(ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithLongLong, value), NativeObjectOwnership.Managed);
    }

    public static implicit operator NSNumber(ulong value)
    {
        return new(ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithUnsignedLongLong, value), NativeObjectOwnership.Managed);
    }

    public static implicit operator NSNumber(float value)
    {
        return new(ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithFloat, value), NativeObjectOwnership.Managed);
    }

    public static implicit operator NSNumber(double value)
    {
        return new(ObjectiveC.MsgSendNInt(NSNumberBindings.Class, NSNumberBindings.NumberWithDouble, value), NativeObjectOwnership.Managed);
    }

    public static implicit operator bool(NSNumber value) => value.BoolValue;

    public static implicit operator int(NSNumber value) => value.IntValue;

    public static implicit operator uint(NSNumber value) => value.UnsignedIntValue;

    public static implicit operator long(NSNumber value) => value.LongValue;

    public static implicit operator ulong(NSNumber value) => value.UnsignedLongValue;

    public static implicit operator float(NSNumber value) => value.FloatValue;

    public static implicit operator double(NSNumber value) => value.DoubleValue;
}

file static class NSNumberBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSNumber");

    public static readonly Selector BoolValue = "boolValue";

    public static readonly Selector IntValue = "intValue";

    public static readonly Selector UnsignedIntValue = "unsignedIntValue";

    public static readonly Selector LongLongValue = "longLongValue";

    public static readonly Selector UnsignedLongLongValue = "unsignedLongLongValue";

    public static readonly Selector FloatValue = "floatValue";

    public static readonly Selector DoubleValue = "doubleValue";

    public static readonly Selector IntegerValue = "integerValue";

    public static readonly Selector UnsignedIntegerValue = "unsignedIntegerValue";

    public static readonly Selector NumberWithBool = "numberWithBool:";

    public static readonly Selector NumberWithInt = "numberWithInt:";

    public static readonly Selector NumberWithUnsignedInt = "numberWithUnsignedInt:";

    public static readonly Selector NumberWithLongLong = "numberWithLongLong:";

    public static readonly Selector NumberWithUnsignedLongLong = "numberWithUnsignedLongLong:";

    public static readonly Selector NumberWithFloat = "numberWithFloat:";

    public static readonly Selector NumberWithDouble = "numberWithDouble:";
}
