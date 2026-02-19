namespace Metal.NET;

public class MTL4RenderPipelineDynamicLinkingDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4RenderPipelineDynamicLinkingDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineDynamicLinkingDescriptorBindings.Class))
    {
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? FragmentLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorBindings.FragmentLinkingDescriptor);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4PipelineStageDynamicLinkingDescriptor(ptr);
            }

            return field;
        }
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? MeshLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorBindings.MeshLinkingDescriptor);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4PipelineStageDynamicLinkingDescriptor(ptr);
            }

            return field;
        }
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? ObjectLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorBindings.ObjectLinkingDescriptor);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4PipelineStageDynamicLinkingDescriptor(ptr);
            }

            return field;
        }
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? TileLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorBindings.TileLinkingDescriptor);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4PipelineStageDynamicLinkingDescriptor(ptr);
            }

            return field;
        }
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? VertexLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorBindings.VertexLinkingDescriptor);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4PipelineStageDynamicLinkingDescriptor(ptr);
            }

            return field;
        }
    }
}

file static class MTL4RenderPipelineDynamicLinkingDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineDynamicLinkingDescriptor");

    public static readonly Selector FragmentLinkingDescriptor = Selector.Register("fragmentLinkingDescriptor");

    public static readonly Selector MeshLinkingDescriptor = Selector.Register("meshLinkingDescriptor");

    public static readonly Selector ObjectLinkingDescriptor = Selector.Register("objectLinkingDescriptor");

    public static readonly Selector TileLinkingDescriptor = Selector.Register("tileLinkingDescriptor");

    public static readonly Selector VertexLinkingDescriptor = Selector.Register("vertexLinkingDescriptor");
}
