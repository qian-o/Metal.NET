namespace Metal.NET;

public readonly struct NSNumber(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(NSNumber value) => new(value.NativePtr);

    public NSNumber(bool value) : this(ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithBool, value))
    {
    }

    public NSNumber(int value) : this(ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithInt, value))
    {
    }

    public NSNumber(uint value) : this(ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithUnsignedInt, value))
    {
    }

    public NSNumber(long value) : this(ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithLongLong, value))
    {
    }

    public NSNumber(ulong value) : this(ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithUnsignedLongLong, value))
    {
    }

    public NSNumber(float value) : this(ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithFloat, value))
    {
    }

    public NSNumber(double value) : this(ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSNumberBindings.Class), NSNumberBindings.InitWithDouble, value))
    {
    }

    public NSNumber Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

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

    public static implicit operator bool(NSNumber value)
    {
        return value.BoolValue;
    }

    public static implicit operator int(NSNumber value)
    {
        return value.IntValue;
    }

    public static implicit operator uint(NSNumber value)
    {
        return value.UnsignedIntValue;
    }

    public static implicit operator long(NSNumber value)
    {
        return value.LongLongValue;
    }

    public static implicit operator ulong(NSNumber value)
    {
        return value.UnsignedLongLongValue;
    }

    public static implicit operator float(NSNumber value)
    {
        return value.FloatValue;
    }

    public static implicit operator double(NSNumber value)
    {
        return value.DoubleValue;
    }
}

file static class NSNumberBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSNumber");

    public static readonly Selector BoolValue = "boolValue";

    public static readonly Selector DoubleValue = "doubleValue";

    public static readonly Selector FloatValue = "floatValue";

    public static readonly Selector InitWithBool = "initWithBool:";

    public static readonly Selector InitWithDouble = "initWithDouble:";

    public static readonly Selector InitWithFloat = "initWithFloat:";

    public static readonly Selector InitWithInt = "initWithInt:";

    public static readonly Selector InitWithLongLong = "initWithLongLong:";

    public static readonly Selector InitWithUnsignedInt = "initWithUnsignedInt:";

    public static readonly Selector InitWithUnsignedLongLong = "initWithUnsignedLongLong:";

    public static readonly Selector IntValue = "intValue";

    public static readonly Selector LongLongValue = "longLongValue";

    public static readonly Selector UnsignedIntValue = "unsignedIntValue";

    public static readonly Selector UnsignedLongLongValue = "unsignedLongLongValue";
}
