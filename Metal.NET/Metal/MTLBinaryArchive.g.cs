using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLBinaryArchive_Selectors
{
    internal static readonly Selector addComputePipelineFunctions_error_ = Selector.Register("addComputePipelineFunctions:error:");
    internal static readonly Selector addFunction_library_error_ = Selector.Register("addFunction:library:error:");
    internal static readonly Selector addLibrary_error_ = Selector.Register("addLibrary:error:");
    internal static readonly Selector addMeshRenderPipelineFunctions_error_ = Selector.Register("addMeshRenderPipelineFunctions:error:");
    internal static readonly Selector addRenderPipelineFunctions_error_ = Selector.Register("addRenderPipelineFunctions:error:");
    internal static readonly Selector addTileRenderPipelineFunctions_error_ = Selector.Register("addTileRenderPipelineFunctions:error:");
    internal static readonly Selector serializeToURL_error_ = Selector.Register("serializeToURL:error:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

public class MTLBinaryArchive : IDisposable
{
    public nint NativePtr { get; }

    public MTLBinaryArchive(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLBinaryArchive o) => o.NativePtr;
    public static implicit operator MTLBinaryArchive(nint ptr) => new MTLBinaryArchive(ptr);

    ~MTLBinaryArchive() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public Bool8 AddComputePipelineFunctions(MTLComputePipelineDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBinaryArchive_Selectors.addComputePipelineFunctions_error_, descriptor.NativePtr, out __errorPtr) != 0;
        error = new NSError(__errorPtr);
        return __r;
    }

    public Bool8 AddFunction(MTLFunctionDescriptor descriptor, MTLLibrary library, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBinaryArchive_Selectors.addFunction_library_error_, descriptor.NativePtr, library.NativePtr, out __errorPtr) != 0;
        error = new NSError(__errorPtr);
        return __r;
    }

    public Bool8 AddLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBinaryArchive_Selectors.addLibrary_error_, descriptor.NativePtr, out __errorPtr) != 0;
        error = new NSError(__errorPtr);
        return __r;
    }

    public Bool8 AddMeshRenderPipelineFunctions(MTLMeshRenderPipelineDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBinaryArchive_Selectors.addMeshRenderPipelineFunctions_error_, descriptor.NativePtr, out __errorPtr) != 0;
        error = new NSError(__errorPtr);
        return __r;
    }

    public Bool8 AddRenderPipelineFunctions(MTLRenderPipelineDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBinaryArchive_Selectors.addRenderPipelineFunctions_error_, descriptor.NativePtr, out __errorPtr) != 0;
        error = new NSError(__errorPtr);
        return __r;
    }

    public Bool8 AddTileRenderPipelineFunctions(MTLTileRenderPipelineDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBinaryArchive_Selectors.addTileRenderPipelineFunctions_error_, descriptor.NativePtr, out __errorPtr) != 0;
        error = new NSError(__errorPtr);
        return __r;
    }

    public Bool8 SerializeToURL(NSURL url, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBinaryArchive_Selectors.serializeToURL_error_, url.NativePtr, out __errorPtr) != 0;
        error = new NSError(__errorPtr);
        return __r;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBinaryArchive_Selectors.setLabel_, label.NativePtr);
    }

}
