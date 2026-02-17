using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4PipelineOptions_Selectors
{
    internal static readonly Selector setShaderReflection_ = Selector.Register("setShaderReflection:");
    internal static readonly Selector setShaderValidation_ = Selector.Register("setShaderValidation:");
}

public class MTL4PipelineOptions : IDisposable
{
    public nint NativePtr { get; }

    public MTL4PipelineOptions(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4PipelineOptions o) => o.NativePtr;
    public static implicit operator MTL4PipelineOptions(nint ptr) => new MTL4PipelineOptions(ptr);

    ~MTL4PipelineOptions() => Release();

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

    public void SetShaderReflection(nuint shaderReflection)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineOptions_Selectors.setShaderReflection_, (nint)shaderReflection);
    }

    public void SetShaderValidation(MTLShaderValidation shaderValidation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineOptions_Selectors.setShaderValidation_, (nint)(uint)shaderValidation);
    }

}
