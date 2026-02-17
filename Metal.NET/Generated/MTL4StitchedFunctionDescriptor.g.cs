using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4StitchedFunctionDescriptor_Selectors
{
    internal static readonly Selector setFunctionDescriptors_ = Selector.Register("setFunctionDescriptors:");
    internal static readonly Selector setFunctionGraph_ = Selector.Register("setFunctionGraph:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTL4StitchedFunctionDescriptor
{
    public readonly nint NativePtr;

    public MTL4StitchedFunctionDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4StitchedFunctionDescriptor o) => o.NativePtr;
    public static implicit operator MTL4StitchedFunctionDescriptor(nint ptr) => new MTL4StitchedFunctionDescriptor(ptr);

    public void SetFunctionDescriptors(NSArray functionDescriptors)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4StitchedFunctionDescriptor_Selectors.setFunctionDescriptors_, functionDescriptors.NativePtr);
    }

    public void SetFunctionGraph(MTLFunctionStitchingGraph functionGraph)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4StitchedFunctionDescriptor_Selectors.setFunctionGraph_, functionGraph.NativePtr);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
