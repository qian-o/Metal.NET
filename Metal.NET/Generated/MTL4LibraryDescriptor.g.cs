using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4LibraryDescriptor_Selectors
{
    internal static readonly Selector setName_ = Selector.Register("setName:");
    internal static readonly Selector setOptions_ = Selector.Register("setOptions:");
    internal static readonly Selector setSource_ = Selector.Register("setSource:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTL4LibraryDescriptor
{
    public readonly nint NativePtr;

    public MTL4LibraryDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4LibraryDescriptor o) => o.NativePtr;
    public static implicit operator MTL4LibraryDescriptor(nint ptr) => new MTL4LibraryDescriptor(ptr);

    public void SetName(NSString name)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4LibraryDescriptor_Selectors.setName_, name.NativePtr);
    }

    public void SetOptions(MTLCompileOptions options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4LibraryDescriptor_Selectors.setOptions_, options.NativePtr);
    }

    public void SetSource(NSString source)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4LibraryDescriptor_Selectors.setSource_, source.NativePtr);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
