namespace Metal.NET;

/// <summary>
/// Base class for all Metal 4 acceleration structure geometry descriptors.
/// </summary>
public class MTL4AccelerationStructureGeometryDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4AccelerationStructureGeometryDescriptor>
{
    #region INativeObject
    public static new MTL4AccelerationStructureGeometryDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4AccelerationStructureGeometryDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4AccelerationStructureGeometryDescriptor() : this(ObjectiveC.AllocInit(MTL4AccelerationStructureGeometryDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// A boolean value that indicates whether the ray-tracing system in Metal allows the invocation of intersection functions more than once per ray-primitive intersection.
    /// </summary>
    public Bool8 AllowDuplicateIntersectionFunctionInvocation
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.AllowDuplicateIntersectionFunctionInvocation);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetAllowDuplicateIntersectionFunctionInvocation, value);
    }

    /// <summary>
    /// Sets the offset that this geometry contributes to determining the intersection function to invoke when a ray intersects it.
    /// </summary>
    public nuint IntersectionFunctionTableOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.IntersectionFunctionTableOffset);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetIntersectionFunctionTableOffset, value);
    }

    /// <summary>
    /// Assigns an optional label you can assign to this geometry for debugging purposes.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTL4AccelerationStructureGeometryDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4AccelerationStructureGeometryDescriptorBindings.SetLabel, value);
    }

    /// <summary>
    /// Provides a hint to Metal that this geometry is opaque, potentially accelerating the ray/primitive intersection process.
    /// </summary>
    public Bool8 Opaque
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.Opaque);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetOpaque, value);
    }

    /// <summary>
    /// Assigns optional buffer containing data to associate with each primitive in this geometry.
    /// </summary>
    public MTL4BufferRange PrimitiveDataBuffer
    {
        get => ObjectiveC.MsgSendMTL4BufferRange(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.PrimitiveDataBuffer);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataBuffer, value);
    }

    /// <summary>
    /// Sets the size, in bytes, of the data for each primitive in the primitive data buffer  references.
    /// </summary>
    public nuint PrimitiveDataElementSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.PrimitiveDataElementSize);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataElementSize, value);
    }

    /// <summary>
    /// Defines the stride, in bytes, between each primitive’s data in the primitive data buffer  references.
    /// </summary>
    public nuint PrimitiveDataStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.PrimitiveDataStride);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureGeometryDescriptorBindings.SetPrimitiveDataStride, value);
    }
    #endregion
}

file static class MTL4AccelerationStructureGeometryDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4AccelerationStructureGeometryDescriptor");

    public static readonly Selector AllowDuplicateIntersectionFunctionInvocation = "allowDuplicateIntersectionFunctionInvocation";

    public static readonly Selector IntersectionFunctionTableOffset = "intersectionFunctionTableOffset";

    public static readonly Selector Label = "label";

    public static readonly Selector Opaque = "opaque";

    public static readonly Selector PrimitiveDataBuffer = "primitiveDataBuffer";

    public static readonly Selector PrimitiveDataElementSize = "primitiveDataElementSize";

    public static readonly Selector PrimitiveDataStride = "primitiveDataStride";

    public static readonly Selector SetAllowDuplicateIntersectionFunctionInvocation = "setAllowDuplicateIntersectionFunctionInvocation:";

    public static readonly Selector SetIntersectionFunctionTableOffset = "setIntersectionFunctionTableOffset:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOpaque = "setOpaque:";

    public static readonly Selector SetPrimitiveDataBuffer = "setPrimitiveDataBuffer:";

    public static readonly Selector SetPrimitiveDataElementSize = "setPrimitiveDataElementSize:";

    public static readonly Selector SetPrimitiveDataStride = "setPrimitiveDataStride:";
}
