namespace Metal.NET;

public class MTLFunctionDescriptor : IDisposable
{
    public MTLFunctionDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionDescriptorSelector.SetBinaryArchives, binaryArchives.NativePtr);
    }

    public void SetConstantValues(MTLFunctionConstantValues constantValues)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionDescriptorSelector.SetConstantValues, constantValues.NativePtr);
    }

    public void SetName(NSString name)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionDescriptorSelector.SetName, name.NativePtr);
    }

    public void SetOptions(uint options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionDescriptorSelector.SetOptions, (nint)options);
    }

    public void SetSpecializedName(NSString specializedName)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionDescriptorSelector.SetSpecializedName, specializedName.NativePtr);
    }

    public static MTLFunctionDescriptor FunctionDescriptor()
    {
        var result = new MTLFunctionDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFunctionDescriptorSelector.FunctionDescriptor));

        return result;
    }

}

file class MTLFunctionDescriptorSelector
{
    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");
    public static readonly Selector SetConstantValues = Selector.Register("setConstantValues:");
    public static readonly Selector SetName = Selector.Register("setName:");
    public static readonly Selector SetOptions = Selector.Register("setOptions:");
    public static readonly Selector SetSpecializedName = Selector.Register("setSpecializedName:");
    public static readonly Selector FunctionDescriptor = Selector.Register("functionDescriptor");
}
