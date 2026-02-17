namespace Metal.NET;

public class MTL4BinaryFunctionDescriptor : IDisposable
{
    public MTL4BinaryFunctionDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4BinaryFunctionDescriptorSelector.SetFunctionDescriptor, functionDescriptor.NativePtr);
    }

    public void SetName(NSString name)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4BinaryFunctionDescriptorSelector.SetName, name.NativePtr);
    }

    public void SetOptions(uint options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4BinaryFunctionDescriptorSelector.SetOptions, (nint)options);
    }

}

file class MTL4BinaryFunctionDescriptorSelector
{
    public static readonly Selector SetFunctionDescriptor = Selector.Register("setFunctionDescriptor:");
    public static readonly Selector SetName = Selector.Register("setName:");
    public static readonly Selector SetOptions = Selector.Register("setOptions:");
}
