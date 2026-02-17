#nullable enable

namespace Metal.NET;

file class MTLBinaryArchiveSelector
{
    public static readonly Selector AddComputePipelineFunctions_error_ = Selector.Register("addComputePipelineFunctions:error:");
    public static readonly Selector AddFunction_library_error_ = Selector.Register("addFunction:library:error:");
    public static readonly Selector AddLibrary_error_ = Selector.Register("addLibrary:error:");
    public static readonly Selector AddMeshRenderPipelineFunctions_error_ = Selector.Register("addMeshRenderPipelineFunctions:error:");
    public static readonly Selector AddRenderPipelineFunctions_error_ = Selector.Register("addRenderPipelineFunctions:error:");
    public static readonly Selector AddTileRenderPipelineFunctions_error_ = Selector.Register("addTileRenderPipelineFunctions:error:");
    public static readonly Selector SerializeToURL_error_ = Selector.Register("serializeToURL:error:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
}

public class MTLBinaryArchive : IDisposable
{
    public MTLBinaryArchive(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLBinaryArchive()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLBinaryArchive value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLBinaryArchive(nint value)
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

    public Bool8 AddComputePipelineFunctions(MTLComputePipelineDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBinaryArchiveSelector.AddComputePipelineFunctions_error_, descriptor.NativePtr, out errorPtr) is not 0;
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public Bool8 AddFunction(MTLFunctionDescriptor descriptor, MTLLibrary library, out NSError? error)
    {
        nint errorPtr = 0;
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBinaryArchiveSelector.AddFunction_library_error_, descriptor.NativePtr, library.NativePtr, out errorPtr) is not 0;
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public Bool8 AddLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBinaryArchiveSelector.AddLibrary_error_, descriptor.NativePtr, out errorPtr) is not 0;
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public Bool8 AddMeshRenderPipelineFunctions(MTLMeshRenderPipelineDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBinaryArchiveSelector.AddMeshRenderPipelineFunctions_error_, descriptor.NativePtr, out errorPtr) is not 0;
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public Bool8 AddRenderPipelineFunctions(MTLRenderPipelineDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBinaryArchiveSelector.AddRenderPipelineFunctions_error_, descriptor.NativePtr, out errorPtr) is not 0;
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public Bool8 AddTileRenderPipelineFunctions(MTLTileRenderPipelineDescriptor descriptor, out NSError? error)
    {
        nint errorPtr = 0;
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBinaryArchiveSelector.AddTileRenderPipelineFunctions_error_, descriptor.NativePtr, out errorPtr) is not 0;
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public Bool8 SerializeToURL(NSURL url, out NSError? error)
    {
        nint errorPtr = 0;
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBinaryArchiveSelector.SerializeToURL_error_, url.NativePtr, out errorPtr) is not 0;
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBinaryArchiveSelector.SetLabel_, label.NativePtr);
    }

}
