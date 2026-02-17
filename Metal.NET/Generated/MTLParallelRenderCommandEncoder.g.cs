using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLParallelRenderCommandEncoder_Selectors
{
    internal static readonly Selector setColorStoreAction_colorAttachmentIndex_ = Selector.Register("setColorStoreAction:colorAttachmentIndex:");
    internal static readonly Selector setColorStoreActionOptions_colorAttachmentIndex_ = Selector.Register("setColorStoreActionOptions:colorAttachmentIndex:");
    internal static readonly Selector setDepthStoreAction_ = Selector.Register("setDepthStoreAction:");
    internal static readonly Selector setDepthStoreActionOptions_ = Selector.Register("setDepthStoreActionOptions:");
    internal static readonly Selector setStencilStoreAction_ = Selector.Register("setStencilStoreAction:");
    internal static readonly Selector setStencilStoreActionOptions_ = Selector.Register("setStencilStoreActionOptions:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLParallelRenderCommandEncoder
{
    public readonly nint NativePtr;

    public MTLParallelRenderCommandEncoder(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLParallelRenderCommandEncoder o) => o.NativePtr;
    public static implicit operator MTLParallelRenderCommandEncoder(nint ptr) => new MTLParallelRenderCommandEncoder(ptr);

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLParallelRenderCommandEncoder_Selectors.setColorStoreAction_colorAttachmentIndex_, (nint)(uint)storeAction, (nint)colorAttachmentIndex);
    }

    public void SetColorStoreActionOptions(nuint storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLParallelRenderCommandEncoder_Selectors.setColorStoreActionOptions_colorAttachmentIndex_, (nint)storeActionOptions, (nint)colorAttachmentIndex);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLParallelRenderCommandEncoder_Selectors.setDepthStoreAction_, (nint)(uint)storeAction);
    }

    public void SetDepthStoreActionOptions(nuint storeActionOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLParallelRenderCommandEncoder_Selectors.setDepthStoreActionOptions_, (nint)storeActionOptions);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLParallelRenderCommandEncoder_Selectors.setStencilStoreAction_, (nint)(uint)storeAction);
    }

    public void SetStencilStoreActionOptions(nuint storeActionOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLParallelRenderCommandEncoder_Selectors.setStencilStoreActionOptions_, (nint)storeActionOptions);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
