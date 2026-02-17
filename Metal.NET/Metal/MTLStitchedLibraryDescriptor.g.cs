using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLStitchedLibraryDescriptor_Selectors
{
    internal static readonly Selector setBinaryArchives_ = Selector.Register("setBinaryArchives:");
    internal static readonly Selector setFunctionGraphs_ = Selector.Register("setFunctionGraphs:");
    internal static readonly Selector setFunctions_ = Selector.Register("setFunctions:");
    internal static readonly Selector setOptions_ = Selector.Register("setOptions:");
}

public class MTLStitchedLibraryDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLStitchedLibraryDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLStitchedLibraryDescriptor o) => o.NativePtr;
    public static implicit operator MTLStitchedLibraryDescriptor(nint ptr) => new MTLStitchedLibraryDescriptor(ptr);

    ~MTLStitchedLibraryDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLStitchedLibraryDescriptor");

    public static MTLStitchedLibraryDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLStitchedLibraryDescriptor(ptr);
    }

    public void SetBinaryArchives(NSArray binaryArchives)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStitchedLibraryDescriptor_Selectors.setBinaryArchives_, binaryArchives.NativePtr);
    }

    public void SetFunctionGraphs(NSArray functionGraphs)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStitchedLibraryDescriptor_Selectors.setFunctionGraphs_, functionGraphs.NativePtr);
    }

    public void SetFunctions(NSArray functions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStitchedLibraryDescriptor_Selectors.setFunctions_, functions.NativePtr);
    }

    public void SetOptions(nuint options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStitchedLibraryDescriptor_Selectors.setOptions_, (nint)options);
    }

}
