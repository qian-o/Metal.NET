using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4RenderPipelineBinaryFunctionsDescriptor_Selectors
{
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector setFragmentAdditionalBinaryFunctions_ = Selector.Register("setFragmentAdditionalBinaryFunctions:");
    internal static readonly Selector setMeshAdditionalBinaryFunctions_ = Selector.Register("setMeshAdditionalBinaryFunctions:");
    internal static readonly Selector setObjectAdditionalBinaryFunctions_ = Selector.Register("setObjectAdditionalBinaryFunctions:");
    internal static readonly Selector setTileAdditionalBinaryFunctions_ = Selector.Register("setTileAdditionalBinaryFunctions:");
    internal static readonly Selector setVertexAdditionalBinaryFunctions_ = Selector.Register("setVertexAdditionalBinaryFunctions:");
}

public class MTL4RenderPipelineBinaryFunctionsDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4RenderPipelineBinaryFunctionsDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4RenderPipelineBinaryFunctionsDescriptor o) => o.NativePtr;
    public static implicit operator MTL4RenderPipelineBinaryFunctionsDescriptor(nint ptr) => new MTL4RenderPipelineBinaryFunctionsDescriptor(ptr);

    ~MTL4RenderPipelineBinaryFunctionsDescriptor() => Release();

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

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptor_Selectors.reset);
    }

    public void SetFragmentAdditionalBinaryFunctions(NSArray fragmentAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptor_Selectors.setFragmentAdditionalBinaryFunctions_, fragmentAdditionalBinaryFunctions.NativePtr);
    }

    public void SetMeshAdditionalBinaryFunctions(NSArray meshAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptor_Selectors.setMeshAdditionalBinaryFunctions_, meshAdditionalBinaryFunctions.NativePtr);
    }

    public void SetObjectAdditionalBinaryFunctions(NSArray objectAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptor_Selectors.setObjectAdditionalBinaryFunctions_, objectAdditionalBinaryFunctions.NativePtr);
    }

    public void SetTileAdditionalBinaryFunctions(NSArray tileAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptor_Selectors.setTileAdditionalBinaryFunctions_, tileAdditionalBinaryFunctions.NativePtr);
    }

    public void SetVertexAdditionalBinaryFunctions(NSArray vertexAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptor_Selectors.setVertexAdditionalBinaryFunctions_, vertexAdditionalBinaryFunctions.NativePtr);
    }

}
