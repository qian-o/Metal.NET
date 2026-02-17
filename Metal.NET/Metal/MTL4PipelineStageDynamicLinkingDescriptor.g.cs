using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4PipelineStageDynamicLinkingDescriptor_Selectors
{
    internal static readonly Selector setBinaryLinkedFunctions_ = Selector.Register("setBinaryLinkedFunctions:");
    internal static readonly Selector setMaxCallStackDepth_ = Selector.Register("setMaxCallStackDepth:");
    internal static readonly Selector setPreloadedLibraries_ = Selector.Register("setPreloadedLibraries:");
}

public class MTL4PipelineStageDynamicLinkingDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4PipelineStageDynamicLinkingDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4PipelineStageDynamicLinkingDescriptor o) => o.NativePtr;
    public static implicit operator MTL4PipelineStageDynamicLinkingDescriptor(nint ptr) => new MTL4PipelineStageDynamicLinkingDescriptor(ptr);

    ~MTL4PipelineStageDynamicLinkingDescriptor() => Release();

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

    public void SetBinaryLinkedFunctions(NSArray binaryLinkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptor_Selectors.setBinaryLinkedFunctions_, binaryLinkedFunctions.NativePtr);
    }

    public void SetMaxCallStackDepth(nuint maxCallStackDepth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptor_Selectors.setMaxCallStackDepth_, (nint)maxCallStackDepth);
    }

    public void SetPreloadedLibraries(NSArray preloadedLibraries)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptor_Selectors.setPreloadedLibraries_, preloadedLibraries.NativePtr);
    }

}
