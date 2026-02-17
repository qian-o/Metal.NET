namespace Metal.NET;

public class MTLFunctionConstantValues : IDisposable
{
    public MTLFunctionConstantValues(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesSelector.Reset);
    }

    public void SetConstantValue(int value, MTLDataType type, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesSelector.SetConstantValueTypeIndex, value, (nint)(uint)type, (nint)index);
    }

    public void SetConstantValue(int value, MTLDataType type, NSString name)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionConstantValuesSelector.SetConstantValueTypeName, value, (nint)(uint)type, name.NativePtr);
    }

}

file class MTLFunctionConstantValuesSelector
{
    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetConstantValueTypeIndex = Selector.Register("setConstantValue:type:index:");

    public static readonly Selector SetConstantValueTypeName = Selector.Register("setConstantValue:type:name:");
}
