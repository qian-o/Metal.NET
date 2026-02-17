using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CompilerDescriptor_Selectors
{
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector setPipelineDataSetSerializer_ = Selector.Register("setPipelineDataSetSerializer:");
}

public class MTL4CompilerDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4CompilerDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CompilerDescriptor o) => o.NativePtr;
    public static implicit operator MTL4CompilerDescriptor(nint ptr) => new MTL4CompilerDescriptor(ptr);

    ~MTL4CompilerDescriptor() => Release();

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

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CompilerDescriptor_Selectors.setLabel_, label.NativePtr);
    }

    public void SetPipelineDataSetSerializer(MTL4PipelineDataSetSerializer pipelineDataSetSerializer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CompilerDescriptor_Selectors.setPipelineDataSetSerializer_, pipelineDataSetSerializer.NativePtr);
    }

}
