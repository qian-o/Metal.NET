using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLPrimitiveAccelerationStructureDescriptor_Selectors
{
    internal static readonly Selector setGeometryDescriptors_ = Selector.Register("setGeometryDescriptors:");
    internal static readonly Selector setMotionEndBorderMode_ = Selector.Register("setMotionEndBorderMode:");
    internal static readonly Selector setMotionEndTime_ = Selector.Register("setMotionEndTime:");
    internal static readonly Selector setMotionKeyframeCount_ = Selector.Register("setMotionKeyframeCount:");
    internal static readonly Selector setMotionStartBorderMode_ = Selector.Register("setMotionStartBorderMode:");
    internal static readonly Selector setMotionStartTime_ = Selector.Register("setMotionStartTime:");
    internal static readonly Selector descriptor = Selector.Register("descriptor");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLPrimitiveAccelerationStructureDescriptor
{
    public readonly nint NativePtr;

    public MTLPrimitiveAccelerationStructureDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLPrimitiveAccelerationStructureDescriptor o) => o.NativePtr;
    public static implicit operator MTLPrimitiveAccelerationStructureDescriptor(nint ptr) => new MTLPrimitiveAccelerationStructureDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLPrimitiveAccelerationStructureDescriptor");

    public static MTLPrimitiveAccelerationStructureDescriptor Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTLPrimitiveAccelerationStructureDescriptor(ptr);
    }

    public MTLPrimitiveAccelerationStructureDescriptor Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTLPrimitiveAccelerationStructureDescriptor(ptr);
    }

    public static MTLPrimitiveAccelerationStructureDescriptor New()
    {
        return Alloc().Init();
    }

    public void SetGeometryDescriptors(NSArray geometryDescriptors)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptor_Selectors.setGeometryDescriptors_, geometryDescriptors.NativePtr);
    }

    public void SetMotionEndBorderMode(MTLMotionBorderMode motionEndBorderMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptor_Selectors.setMotionEndBorderMode_, (nint)(uint)motionEndBorderMode);
    }

    public void SetMotionEndTime(float motionEndTime)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptor_Selectors.setMotionEndTime_, motionEndTime);
    }

    public void SetMotionKeyframeCount(nuint motionKeyframeCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptor_Selectors.setMotionKeyframeCount_, (nint)motionKeyframeCount);
    }

    public void SetMotionStartBorderMode(MTLMotionBorderMode motionStartBorderMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptor_Selectors.setMotionStartBorderMode_, (nint)(uint)motionStartBorderMode);
    }

    public void SetMotionStartTime(float motionStartTime)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPrimitiveAccelerationStructureDescriptor_Selectors.setMotionStartTime_, motionStartTime);
    }

    public static MTLPrimitiveAccelerationStructureDescriptor Descriptor()
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLPrimitiveAccelerationStructureDescriptor_Selectors.descriptor);
        return new MTLPrimitiveAccelerationStructureDescriptor(__result);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
