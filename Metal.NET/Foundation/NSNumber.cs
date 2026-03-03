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
}

file static class NSNumberBindings
{
    public static readonly Selector BoolValue = "boolValue";

    public static readonly Selector IntValue = "intValue";

    public static readonly Selector UnsignedIntValue = "unsignedIntValue";

    public static readonly Selector LongLongValue = "longLongValue";

    public static readonly Selector UnsignedLongLongValue = "unsignedLongLongValue";

    public static readonly Selector FloatValue = "floatValue";

    public static readonly Selector DoubleValue = "doubleValue";

    public static readonly Selector IntegerValue = "integerValue";

    public static readonly Selector UnsignedIntegerValue = "unsignedIntegerValue";
}
