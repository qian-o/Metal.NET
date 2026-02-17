using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionConstantValues_Selectors
{
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector setConstantValue_type_index_ = Selector.Register("setConstantValue:type:index:");
    internal static readonly Selector setConstantValue_type_name_ = Selector.Register("setConstantValue:type:name:");
}

public class MTLFunctionConstantValues : IDisposable
{
    public nint NativePtr { get; }

    public MTLFunctionConstantValues(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionConstantValues o) => o.NativePtr;
    public static implicit operator MTLFunctionConstantValues(nint ptr) => new MTLFunctionConstantValues(ptr);

    ~MTLFunctionConstantValues() => Release();

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

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionConstantValues_Selectors.reset);
    }

    public void SetConstantValue(nint value, MTLDataType type, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionConstantValues_Selectors.setConstantValue_type_index_, value, (nint)(uint)type, (nint)index);
    }

    public void SetConstantValue(nint value, MTLDataType type, NSString name)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionConstantValues_Selectors.setConstantValue_type_name_, value, (nint)(uint)type, name.NativePtr);
    }

}
