namespace Metal.NET;

public class MTLFunctionConstantValues(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFunctionConstantValues>
{
    public static MTLFunctionConstantValues Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLFunctionConstantValues Null => new(0, false);

    public MTLFunctionConstantValues() : this(ObjectiveCRuntime.AllocInit(MTLFunctionConstantValuesBindings.Class), true)
    {
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.Reset);
    }

    public void SetConstantValue(nint value, MTLDataType type, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.SetConstantValue, value, (nuint)type, index);
    }

    public void SetConstantValue(nint value, MTLDataType type, NSString name)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.SetConstantValuetypewithName, value, (nuint)type, name.NativePtr);
    }

    public void SetConstantValues(nint values, MTLDataType type, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.SetConstantValues, values, (nuint)type, range);
    }
}

file static class MTLFunctionConstantValuesBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionConstantValues");

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetConstantValue = "setConstantValue:type:atIndex:";

    public static readonly Selector SetConstantValues = "setConstantValues:type:withRange:";

    public static readonly Selector SetConstantValuetypewithName = "setConstantValue:type:withName:";
}
