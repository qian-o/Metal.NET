namespace Metal.NET;

public class MTLFunctionConstantValues(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFunctionConstantValues() : this(ObjectiveCRuntime.AllocInit(MTLFunctionConstantValuesSelector.Class))
    {
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesSelector.Reset);
    }

    public void SetConstantValue(nint value, MTLDataType type, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesSelector.SetConstantValue, value, (nuint)type, index);
    }

    public void SetConstantValue(nint value, MTLDataType type, NSString name)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesSelector.SetConstantValue, value, (nuint)type, name.NativePtr);
    }

    public void SetConstantValues(nint values, MTLDataType type, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesSelector.SetConstantValues, values, (nuint)type, range);
    }
}

file static class MTLFunctionConstantValuesSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionConstantValues");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetConstantValue = Selector.Register("setConstantValue:type:atIndex:");

    public static readonly Selector SetConstantValues = Selector.Register("setConstantValues:type:withRange:");
}
