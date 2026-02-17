namespace Metal.NET;

file class MTL4BinaryFunctionDescriptorSelector
{
    public static readonly Selector SetFunctionDescriptor_ = Selector.Register("setFunctionDescriptor:");
    public static readonly Selector SetName_ = Selector.Register("setName:");
    public static readonly Selector SetOptions_ = Selector.Register("setOptions:");
}

public class MTL4BinaryFunctionDescriptor : IDisposable
{
    public MTL4BinaryFunctionDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4BinaryFunctionDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4BinaryFunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4BinaryFunctionDescriptor(nint value)
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

    public void SetFunctionDescriptor(MTL4FunctionDescriptor functionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4BinaryFunctionDescriptorSelector.SetFunctionDescriptor_, functionDescriptor.NativePtr);
    }

    public void SetName(NSString name)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4BinaryFunctionDescriptorSelector.SetName_, name.NativePtr);
    }

    public void SetOptions(nuint options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4BinaryFunctionDescriptorSelector.SetOptions_, (nint)options);
    }

}
