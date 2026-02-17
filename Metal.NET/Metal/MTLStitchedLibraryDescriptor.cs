namespace Metal.NET;

public class MTLStitchedLibraryDescriptor : IDisposable
{
    public MTLStitchedLibraryDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLStitchedLibraryDescriptor(ptr);
    }

    public void SetBinaryArchives(NSArray binaryArchives)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetBinaryArchives, binaryArchives.NativePtr);
    }

    public void SetFunctionGraphs(NSArray functionGraphs)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetFunctionGraphs, functionGraphs.NativePtr);
    }

    public void SetFunctions(NSArray functions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetFunctions, functions.NativePtr);
    }

    public void SetOptions(uint options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLStitchedLibraryDescriptorSelector.SetOptions, (nint)options);
    }

}

file class MTLStitchedLibraryDescriptorSelector
{
    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector SetFunctionGraphs = Selector.Register("setFunctionGraphs:");

    public static readonly Selector SetFunctions = Selector.Register("setFunctions:");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");
}
