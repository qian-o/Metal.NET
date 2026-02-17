using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRenderPipelineFunctionsDescriptor_Selectors
{
    internal static readonly Selector setFragmentAdditionalBinaryFunctions_ = Selector.Register("setFragmentAdditionalBinaryFunctions:");
    internal static readonly Selector setTileAdditionalBinaryFunctions_ = Selector.Register("setTileAdditionalBinaryFunctions:");
    internal static readonly Selector setVertexAdditionalBinaryFunctions_ = Selector.Register("setVertexAdditionalBinaryFunctions:");
}

public class MTLRenderPipelineFunctionsDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLRenderPipelineFunctionsDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRenderPipelineFunctionsDescriptor o) => o.NativePtr;
    public static implicit operator MTLRenderPipelineFunctionsDescriptor(nint ptr) => new MTLRenderPipelineFunctionsDescriptor(ptr);

    ~MTLRenderPipelineFunctionsDescriptor() => Release();

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

    public void SetFragmentAdditionalBinaryFunctions(NSArray fragmentAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineFunctionsDescriptor_Selectors.setFragmentAdditionalBinaryFunctions_, fragmentAdditionalBinaryFunctions.NativePtr);
    }

    public void SetTileAdditionalBinaryFunctions(NSArray tileAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineFunctionsDescriptor_Selectors.setTileAdditionalBinaryFunctions_, tileAdditionalBinaryFunctions.NativePtr);
    }

    public void SetVertexAdditionalBinaryFunctions(NSArray vertexAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineFunctionsDescriptor_Selectors.setVertexAdditionalBinaryFunctions_, vertexAdditionalBinaryFunctions.NativePtr);
    }

}
