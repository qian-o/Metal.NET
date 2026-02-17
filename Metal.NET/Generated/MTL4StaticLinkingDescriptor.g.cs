using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4StaticLinkingDescriptor_Selectors
{
    internal static readonly Selector setFunctionDescriptors_ = Selector.Register("setFunctionDescriptors:");
    internal static readonly Selector setGroups_ = Selector.Register("setGroups:");
    internal static readonly Selector setPrivateFunctionDescriptors_ = Selector.Register("setPrivateFunctionDescriptors:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTL4StaticLinkingDescriptor
{
    public readonly nint NativePtr;

    public MTL4StaticLinkingDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4StaticLinkingDescriptor o) => o.NativePtr;
    public static implicit operator MTL4StaticLinkingDescriptor(nint ptr) => new MTL4StaticLinkingDescriptor(ptr);

    public void SetFunctionDescriptors(NSArray functionDescriptors)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4StaticLinkingDescriptor_Selectors.setFunctionDescriptors_, functionDescriptors.NativePtr);
    }

    public void SetGroups(nint groups)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4StaticLinkingDescriptor_Selectors.setGroups_, groups);
    }

    public void SetPrivateFunctionDescriptors(NSArray privateFunctionDescriptors)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4StaticLinkingDescriptor_Selectors.setPrivateFunctionDescriptors_, privateFunctionDescriptors.NativePtr);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
