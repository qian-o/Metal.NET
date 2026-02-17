namespace Metal.NET;

file class MTL4LibraryDescriptorSelector
{
    public static readonly Selector SetName_ = Selector.Register("setName:");
    public static readonly Selector SetOptions_ = Selector.Register("setOptions:");
    public static readonly Selector SetSource_ = Selector.Register("setSource:");
}

public class MTL4LibraryDescriptor : IDisposable
{
    public MTL4LibraryDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4LibraryDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4LibraryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4LibraryDescriptor(nint value)
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

    public void SetName(NSString name)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4LibraryDescriptorSelector.SetName_, name.NativePtr);
    }

    public void SetOptions(MTLCompileOptions options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4LibraryDescriptorSelector.SetOptions_, options.NativePtr);
    }

    public void SetSource(NSString source)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4LibraryDescriptorSelector.SetSource_, source.NativePtr);
    }

}
