namespace Metal.NET;

public class MTLFunction(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionBindings.Device);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLDevice(ptr);
            }

            return field;
        }
    }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionBindings.FunctionType);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionBindings.Name);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionBindings.Options);
    }

    public nint PatchControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionBindings.PatchControlPointCount);
    }

    public MTLPatchType PatchType
    {
        get => (MTLPatchType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionBindings.PatchType);
    }

    public NSArray? StageInputAttributes
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionBindings.StageInputAttributes);

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

    public NSArray? VertexAttributes
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionBindings.VertexAttributes);

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

    public MTLArgumentEncoder? NewArgumentEncoder(nuint bufferIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionBindings.NewArgumentEncoder, bufferIndex);
        return ptr is not 0 ? new MTLArgumentEncoder(ptr) : null;
    }
}

file static class MTLFunctionBindings
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector FunctionType = Selector.Register("functionType");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector NewArgumentEncoder = Selector.Register("newArgumentEncoderWithBufferIndex:");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector PatchControlPointCount = Selector.Register("patchControlPointCount");

    public static readonly Selector PatchType = Selector.Register("patchType");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector StageInputAttributes = Selector.Register("stageInputAttributes");

    public static readonly Selector VertexAttributes = Selector.Register("vertexAttributes");
}
