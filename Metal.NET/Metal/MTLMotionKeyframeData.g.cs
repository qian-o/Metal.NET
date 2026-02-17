using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLMotionKeyframeData_Selectors
{
    internal static readonly Selector setBuffer_ = Selector.Register("setBuffer:");
    internal static readonly Selector setOffset_ = Selector.Register("setOffset:");
    internal static readonly Selector data = Selector.Register("data");
}

public class MTLMotionKeyframeData : IDisposable
{
    public nint NativePtr { get; }

    public MTLMotionKeyframeData(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLMotionKeyframeData o) => o.NativePtr;
    public static implicit operator MTLMotionKeyframeData(nint ptr) => new MTLMotionKeyframeData(ptr);

    ~MTLMotionKeyframeData() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLMotionKeyframeData");

    public void SetBuffer(MTLBuffer buffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMotionKeyframeData_Selectors.setBuffer_, buffer.NativePtr);
    }

    public void SetOffset(nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLMotionKeyframeData_Selectors.setOffset_, (nint)offset);
    }

    public static MTLMotionKeyframeData Data()
    {
        var __r = new MTLMotionKeyframeData(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLMotionKeyframeData_Selectors.data));
        return __r;
    }

}
