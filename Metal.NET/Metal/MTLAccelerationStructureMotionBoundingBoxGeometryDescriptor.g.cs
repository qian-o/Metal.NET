using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor_Selectors
{
    internal static readonly Selector setBoundingBoxBuffers_ = Selector.Register("setBoundingBoxBuffers:");
    internal static readonly Selector setBoundingBoxCount_ = Selector.Register("setBoundingBoxCount:");
    internal static readonly Selector setBoundingBoxStride_ = Selector.Register("setBoundingBoxStride:");
    internal static readonly Selector descriptor = Selector.Register("descriptor");
}

public class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor o) => o.NativePtr;
    public static implicit operator MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(nint ptr) => new MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(ptr);

    ~MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor");

    public void SetBoundingBoxBuffers(NSArray boundingBoxBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor_Selectors.setBoundingBoxBuffers_, boundingBoxBuffers.NativePtr);
    }

    public void SetBoundingBoxCount(nuint boundingBoxCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor_Selectors.setBoundingBoxCount_, (nint)boundingBoxCount);
    }

    public void SetBoundingBoxStride(nuint boundingBoxStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor_Selectors.setBoundingBoxStride_, (nint)boundingBoxStride);
    }

    public static MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor Descriptor()
    {
        var __r = new MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor_Selectors.descriptor));
        return __r;
    }

}
