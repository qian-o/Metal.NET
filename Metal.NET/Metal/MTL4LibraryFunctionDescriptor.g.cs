namespace Metal.NET;

file class MTL4LibraryFunctionDescriptorSelector
{
    public static readonly Selector SetLibrary_ = Selector.Register("setLibrary:");
    public static readonly Selector SetName_ = Selector.Register("setName:");
}

public class MTL4LibraryFunctionDescriptor : IDisposable
{
    public MTL4LibraryFunctionDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4LibraryFunctionDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4LibraryFunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4LibraryFunctionDescriptor(nint value)
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

    public void SetLibrary(MTLLibrary library)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4LibraryFunctionDescriptorSelector.SetLibrary_, library.NativePtr);
    }

    public void SetName(NSString name)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4LibraryFunctionDescriptorSelector.SetName_, name.NativePtr);
    }

}
