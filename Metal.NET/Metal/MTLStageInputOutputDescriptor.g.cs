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

public class MTLStageInputOutputDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLStageInputOutputDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLStageInputOutputDescriptor o) => o.NativePtr;
    public static implicit operator MTLStageInputOutputDescriptor(nint ptr) => new MTLStageInputOutputDescriptor(ptr);

    ~MTLStageInputOutputDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLStageInputOutputDescriptor");

    public static MTLStageInputOutputDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLStageInputOutputDescriptor(ptr);
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
        var __r = new MTLStageInputOutputDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLStageInputOutputDescriptor_Selectors.stageInputOutputDescriptor));
        return __r;
    }

}
