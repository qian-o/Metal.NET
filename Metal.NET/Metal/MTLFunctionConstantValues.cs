namespace Metal.NET;

public class MTLFunctionConstantValues : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionConstantValues");

    public MTLFunctionConstantValues(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLFunctionConstantValues() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLFunctionConstantValues()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunctionConstantValues value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionConstantValues(nint value)
    {
        return new(value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesSelector.Reset);
    }

    public void SetConstantValue(nint value, MTLDataType type, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesSelector.SetConstantValueTypeWithName, value, (ulong)type, index);
    }

    public void SetConstantValue(nint value, MTLDataType type, NSString name)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesSelector.SetConstantValueTypeWithName, value, (ulong)type, name.NativePtr);
    }

    public void SetConstantValues(nint values, MTLDataType type, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesSelector.SetConstantValuesTypeWithRange, values, (ulong)type, range);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLFunctionConstantValuesSelector
{
    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetConstantValueTypeWithName = Selector.Register("setConstantValue:type:withName:");

    public static readonly Selector SetConstantValuesTypeWithRange = Selector.Register("setConstantValues:type:withRange:");
}
