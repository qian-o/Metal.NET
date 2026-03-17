namespace Metal.NET;

/// <summary>
/// A set of constant values that specialize a graphics or compute GPU function.
/// </summary>
public class MTLFunctionConstantValues(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionConstantValues>
{
    #region INativeObject
    public static new MTLFunctionConstantValues Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionConstantValues New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFunctionConstantValues() : this(ObjectiveC.AllocInit(MTLFunctionConstantValuesBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Setting constant values - Methods

    /// <summary>
    /// Sets a value for a function constant at a specific index.
    /// </summary>
    public void SetConstantValue(nint value, MTLDataType type, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.SetConstantValue, value, (nuint)type, index);
    }

    /// <summary>
    /// Sets a value for a function constant at a specific index.
    /// </summary>
    public void SetConstantValue(nint value, MTLDataType type, NSString name)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.SetConstantValuetypewithName, value, (nuint)type, name.NativePtr);
    }

    /// <summary>
    /// Sets values for a group of function constants within a specific index range.
    /// </summary>
    public void SetConstantValues(nint values, MTLDataType type, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.SetConstantValues, values, (nuint)type, range);
    }
    #endregion

    #region Resetting constant values - Methods

    /// <summary>
    /// Deletes all previously set constant values.
    /// </summary>
    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.Reset);
    }
    #endregion
}

file static class MTLFunctionConstantValuesBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionConstantValues");

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetConstantValue = "setConstantValue:type:atIndex:";

    public static readonly Selector SetConstantValues = "setConstantValues:type:withRange:";

    public static readonly Selector SetConstantValuetypewithName = "setConstantValue:type:withName:";
}
