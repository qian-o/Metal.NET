namespace Metal.NET;

public partial class NSNumber
{
    public static implicit operator NSNumber(bool value)
    {
        return new(ObjectiveC.MsgSendNInt(NSNumberInteropBindings.Class, NSNumberInteropBindings.NumberWithBool, value), NativeObjectOwnership.Managed);
    }

    public static implicit operator NSNumber(int value)
    {
        return new(ObjectiveC.MsgSendNInt(NSNumberInteropBindings.Class, NSNumberInteropBindings.NumberWithInt, value), NativeObjectOwnership.Managed);
    }

    public static implicit operator NSNumber(uint value)
    {
        return new(ObjectiveC.MsgSendNInt(NSNumberInteropBindings.Class, NSNumberInteropBindings.NumberWithUnsignedInt, value), NativeObjectOwnership.Managed);
    }

    public static implicit operator NSNumber(long value)
    {
        return new(ObjectiveC.MsgSendNInt(NSNumberInteropBindings.Class, NSNumberInteropBindings.NumberWithLongLong, value), NativeObjectOwnership.Managed);
    }

    public static implicit operator NSNumber(ulong value)
    {
        return new(ObjectiveC.MsgSendNInt(NSNumberInteropBindings.Class, NSNumberInteropBindings.NumberWithUnsignedLongLong, value), NativeObjectOwnership.Managed);
    }

    public static implicit operator NSNumber(float value)
    {
        return new(ObjectiveC.MsgSendNInt(NSNumberInteropBindings.Class, NSNumberInteropBindings.NumberWithFloat, value), NativeObjectOwnership.Managed);
    }

    public static implicit operator NSNumber(double value)
    {
        return new(ObjectiveC.MsgSendNInt(NSNumberInteropBindings.Class, NSNumberInteropBindings.NumberWithDouble, value), NativeObjectOwnership.Managed);
    }

    public static implicit operator bool(NSNumber value) => value.BoolValue;

    public static implicit operator int(NSNumber value) => value.IntValue;

    public static implicit operator uint(NSNumber value) => value.UnsignedIntValue;

    public static implicit operator long(NSNumber value) => value.LongLongValue;

    public static implicit operator ulong(NSNumber value) => value.UnsignedLongLongValue;

    public static implicit operator float(NSNumber value) => value.FloatValue;

    public static implicit operator double(NSNumber value) => value.DoubleValue;
}

file static class NSNumberInteropBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSNumber");

    public static readonly Selector NumberWithBool = "numberWithBool:";

    public static readonly Selector NumberWithInt = "numberWithInt:";

    public static readonly Selector NumberWithUnsignedInt = "numberWithUnsignedInt:";

    public static readonly Selector NumberWithLongLong = "numberWithLongLong:";

    public static readonly Selector NumberWithUnsignedLongLong = "numberWithUnsignedLongLong:";

    public static readonly Selector NumberWithFloat = "numberWithFloat:";

    public static readonly Selector NumberWithDouble = "numberWithDouble:";
}
