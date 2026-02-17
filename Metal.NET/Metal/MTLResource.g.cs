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

public class MTLResource : IDisposable
{
    public nint NativePtr { get; }

    public MTLResource(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLResource o) => o.NativePtr;
    public static implicit operator MTLResource(nint ptr) => new MTLResource(ptr);

    ~MTLResource() => Release();

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
        var __r = (uint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLResource_Selectors.setOwner_, task_id_token);
        return __r;
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        var __r = (MTLPurgeableState)(uint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLResource_Selectors.setPurgeableState_, (nint)(uint)state);
        return __r;
    }

}
