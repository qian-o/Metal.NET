namespace Metal.NET;

file class MTLFunctionDescriptorSelector
{
    public static readonly Selector SetBinaryArchives_ = Selector.Register("setBinaryArchives:");
    public static readonly Selector SetConstantValues_ = Selector.Register("setConstantValues:");
    public static readonly Selector SetName_ = Selector.Register("setName:");
    public static readonly Selector SetOptions_ = Selector.Register("setOptions:");
    public static readonly Selector SetSpecializedName_ = Selector.Register("setSpecializedName:");
    public static readonly Selector FunctionDescriptor = Selector.Register("functionDescriptor");
}

public class MTLFunctionDescriptor : IDisposable
{
    public MTLFunctionDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLFunctionDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFunctionDescriptor");

    public void SetBinaryArchives(NSArray binaryArchives)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionDescriptorSelector.SetBinaryArchives_, binaryArchives.NativePtr);
    }

    public void SetConstantValues(MTLFunctionConstantValues constantValues)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionDescriptorSelector.SetConstantValues_, constantValues.NativePtr);
    }

    public void SetName(NSString name)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionDescriptorSelector.SetName_, name.NativePtr);
    }

    public void SetOptions(nuint options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionDescriptorSelector.SetOptions_, (nint)options);
    }

    public void SetSpecializedName(NSString specializedName)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionDescriptorSelector.SetSpecializedName_, specializedName.NativePtr);
    }

    public static MTLFunctionDescriptor FunctionDescriptor()
    {
        var result = new MTLFunctionDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFunctionDescriptorSelector.FunctionDescriptor));

        return result;
    }

}
