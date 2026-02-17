using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4PipelineDataSetSerializerDescriptor_Selectors
{
    internal static readonly Selector setConfiguration_ = Selector.Register("setConfiguration:");
}

public class MTL4PipelineDataSetSerializerDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4PipelineDataSetSerializerDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4PipelineDataSetSerializerDescriptor o) => o.NativePtr;
    public static implicit operator MTL4PipelineDataSetSerializerDescriptor(nint ptr) => new MTL4PipelineDataSetSerializerDescriptor(ptr);

    ~MTL4PipelineDataSetSerializerDescriptor() => Release();

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

    public void SetConfiguration(nuint configuration)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineDataSetSerializerDescriptor_Selectors.setConfiguration_, (nint)configuration);
    }

}
