namespace Metal.NET;

/// <summary>A base class for descriptors that contain geometry data to convert into a ray-tracing acceleration structure.</summary>
public class MTLAccelerationStructureGeometryDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLAccelerationStructureGeometryDescriptor>
{
    #region INativeObject
    public static new MTLAccelerationStructureGeometryDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAccelerationStructureGeometryDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLAccelerationStructureGeometryDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructureGeometryDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Specifying base geometry properties - Properties

    /// <summary>A label for the geometry structure, suitable for debugging.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLAccelerationStructureGeometryDescriptorBindings.Label);
        set => SetProperty(ref field, MTLAccelerationStructureGeometryDescriptorBindings.SetLabel, value);
    }

    /// <summary>An index into the intersection table for determining which intersection function Metal calls when it intersects a ray with the acceleration structure.</summary>
    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    /// <summary>A Boolean value that determines whether the geometry data in the acceleration structure needs to skip triangle-intersection tests.</summary>
    public Bool8 Opaque
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.Opaque);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetOpaque, value);
    }

    /// <summary>A Boolean value that indicates whether Metal calls the ray-intersection test more than once per primitive on the structure.</summary>
    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLBuffer PrimitiveDataBuffer
    {
        get => GetProperty(ref field, MTLAccelerationStructureGeometryDescriptorBindings.PrimitiveDataBuffer);
        set => SetProperty(ref field, MTLAccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataBuffer, value);
    }

    public nuint PrimitiveDataBufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.PrimitiveDataBufferOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataBufferOffset, value);
    }

    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }

    public nuint PrimitiveDataStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }
    #endregion
}

file static class MTLAccelerationStructureGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructureGeometryDescriptor");

    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";

    public static readonly Selector IntersectionFunctionTableOffset = "intersectionFunctionTableOffset";

    public static readonly Selector Label = "label";

    public static readonly Selector Opaque = "opaque";

    public static readonly Selector PrimitiveDataBuffer = "primitiveDataBuffer";

    public static readonly Selector PrimitiveDataBufferOffset = "primitiveDataBufferOffset";

    public static readonly Selector PrimitiveDataElementSize = "primitiveDataElementSize";

    public static readonly Selector PrimitiveDataStride = "primitiveDataStride";

    public static readonly Selector SetAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";

    public static readonly Selector SetIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOpaque = "setOpaque:";

    public static readonly Selector SetPrimitiveDataBuffer = "setPrimitiveDataBuffer:";

    public static readonly Selector SetPrimitiveDataBufferOffset = "setPrimitiveDataBufferOffset:";

    public static readonly Selector SetPrimitiveDataElementSize = "setPrimitiveDataElementSize:";

    public static readonly Selector SetPrimitiveDataStride = "setPrimitiveDataStride:";
}
