using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4FunctionDescriptor_Selectors
{
}

public class MTL4FunctionDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4FunctionDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4FunctionDescriptor o) => o.NativePtr;
    public static implicit operator MTL4FunctionDescriptor(nint ptr) => new MTL4FunctionDescriptor(ptr);

    ~MTL4FunctionDescriptor() => Release();

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

}
