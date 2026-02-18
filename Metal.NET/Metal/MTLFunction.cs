namespace Metal.NET;

public partial class MTLFunction : NativeObject
{
    public MTLFunction(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionSelector.FunctionType);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.Name);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionSelector.Options);
    }

    public nint PatchControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.PatchControlPointCount);
    }

    public MTLPatchType PatchType
    {
        get => (MTLPatchType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionSelector.PatchType);
    }

    public NSArray? StageInputAttributes
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.StageInputAttributes);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSArray? VertexAttributes
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.VertexAttributes);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLArgumentEncoder? NewArgumentEncoder(nuint bufferIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.NewArgumentEncoder, bufferIndex);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLFunctionSelector
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
