namespace Metal.NET;

public readonly struct MTLFunctionConstantValues(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLFunctionConstantValues value) => new(value.NativePtr);

    public MTLFunctionConstantValues() : this(ObjectiveC.AllocInit(MTLFunctionConstantValuesBindings.Class))
    {
    }

    public MTLFunctionConstantValues Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
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
