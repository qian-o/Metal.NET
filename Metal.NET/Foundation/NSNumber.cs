namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSNumber for numeric value boxing and unboxing.
/// </summary>
public class NSNumber(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSNumber>
{
    public static NSNumber Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSNumber Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public bool BoolValue
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, NSNumberBindings.BoolValue);
    }

    public int IntValue
    {
        get => ObjectiveCRuntime.MsgSendInt(NativePtr, NSNumberBindings.IntValue);
    }

    public uint UnsignedIntValue
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, NSNumberBindings.UnsignedIntValue);
    }

    public long LongValue
    {
        get => (long)ObjectiveCRuntime.MsgSendPtr(NativePtr, NSNumberBindings.LongLongValue);
    }

    public ulong UnsignedLongValue
    {
        get => (ulong)ObjectiveCRuntime.MsgSendPtr(NativePtr, NSNumberBindings.UnsignedLongLongValue);
    }

    public float FloatValue
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, NSNumberBindings.FloatValue);
    }

    public double DoubleValue
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, NSNumberBindings.DoubleValue);
    }

    public nint IntegerValue
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSNumberBindings.IntegerValue);
    }

    public nuint UnsignedIntegerValue
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSNumberBindings.UnsignedIntegerValue);
    }

    public NSString StringValue
    {
        get => GetProperty(ref field, NSNumberBindings.StringValue);
    }

    public static NSNumber NumberWithBool(bool value)
    {
        return new(ObjectiveCRuntime.MsgSendPtr(NSNumberBindings.Class, NSNumberBindings.NumberWithBool, (Bool8)value), NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithInt(int value)
    {
        return new(ObjectiveCRuntime.MsgSendPtr(NSNumberBindings.Class, NSNumberBindings.NumberWithInt, value), NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithUnsignedInt(uint value)
    {
        return new(ObjectiveCRuntime.MsgSendPtr(NSNumberBindings.Class, NSNumberBindings.NumberWithUnsignedInt, value), NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithLong(long value)
    {
        return new(ObjectiveCRuntime.MsgSendPtr(NSNumberBindings.Class, NSNumberBindings.NumberWithLongLong, (nint)value), NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithUnsignedLong(ulong value)
    {
        return new(ObjectiveCRuntime.MsgSendPtr(NSNumberBindings.Class, NSNumberBindings.NumberWithUnsignedLongLong, (nint)value), NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithFloat(float value)
    {
        return new(ObjectiveCRuntime.MsgSendPtr(NSNumberBindings.Class, NSNumberBindings.NumberWithFloat, value), NativeObjectOwnership.Owned);
    }

    public static NSNumber NumberWithDouble(double value)
    {
        return new(ObjectiveCRuntime.MsgSendPtr(NSNumberBindings.Class, NSNumberBindings.NumberWithDouble, value), NativeObjectOwnership.Owned);
    }

    public static implicit operator NSNumber(int value) => NumberWithInt(value);

    public static implicit operator NSNumber(uint value) => NumberWithUnsignedInt(value);

    public static implicit operator NSNumber(long value) => NumberWithLong(value);

    public static implicit operator NSNumber(ulong value) => NumberWithUnsignedLong(value);

    public static implicit operator NSNumber(float value) => NumberWithFloat(value);

    public static implicit operator NSNumber(double value) => NumberWithDouble(value);

    public static implicit operator NSNumber(bool value) => NumberWithBool(value);

    public override string ToString()
    {
        return StringValue.Value;
    }
}

file static class NSNumberBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSNumber");

    public static readonly Selector BoolValue = "boolValue";

    public static readonly Selector IntValue = "intValue";

    public static readonly Selector UnsignedIntValue = "unsignedIntValue";

    public static readonly Selector LongLongValue = "longLongValue";

    public static readonly Selector UnsignedLongLongValue = "unsignedLongLongValue";

    public static readonly Selector FloatValue = "floatValue";

    public static readonly Selector DoubleValue = "doubleValue";

    public static readonly Selector IntegerValue = "integerValue";

    public static readonly Selector UnsignedIntegerValue = "unsignedIntegerValue";

    public static readonly Selector StringValue = "stringValue";

    public static readonly Selector NumberWithBool = "numberWithBool:";

    public static readonly Selector NumberWithInt = "numberWithInt:";

    public static readonly Selector NumberWithUnsignedInt = "numberWithUnsignedInt:";

    public static readonly Selector NumberWithLongLong = "numberWithLongLong:";

    public static readonly Selector NumberWithUnsignedLongLong = "numberWithUnsignedLongLong:";

    public static readonly Selector NumberWithFloat = "numberWithFloat:";

    public static readonly Selector NumberWithDouble = "numberWithDouble:";
}
