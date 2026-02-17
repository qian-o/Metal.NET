using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionDescriptor_Selectors
{
    internal static readonly Selector setBinaryArchives_ = Selector.Register("setBinaryArchives:");
    internal static readonly Selector setConstantValues_ = Selector.Register("setConstantValues:");
    internal static readonly Selector setName_ = Selector.Register("setName:");
    internal static readonly Selector setOptions_ = Selector.Register("setOptions:");
    internal static readonly Selector setSpecializedName_ = Selector.Register("setSpecializedName:");
    internal static readonly Selector functionDescriptor = Selector.Register("functionDescriptor");
}

public class MTLFunctionDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLFunctionDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionDescriptor o) => o.NativePtr;
    public static implicit operator MTLFunctionDescriptor(nint ptr) => new MTLFunctionDescriptor(ptr);

    ~MTLFunctionDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFunctionDescriptor");

    public void SetBinaryArchives(NSArray binaryArchives)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionDescriptor_Selectors.setBinaryArchives_, binaryArchives.NativePtr);
    }

    public void SetConstantValues(MTLFunctionConstantValues constantValues)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionDescriptor_Selectors.setConstantValues_, constantValues.NativePtr);
    }

    public void SetName(NSString name)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionDescriptor_Selectors.setName_, name.NativePtr);
    }

    public void SetOptions(nuint options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionDescriptor_Selectors.setOptions_, (nint)options);
    }

    public void SetSpecializedName(NSString specializedName)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionDescriptor_Selectors.setSpecializedName_, specializedName.NativePtr);
    }

    public static MTLFunctionDescriptor FunctionDescriptor()
    {
        var __r = new MTLFunctionDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFunctionDescriptor_Selectors.functionDescriptor));
        return __r;
    }

}
