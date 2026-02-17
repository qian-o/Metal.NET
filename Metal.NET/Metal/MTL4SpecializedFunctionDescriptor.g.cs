using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4SpecializedFunctionDescriptor_Selectors
{
    internal static readonly Selector setConstantValues_ = Selector.Register("setConstantValues:");
    internal static readonly Selector setFunctionDescriptor_ = Selector.Register("setFunctionDescriptor:");
    internal static readonly Selector setSpecializedName_ = Selector.Register("setSpecializedName:");
}

public class MTL4SpecializedFunctionDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4SpecializedFunctionDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4SpecializedFunctionDescriptor o) => o.NativePtr;
    public static implicit operator MTL4SpecializedFunctionDescriptor(nint ptr) => new MTL4SpecializedFunctionDescriptor(ptr);

    ~MTL4SpecializedFunctionDescriptor() => Release();

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

    public void SetConstantValues(MTLFunctionConstantValues constantValues)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4SpecializedFunctionDescriptor_Selectors.setConstantValues_, constantValues.NativePtr);
    }

    public void SetFunctionDescriptor(MTL4FunctionDescriptor functionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4SpecializedFunctionDescriptor_Selectors.setFunctionDescriptor_, functionDescriptor.NativePtr);
    }

    public void SetSpecializedName(NSString specializedName)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4SpecializedFunctionDescriptor_Selectors.setSpecializedName_, specializedName.NativePtr);
    }

}
