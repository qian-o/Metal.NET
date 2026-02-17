using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLStructType_Selectors
{
    internal static readonly Selector memberByName_ = Selector.Register("memberByName:");
}

public class MTLStructType : IDisposable
{
    public nint NativePtr { get; }

    public MTLStructType(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLStructType o) => o.NativePtr;
    public static implicit operator MTLStructType(nint ptr) => new MTLStructType(ptr);

    ~MTLStructType() => Release();

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

    public MTLStructMember MemberByName(NSString name)
    {
        var __r = new MTLStructMember(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLStructType_Selectors.memberByName_, name.NativePtr));
        return __r;
    }

}
