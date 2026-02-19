namespace Metal.NET;

public class MTLRenderPipelineReflection(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRenderPipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineReflectionBindings.Class))
    {
    }

    public NSArray? FragmentArguments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.FragmentArguments);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
    }

    public NSArray? FragmentBindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.FragmentBindings);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
    }

    public NSArray? MeshBindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.MeshBindings);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
    }

    public NSArray? ObjectBindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.ObjectBindings);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
    }

    public NSArray? TileArguments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.TileArguments);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
    }

    public NSArray? TileBindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.TileBindings);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
    }

    public NSArray? VertexArguments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.VertexArguments);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
    }

    public NSArray? VertexBindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineReflectionBindings.VertexBindings);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
    }
}

file static class MTLRenderPipelineReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPipelineReflection");

    public static readonly Selector FragmentArguments = Selector.Register("fragmentArguments");

    public static readonly Selector FragmentBindings = Selector.Register("fragmentBindings");

    public static readonly Selector MeshBindings = Selector.Register("meshBindings");

    public static readonly Selector ObjectBindings = Selector.Register("objectBindings");

    public static readonly Selector TileArguments = Selector.Register("tileArguments");

    public static readonly Selector TileBindings = Selector.Register("tileBindings");

    public static readonly Selector VertexArguments = Selector.Register("vertexArguments");

    public static readonly Selector VertexBindings = Selector.Register("vertexBindings");
}
