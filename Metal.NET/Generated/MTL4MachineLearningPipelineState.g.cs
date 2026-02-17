using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4MachineLearningPipelineState_Selectors
{
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTL4MachineLearningPipelineState
{
    public readonly nint NativePtr;

    public MTL4MachineLearningPipelineState(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4MachineLearningPipelineState o) => o.NativePtr;
    public static implicit operator MTL4MachineLearningPipelineState(nint ptr) => new MTL4MachineLearningPipelineState(ptr);

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
