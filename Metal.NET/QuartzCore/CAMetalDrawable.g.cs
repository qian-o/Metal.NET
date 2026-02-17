using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class CAMetalDrawable_Selectors
{
}

public class CAMetalDrawable : IDisposable
{
    public nint NativePtr { get; }

    public CAMetalDrawable(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(CAMetalDrawable o) => o.NativePtr;
    public static implicit operator CAMetalDrawable(nint ptr) => new CAMetalDrawable(ptr);

    ~CAMetalDrawable() => Release();

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
