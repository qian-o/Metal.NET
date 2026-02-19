namespace Metal.NET;

public class MTL4RenderPipelineBinaryFunctionsDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4RenderPipelineBinaryFunctionsDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.Class))
    {
    }

    public NSArray? FragmentAdditionalBinaryFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.FragmentAdditionalBinaryFunctions);

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
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetFragmentAdditionalBinaryFunctions, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSArray? MeshAdditionalBinaryFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.MeshAdditionalBinaryFunctions);

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
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetMeshAdditionalBinaryFunctions, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSArray? ObjectAdditionalBinaryFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.ObjectAdditionalBinaryFunctions);

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
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetObjectAdditionalBinaryFunctions, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSArray? TileAdditionalBinaryFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.TileAdditionalBinaryFunctions);

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
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetTileAdditionalBinaryFunctions, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSArray? VertexAdditionalBinaryFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.VertexAdditionalBinaryFunctions);

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
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetVertexAdditionalBinaryFunctions, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.Reset);
    }
}

file static class MTL4RenderPipelineBinaryFunctionsDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineBinaryFunctionsDescriptor");

    public static readonly Selector FragmentAdditionalBinaryFunctions = Selector.Register("fragmentAdditionalBinaryFunctions");

    public static readonly Selector MeshAdditionalBinaryFunctions = Selector.Register("meshAdditionalBinaryFunctions");

    public static readonly Selector ObjectAdditionalBinaryFunctions = Selector.Register("objectAdditionalBinaryFunctions");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetFragmentAdditionalBinaryFunctions = Selector.Register("setFragmentAdditionalBinaryFunctions:");

    public static readonly Selector SetMeshAdditionalBinaryFunctions = Selector.Register("setMeshAdditionalBinaryFunctions:");

    public static readonly Selector SetObjectAdditionalBinaryFunctions = Selector.Register("setObjectAdditionalBinaryFunctions:");

    public static readonly Selector SetTileAdditionalBinaryFunctions = Selector.Register("setTileAdditionalBinaryFunctions:");

    public static readonly Selector SetVertexAdditionalBinaryFunctions = Selector.Register("setVertexAdditionalBinaryFunctions:");

    public static readonly Selector TileAdditionalBinaryFunctions = Selector.Register("tileAdditionalBinaryFunctions");

    public static readonly Selector VertexAdditionalBinaryFunctions = Selector.Register("vertexAdditionalBinaryFunctions");
}
