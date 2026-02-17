namespace Metal.NET;

public class MTL4SpecializedFunctionDescriptor : IDisposable
{
    public MTL4SpecializedFunctionDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4SpecializedFunctionDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4SpecializedFunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4SpecializedFunctionDescriptor(nint value)
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

    public void SetConstantValues(MTLFunctionConstantValues constantValues)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorSelector.SetConstantValues, constantValues.NativePtr);
    }

    public void SetFunctionDescriptor(MTL4FunctionDescriptor functionDescriptor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorSelector.SetFunctionDescriptor, functionDescriptor.NativePtr);
    }

    public void SetSpecializedName(NSString specializedName)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorSelector.SetSpecializedName, specializedName.NativePtr);
    }

}

file class MTL4SpecializedFunctionDescriptorSelector
{
    public static readonly Selector SetConstantValues = Selector.Register("setConstantValues:");

    public static readonly Selector SetFunctionDescriptor = Selector.Register("setFunctionDescriptor:");

    public static readonly Selector SetSpecializedName = Selector.Register("setSpecializedName:");
}
