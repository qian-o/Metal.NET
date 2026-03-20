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

    public void SetConstantValue(nint value, MTLDataType type, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.SetConstantValue_Type_AtIndex, value, (nuint)type, index);
    }

    public void SetConstantValues(nint values, MTLDataType type, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.SetConstantValues_Type_WithRange, values, (nuint)type, range);
    }

    public void SetConstantValue(nint value, MTLDataType type, NSString name)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.SetConstantValue_Type_WithName, value, (nuint)type, name.NativePtr);
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

    public static readonly Selector SetConstantValue_Type_AtIndex = "setConstantValue:type:atIndex:";

    public static readonly Selector SetConstantValue_Type_WithName = "setConstantValue:type:withName:";

    public static readonly Selector SetConstantValues_Type_WithRange = "setConstantValues:type:withRange:";
}
