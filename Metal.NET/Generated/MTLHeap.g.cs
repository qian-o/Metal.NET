using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLHeap_Selectors
{
    internal static readonly Selector maxAvailableSize_ = Selector.Register("maxAvailableSize:");
    internal static readonly Selector newAccelerationStructure_ = Selector.Register("newAccelerationStructure:");
    internal static readonly Selector newAccelerationStructure_offset_ = Selector.Register("newAccelerationStructure:offset:");
    internal static readonly Selector newBuffer_options_ = Selector.Register("newBuffer:options:");
    internal static readonly Selector newBuffer_options_offset_ = Selector.Register("newBuffer:options:offset:");
    internal static readonly Selector newTexture_ = Selector.Register("newTexture:");
    internal static readonly Selector newTexture_offset_ = Selector.Register("newTexture:offset:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector setPurgeableState_ = Selector.Register("setPurgeableState:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLHeap
{
    public readonly nint NativePtr;

    public MTLHeap(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLHeap o) => o.NativePtr;
    public static implicit operator MTLHeap(nint ptr) => new MTLHeap(ptr);

    public nuint MaxAvailableSize(nuint alignment)
    {
        return (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeap_Selectors.maxAvailableSize_, (nint)alignment);
    }

    public MTLAccelerationStructure NewAccelerationStructure(nuint size)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeap_Selectors.newAccelerationStructure_, (nint)size);
        return new MTLAccelerationStructure(__result);
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeap_Selectors.newAccelerationStructure_, descriptor.NativePtr);
        return new MTLAccelerationStructure(__result);
    }

    public MTLAccelerationStructure NewAccelerationStructure(nuint size, nuint offset)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeap_Selectors.newAccelerationStructure_offset_, (nint)size, (nint)offset);
        return new MTLAccelerationStructure(__result);
    }

    public MTLAccelerationStructure NewAccelerationStructure(MTLAccelerationStructureDescriptor descriptor, nuint offset)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeap_Selectors.newAccelerationStructure_offset_, descriptor.NativePtr, (nint)offset);
        return new MTLAccelerationStructure(__result);
    }

    public MTLBuffer NewBuffer(nuint length, nuint options)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeap_Selectors.newBuffer_options_, (nint)length, (nint)options);
        return new MTLBuffer(__result);
    }

    public MTLBuffer NewBuffer(nuint length, nuint options, nuint offset)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeap_Selectors.newBuffer_options_offset_, (nint)length, (nint)options, (nint)offset);
        return new MTLBuffer(__result);
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeap_Selectors.newTexture_, descriptor.NativePtr);
        return new MTLTexture(__result);
    }

    public MTLTexture NewTexture(MTLTextureDescriptor descriptor, nuint offset)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeap_Selectors.newTexture_offset_, descriptor.NativePtr, (nint)offset);
        return new MTLTexture(__result);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLHeap_Selectors.setLabel_, label.NativePtr);
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)(uint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLHeap_Selectors.setPurgeableState_, (nint)(uint)state);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
