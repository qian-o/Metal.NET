using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4BinaryFunctionDescriptor_Selectors
{
    internal static readonly Selector setFunctionDescriptor_ = Selector.Register("setFunctionDescriptor:");
    internal static readonly Selector setName_ = Selector.Register("setName:");
    internal static readonly Selector setOptions_ = Selector.Register("setOptions:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTL4BinaryFunctionDescriptor
{
    public readonly nint NativePtr;

    public MTL4BinaryFunctionDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4BinaryFunctionDescriptor o) => o.NativePtr;
    public static implicit operator MTL4BinaryFunctionDescriptor(nint ptr) => new MTL4BinaryFunctionDescriptor(ptr);

    public void SetFunctionDescriptor(MTL4FunctionDescriptor functionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4BinaryFunctionDescriptor_Selectors.setFunctionDescriptor_, functionDescriptor.NativePtr);
    }

    public void SetName(NSString name)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4BinaryFunctionDescriptor_Selectors.setName_, name.NativePtr);
    }

    public void SetOptions(nuint options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4BinaryFunctionDescriptor_Selectors.setOptions_, (nint)options);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
