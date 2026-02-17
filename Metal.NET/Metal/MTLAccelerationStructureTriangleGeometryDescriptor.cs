namespace Metal.NET;

public class MTLAccelerationStructureTriangleGeometryDescriptor : IDisposable
{
    public MTLAccelerationStructureTriangleGeometryDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLAccelerationStructureTriangleGeometryDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureTriangleGeometryDescriptor");

    public MTLBuffer IndexBuffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.IndexBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetIndexBuffer, value.NativePtr);
    }

    public nuint IndexBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.IndexBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetIndexBufferOffset, value);
    }

    public MTLIndexType IndexType
    {
        get => (MTLIndexType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.IndexType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetIndexType, (uint)value);
    }

    public MTLBuffer TransformationMatrixBuffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.TransformationMatrixBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixBuffer, value.NativePtr);
    }

    public nuint TransformationMatrixBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.TransformationMatrixBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixBufferOffset, value);
    }

    public MTLMatrixLayout TransformationMatrixLayout
    {
        get => (MTLMatrixLayout)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.TransformationMatrixLayout));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTransformationMatrixLayout, (uint)value);
    }

    public nuint TriangleCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.TriangleCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetTriangleCount, value);
    }

    public MTLBuffer VertexBuffer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.VertexBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexBuffer, value.NativePtr);
    }

    public nuint VertexBufferOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.VertexBufferOffset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexBufferOffset, value);
    }

    public MTLAttributeFormat VertexFormat
    {
        get => (MTLAttributeFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.VertexFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexFormat, (uint)value);
    }

    public nuint VertexStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.VertexStride);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureTriangleGeometryDescriptorSelector.SetVertexStride, value);
    }

    public static implicit operator nint(MTLAccelerationStructureTriangleGeometryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureTriangleGeometryDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    public static MTLAccelerationStructureTriangleGeometryDescriptor Descriptor()
    {
        MTLAccelerationStructureTriangleGeometryDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLAccelerationStructureTriangleGeometryDescriptorSelector.Descriptor));

        return result;
    }
}

file class MTLAccelerationStructureTriangleGeometryDescriptorSelector
{
    public static readonly Selector IndexBuffer = Selector.Register("indexBuffer");

    public static readonly Selector SetIndexBuffer = Selector.Register("setIndexBuffer:");

    public static readonly Selector IndexBufferOffset = Selector.Register("indexBufferOffset");

    public static readonly Selector SetIndexBufferOffset = Selector.Register("setIndexBufferOffset:");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector SetIndexType = Selector.Register("setIndexType:");

    public static readonly Selector TransformationMatrixBuffer = Selector.Register("transformationMatrixBuffer");

    public static readonly Selector SetTransformationMatrixBuffer = Selector.Register("setTransformationMatrixBuffer:");

    public static readonly Selector TransformationMatrixBufferOffset = Selector.Register("transformationMatrixBufferOffset");

    public static readonly Selector SetTransformationMatrixBufferOffset = Selector.Register("setTransformationMatrixBufferOffset:");

    public static readonly Selector TransformationMatrixLayout = Selector.Register("transformationMatrixLayout");

    public static readonly Selector SetTransformationMatrixLayout = Selector.Register("setTransformationMatrixLayout:");

    public static readonly Selector TriangleCount = Selector.Register("triangleCount");

    public static readonly Selector SetTriangleCount = Selector.Register("setTriangleCount:");

    public static readonly Selector VertexBuffer = Selector.Register("vertexBuffer");

    public static readonly Selector SetVertexBuffer = Selector.Register("setVertexBuffer:");

    public static readonly Selector VertexBufferOffset = Selector.Register("vertexBufferOffset");

    public static readonly Selector SetVertexBufferOffset = Selector.Register("setVertexBufferOffset:");

    public static readonly Selector VertexFormat = Selector.Register("vertexFormat");

    public static readonly Selector SetVertexFormat = Selector.Register("setVertexFormat:");

    public static readonly Selector VertexStride = Selector.Register("vertexStride");

    public static readonly Selector SetVertexStride = Selector.Register("setVertexStride:");

    public static readonly Selector Descriptor = Selector.Register("descriptor");
}
