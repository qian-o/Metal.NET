using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4StitchedFunctionDescriptor_Selectors
{
    internal static readonly Selector setFunctionDescriptors_ = Selector.Register("setFunctionDescriptors:");
    internal static readonly Selector setFunctionGraph_ = Selector.Register("setFunctionGraph:");
}

public class MTL4StitchedFunctionDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4StitchedFunctionDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4StitchedFunctionDescriptor o) => o.NativePtr;
    public static implicit operator MTL4StitchedFunctionDescriptor(nint ptr) => new MTL4StitchedFunctionDescriptor(ptr);

    ~MTL4StitchedFunctionDescriptor() => Release();

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

    public void SetFunctionDescriptors(NSArray functionDescriptors)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4StitchedFunctionDescriptor_Selectors.setFunctionDescriptors_, functionDescriptors.NativePtr);
    }

    public void SetFunctionGraph(MTLFunctionStitchingGraph functionGraph)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4StitchedFunctionDescriptor_Selectors.setFunctionGraph_, functionGraph.NativePtr);
    }

}
