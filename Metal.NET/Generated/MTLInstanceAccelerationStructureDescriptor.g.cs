using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLInstanceAccelerationStructureDescriptor_Selectors
{
    internal static readonly Selector setInstanceCount_ = Selector.Register("setInstanceCount:");
    internal static readonly Selector setInstanceDescriptorBuffer_ = Selector.Register("setInstanceDescriptorBuffer:");
    internal static readonly Selector setInstanceDescriptorBufferOffset_ = Selector.Register("setInstanceDescriptorBufferOffset:");
    internal static readonly Selector setInstanceDescriptorStride_ = Selector.Register("setInstanceDescriptorStride:");
    internal static readonly Selector setInstanceDescriptorType_ = Selector.Register("setInstanceDescriptorType:");
    internal static readonly Selector setInstanceTransformationMatrixLayout_ = Selector.Register("setInstanceTransformationMatrixLayout:");
    internal static readonly Selector setInstancedAccelerationStructures_ = Selector.Register("setInstancedAccelerationStructures:");
    internal static readonly Selector setMotionTransformBuffer_ = Selector.Register("setMotionTransformBuffer:");
    internal static readonly Selector setMotionTransformBufferOffset_ = Selector.Register("setMotionTransformBufferOffset:");
    internal static readonly Selector setMotionTransformCount_ = Selector.Register("setMotionTransformCount:");
    internal static readonly Selector setMotionTransformStride_ = Selector.Register("setMotionTransformStride:");
    internal static readonly Selector setMotionTransformType_ = Selector.Register("setMotionTransformType:");
    internal static readonly Selector descriptor = Selector.Register("descriptor");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLInstanceAccelerationStructureDescriptor
{
    public readonly nint NativePtr;

    public MTLInstanceAccelerationStructureDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLInstanceAccelerationStructureDescriptor o) => o.NativePtr;
    public static implicit operator MTLInstanceAccelerationStructureDescriptor(nint ptr) => new MTLInstanceAccelerationStructureDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLInstanceAccelerationStructureDescriptor");

    public static MTLInstanceAccelerationStructureDescriptor Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTLInstanceAccelerationStructureDescriptor(ptr);
    }

    public MTLInstanceAccelerationStructureDescriptor Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTLInstanceAccelerationStructureDescriptor(ptr);
    }

    public static MTLInstanceAccelerationStructureDescriptor New()
    {
        return Alloc().Init();
    }

    public void SetInstanceCount(nuint instanceCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptor_Selectors.setInstanceCount_, (nint)instanceCount);
    }

    public void SetInstanceDescriptorBuffer(MTLBuffer instanceDescriptorBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptor_Selectors.setInstanceDescriptorBuffer_, instanceDescriptorBuffer.NativePtr);
    }

    public void SetInstanceDescriptorBufferOffset(nuint instanceDescriptorBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptor_Selectors.setInstanceDescriptorBufferOffset_, (nint)instanceDescriptorBufferOffset);
    }

    public void SetInstanceDescriptorStride(nuint instanceDescriptorStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptor_Selectors.setInstanceDescriptorStride_, (nint)instanceDescriptorStride);
    }

    public void SetInstanceDescriptorType(MTLAccelerationStructureInstanceDescriptorType instanceDescriptorType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptor_Selectors.setInstanceDescriptorType_, (nint)(uint)instanceDescriptorType);
    }

    public void SetInstanceTransformationMatrixLayout(MTLMatrixLayout instanceTransformationMatrixLayout)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptor_Selectors.setInstanceTransformationMatrixLayout_, (nint)(uint)instanceTransformationMatrixLayout);
    }

    public void SetInstancedAccelerationStructures(NSArray instancedAccelerationStructures)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptor_Selectors.setInstancedAccelerationStructures_, instancedAccelerationStructures.NativePtr);
    }

    public void SetMotionTransformBuffer(MTLBuffer motionTransformBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptor_Selectors.setMotionTransformBuffer_, motionTransformBuffer.NativePtr);
    }

    public void SetMotionTransformBufferOffset(nuint motionTransformBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptor_Selectors.setMotionTransformBufferOffset_, (nint)motionTransformBufferOffset);
    }

    public void SetMotionTransformCount(nuint motionTransformCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptor_Selectors.setMotionTransformCount_, (nint)motionTransformCount);
    }

    public void SetMotionTransformStride(nuint motionTransformStride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptor_Selectors.setMotionTransformStride_, (nint)motionTransformStride);
    }

    public void SetMotionTransformType(MTLTransformType motionTransformType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLInstanceAccelerationStructureDescriptor_Selectors.setMotionTransformType_, (nint)(uint)motionTransformType);
    }

    public static MTLInstanceAccelerationStructureDescriptor Descriptor()
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLInstanceAccelerationStructureDescriptor_Selectors.descriptor);
        return new MTLInstanceAccelerationStructureDescriptor(__result);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
