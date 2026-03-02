namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSNumber for numeric value boxing.
/// </summary>
public class NSNumber(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSNumber>
{
    public static NSNumber Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSNumber Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    /// <summary>
    /// Gets the integer value of the number.
    /// </summary>
    public nint IntegerValue
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSNumberBindings.IntegerValue);
    }

    /// <summary>
    /// Gets the unsigned integer value of the number.
    /// </summary>
    public nuint UnsignedIntegerValue
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSNumberBindings.UnsignedIntegerValue);
    }

    /// <summary>
    /// Gets the float value of the number.
    /// </summary>
    public float FloatValue
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, NSNumberBindings.FloatValue);
    }

    /// <summary>
    /// Gets the double value of the number.
    /// </summary>
    public double DoubleValue
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, NSNumberBindings.DoubleValue);
    }

    /// <summary>
    /// Gets the boolean value of the number.
    /// </summary>
    public bool BoolValue
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, NSNumberBindings.BoolValue);
    }

    /// <summary>
    /// Creates an NSNumber from an integer value.
    /// </summary>
    public static NSNumber FromInteger(nint value)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NSNumberBindings.Class, NSNumberBindings.NumberWithInteger, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates an NSNumber from an unsigned integer value.
    /// </summary>
    public static NSNumber FromUnsignedInteger(nuint value)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NSNumberBindings.Class, NSNumberBindings.NumberWithUnsignedInteger, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates an NSNumber from a float value.
    /// </summary>
    public static NSNumber FromFloat(float value)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NSNumberBindings.Class, NSNumberBindings.NumberWithFloat, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates an NSNumber from a double value.
    /// </summary>
    public static NSNumber FromDouble(double value)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NSNumberBindings.Class, NSNumberBindings.NumberWithDouble, value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates an NSNumber from a boolean value.
    /// </summary>
    public static NSNumber FromBool(bool value)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NSNumberBindings.Class, NSNumberBindings.NumberWithBool, (Bool8)value);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class NSNumberBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSNumber");

    public static readonly Selector IntegerValue = "integerValue";

    public static readonly Selector UnsignedIntegerValue = "unsignedIntegerValue";

    public static readonly Selector FloatValue = "floatValue";

    public static readonly Selector DoubleValue = "doubleValue";

    public static readonly Selector BoolValue = "boolValue";

    public static readonly Selector NumberWithInteger = "numberWithInteger:";

    public static readonly Selector NumberWithUnsignedInteger = "numberWithUnsignedInteger:";

    public static readonly Selector NumberWithFloat = "numberWithFloat:";

    public static readonly Selector NumberWithDouble = "numberWithDouble:";

    public static readonly Selector NumberWithBool = "numberWithBool:";
}
