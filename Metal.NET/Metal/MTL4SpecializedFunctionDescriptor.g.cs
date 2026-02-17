namespace Metal.NET;

file class MTL4SpecializedFunctionDescriptorSelector
{
    public static readonly Selector SetConstantValues_ = Selector.Register("setConstantValues:");
    public static readonly Selector SetFunctionDescriptor_ = Selector.Register("setFunctionDescriptor:");
    public static readonly Selector SetSpecializedName_ = Selector.Register("setSpecializedName:");
}

public class MTL4SpecializedFunctionDescriptor : IDisposable
{
    public MTL4SpecializedFunctionDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4SpecializedFunctionDescriptorSelector.SetConstantValues_, constantValues.NativePtr);
    }

    public void SetFunctionDescriptor(MTL4FunctionDescriptor functionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4SpecializedFunctionDescriptorSelector.SetFunctionDescriptor_, functionDescriptor.NativePtr);
    }

    public void SetSpecializedName(NSString specializedName)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4SpecializedFunctionDescriptorSelector.SetSpecializedName_, specializedName.NativePtr);
    }

}
