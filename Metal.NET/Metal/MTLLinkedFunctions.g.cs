using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLLinkedFunctions_Selectors
{
    internal static readonly Selector setBinaryFunctions_ = Selector.Register("setBinaryFunctions:");
    internal static readonly Selector setFunctions_ = Selector.Register("setFunctions:");
    internal static readonly Selector setGroups_ = Selector.Register("setGroups:");
    internal static readonly Selector setPrivateFunctions_ = Selector.Register("setPrivateFunctions:");
    internal static readonly Selector linkedFunctions = Selector.Register("linkedFunctions");
}

public class MTLLinkedFunctions : IDisposable
{
    public nint NativePtr { get; }

    public MTLLinkedFunctions(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLLinkedFunctions o) => o.NativePtr;
    public static implicit operator MTLLinkedFunctions(nint ptr) => new MTLLinkedFunctions(ptr);

    ~MTLLinkedFunctions() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLLinkedFunctions");

    public static MTLLinkedFunctions New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLLinkedFunctions(ptr);
    }

    public void SetBinaryFunctions(NSArray binaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLinkedFunctions_Selectors.setBinaryFunctions_, binaryFunctions.NativePtr);
    }

    public void SetFunctions(NSArray functions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLinkedFunctions_Selectors.setFunctions_, functions.NativePtr);
    }

    public void SetGroups(nint groups)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLinkedFunctions_Selectors.setGroups_, groups);
    }

    public void SetPrivateFunctions(NSArray privateFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLinkedFunctions_Selectors.setPrivateFunctions_, privateFunctions.NativePtr);
    }

    public static MTLLinkedFunctions LinkedFunctions()
    {
        var __r = new MTLLinkedFunctions(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLLinkedFunctions_Selectors.linkedFunctions));
        return __r;
    }

}
