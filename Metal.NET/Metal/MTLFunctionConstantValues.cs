namespace Metal.NET;

public class MTLFunctionConstantValues(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFunctionConstantValues() : this(ObjectiveCRuntime.AllocInit(MTLFunctionConstantValuesBindings.Class))
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.SetConstantValue, value, (nuint)type, name.NativePtr);
    }

    public void SetConstantValues(nint values, MTLDataType type, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesBindings.SetConstantValues, values, (nuint)type, range);
    }
}

file static class MTLFunctionConstantValuesBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionConstantValues");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetConstantValue = Selector.Register("setConstantValue:type:atIndex:");

    public static readonly Selector SetConstantValues = Selector.Register("setConstantValues:type:withRange:");
}
