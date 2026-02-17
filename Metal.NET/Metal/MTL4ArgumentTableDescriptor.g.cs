using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4ArgumentTableDescriptor_Selectors
{
    internal static readonly Selector setInitializeBindings_ = Selector.Register("setInitializeBindings:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector setMaxBufferBindCount_ = Selector.Register("setMaxBufferBindCount:");
    internal static readonly Selector setMaxSamplerStateBindCount_ = Selector.Register("setMaxSamplerStateBindCount:");
    internal static readonly Selector setMaxTextureBindCount_ = Selector.Register("setMaxTextureBindCount:");
    internal static readonly Selector setSupportAttributeStrides_ = Selector.Register("setSupportAttributeStrides:");
}

public class MTL4ArgumentTableDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4ArgumentTableDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4ArgumentTableDescriptor o) => o.NativePtr;
    public static implicit operator MTL4ArgumentTableDescriptor(nint ptr) => new MTL4ArgumentTableDescriptor(ptr);

    ~MTL4ArgumentTableDescriptor() => Release();

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

    public void SetInitializeBindings(Bool8 initializeBindings)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableDescriptor_Selectors.setInitializeBindings_, (nint)initializeBindings.Value);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableDescriptor_Selectors.setLabel_, label.NativePtr);
    }

    public void SetMaxBufferBindCount(nuint maxBufferBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableDescriptor_Selectors.setMaxBufferBindCount_, (nint)maxBufferBindCount);
    }

    public void SetMaxSamplerStateBindCount(nuint maxSamplerStateBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableDescriptor_Selectors.setMaxSamplerStateBindCount_, (nint)maxSamplerStateBindCount);
    }

    public void SetMaxTextureBindCount(nuint maxTextureBindCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableDescriptor_Selectors.setMaxTextureBindCount_, (nint)maxTextureBindCount);
    }

    public void SetSupportAttributeStrides(Bool8 supportAttributeStrides)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTableDescriptor_Selectors.setSupportAttributeStrides_, (nint)supportAttributeStrides.Value);
    }

}
