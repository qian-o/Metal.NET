using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CompilerTaskOptions_Selectors
{
    internal static readonly Selector setLookupArchives_ = Selector.Register("setLookupArchives:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTL4CompilerTaskOptions
{
    public readonly nint NativePtr;

    public MTL4CompilerTaskOptions(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CompilerTaskOptions o) => o.NativePtr;
    public static implicit operator MTL4CompilerTaskOptions(nint ptr) => new MTL4CompilerTaskOptions(ptr);

    public void SetLookupArchives(NSArray lookupArchives)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CompilerTaskOptions_Selectors.setLookupArchives_, lookupArchives.NativePtr);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
