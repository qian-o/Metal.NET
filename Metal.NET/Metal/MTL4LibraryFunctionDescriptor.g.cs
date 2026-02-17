using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4LibraryFunctionDescriptor_Selectors
{
    internal static readonly Selector setLibrary_ = Selector.Register("setLibrary:");
    internal static readonly Selector setName_ = Selector.Register("setName:");
}

public class MTL4LibraryFunctionDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4LibraryFunctionDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4LibraryFunctionDescriptor o) => o.NativePtr;
    public static implicit operator MTL4LibraryFunctionDescriptor(nint ptr) => new MTL4LibraryFunctionDescriptor(ptr);

    ~MTL4LibraryFunctionDescriptor() => Release();

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

    public void SetLibrary(MTLLibrary library)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4LibraryFunctionDescriptor_Selectors.setLibrary_, library.NativePtr);
    }

    public void SetName(NSString name)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4LibraryFunctionDescriptor_Selectors.setName_, name.NativePtr);
    }

}
