namespace Metal.NET;

public class MTL4LibraryDescriptor : IDisposable
{
    public MTL4LibraryDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4LibraryDescriptorSelector.SetName, name.NativePtr);
    }

    public void SetOptions(MTLCompileOptions options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4LibraryDescriptorSelector.SetOptions, options.NativePtr);
    }

    public void SetSource(NSString source)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4LibraryDescriptorSelector.SetSource, source.NativePtr);
    }

}

file class MTL4LibraryDescriptorSelector
{
    public static readonly Selector SetName = Selector.Register("setName:");
    public static readonly Selector SetOptions = Selector.Register("setOptions:");
    public static readonly Selector SetSource = Selector.Register("setSource:");
}
