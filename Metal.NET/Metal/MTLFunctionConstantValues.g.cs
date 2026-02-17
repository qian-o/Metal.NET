namespace Metal.NET;

file class MTLFunctionConstantValuesSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetConstantValue_type_index_ = Selector.Register("setConstantValue:type:index:");
    public static readonly Selector SetConstantValue_type_name_ = Selector.Register("setConstantValue:type:name:");
}

public class MTLFunctionConstantValues : IDisposable
{
    public MTLFunctionConstantValues(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionConstantValuesSelector.Reset);
    }

    public void SetConstantValue(nint value, MTLDataType type, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionConstantValuesSelector.SetConstantValue_type_index_, value, (nint)(uint)type, (nint)index);
    }

    public void SetConstantValue(nint value, MTLDataType type, NSString name)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionConstantValuesSelector.SetConstantValue_type_name_, value, (nint)(uint)type, name.NativePtr);
    }

}
