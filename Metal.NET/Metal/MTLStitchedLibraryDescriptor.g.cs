namespace Metal.NET;

file class MTLStitchedLibraryDescriptorSelector
{
    public static readonly Selector SetBinaryArchives_ = Selector.Register("setBinaryArchives:");
    public static readonly Selector SetFunctionGraphs_ = Selector.Register("setFunctionGraphs:");
    public static readonly Selector SetFunctions_ = Selector.Register("setFunctions:");
    public static readonly Selector SetOptions_ = Selector.Register("setOptions:");
}

public class MTLStitchedLibraryDescriptor : IDisposable
{
    public MTLStitchedLibraryDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLStitchedLibraryDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLStitchedLibraryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLStitchedLibraryDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLStitchedLibraryDescriptor");

    public static MTLStitchedLibraryDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLStitchedLibraryDescriptor(ptr);
    }

    public void SetBinaryArchives(NSArray binaryArchives)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetBinaryArchives_, binaryArchives.NativePtr);
    }

    public void SetFunctionGraphs(NSArray functionGraphs)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetFunctionGraphs_, functionGraphs.NativePtr);
    }

    public void SetFunctions(NSArray functions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetFunctions_, functions.NativePtr);
    }

    public void SetOptions(nuint options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetOptions_, (nint)options);
    }

}
