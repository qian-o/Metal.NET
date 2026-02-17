using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLStageInputOutputDescriptor_Selectors
{
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector setIndexBufferIndex_ = Selector.Register("setIndexBufferIndex:");
    internal static readonly Selector setIndexType_ = Selector.Register("setIndexType:");
    internal static readonly Selector stageInputOutputDescriptor = Selector.Register("stageInputOutputDescriptor");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLStageInputOutputDescriptor
{
    public readonly nint NativePtr;

    public MTLStageInputOutputDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLStageInputOutputDescriptor o) => o.NativePtr;
    public static implicit operator MTLStageInputOutputDescriptor(nint ptr) => new MTLStageInputOutputDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLStageInputOutputDescriptor");

    public static MTLStageInputOutputDescriptor Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTLStageInputOutputDescriptor(ptr);
    }

    public MTLStageInputOutputDescriptor Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTLStageInputOutputDescriptor(ptr);
    }

    public static MTLStageInputOutputDescriptor New()
    {
        return Alloc().Init();
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStageInputOutputDescriptor_Selectors.reset);
    }

    public void SetIndexBufferIndex(nuint indexBufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStageInputOutputDescriptor_Selectors.setIndexBufferIndex_, (nint)indexBufferIndex);
    }

    public void SetIndexType(MTLIndexType indexType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStageInputOutputDescriptor_Selectors.setIndexType_, (nint)(uint)indexType);
    }

    public static MTLStageInputOutputDescriptor StageInputOutputDescriptor()
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLStageInputOutputDescriptor_Selectors.stageInputOutputDescriptor);
        return new MTLStageInputOutputDescriptor(__result);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
