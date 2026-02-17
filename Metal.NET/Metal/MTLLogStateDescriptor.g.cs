using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLLogStateDescriptor_Selectors
{
    internal static readonly Selector setBufferSize_ = Selector.Register("setBufferSize:");
    internal static readonly Selector setLevel_ = Selector.Register("setLevel:");
}

public class MTLLogStateDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLLogStateDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLLogStateDescriptor o) => o.NativePtr;
    public static implicit operator MTLLogStateDescriptor(nint ptr) => new MTLLogStateDescriptor(ptr);

    ~MTLLogStateDescriptor() => Release();

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

    public void SetBufferSize(nint bufferSize)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLogStateDescriptor_Selectors.setBufferSize_, bufferSize);
    }

    public void SetLevel(MTLLogLevel level)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLogStateDescriptor_Selectors.setLevel_, (nint)(uint)level);
    }

}
