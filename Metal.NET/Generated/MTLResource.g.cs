using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLResource_Selectors
{
    internal static readonly Selector makeAliasable = Selector.Register("makeAliasable");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector setOwner_ = Selector.Register("setOwner:");
    internal static readonly Selector setPurgeableState_ = Selector.Register("setPurgeableState:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLResource
{
    public readonly nint NativePtr;

    public MTLResource(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLResource o) => o.NativePtr;
    public static implicit operator MTLResource(nint ptr) => new MTLResource(ptr);

    public void MakeAliasable()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResource_Selectors.makeAliasable);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResource_Selectors.setLabel_, label.NativePtr);
    }

    public uint SetOwner(nint task_id_token)
    {
        return (uint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLResource_Selectors.setOwner_, task_id_token);
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)(uint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLResource_Selectors.setPurgeableState_, (nint)(uint)state);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
