namespace Metal.NET;

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

    public void SetConstantValueTypeAtIndex(nint value, MTLDataType type, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.SetConstantValue, value, (nuint)type, index);
    }

    public void SetConstantValue(nint value, MTLDataType type, nuint index)
    {
        SetConstantValueTypeAtIndex(value, type, index);
    }

    public void SetConstantValuesTypeWithRange(nint values, MTLDataType type, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.SetConstantValues, values, (nuint)type, range);
    }

    public void SetConstantValues(nint values, MTLDataType type, NSRange range)
    {
        SetConstantValuesTypeWithRange(values, type, range);
    }

    public void SetConstantValueTypeWithName(nint value, MTLDataType type, NSString name)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.SetConstantValueTypeWithName, value, (nuint)type, name.NativePtr);
    }

    public void SetConstantValue(nint value, MTLDataType type, NSString name)
    {
        SetConstantValueTypeWithName(value, type, name);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.Reset);
    }
}

file static class MTLFunctionConstantValuesBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionConstantValues");

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetConstantValue = "setConstantValue:type:atIndex:";

    public static readonly Selector SetConstantValues = "setConstantValues:type:withRange:";

    public static readonly Selector SetConstantValueTypeWithName = "setConstantValue:type:withName:";
}
