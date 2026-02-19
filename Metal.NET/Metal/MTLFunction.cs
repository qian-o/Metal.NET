namespace Metal.NET;

public class MTLFunction(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get => GetProperty(ref field, MTLFunctionBindings.Device);
    }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionBindings.FunctionType);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTLFunctionBindings.Label);
        set => SetProperty(ref field, MTLFunctionBindings.SetLabel, value);
    }

    public NSString? Name
    {
        get => GetProperty(ref field, MTLFunctionBindings.Name);
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
        get => GetProperty(ref field, MTLFunctionBindings.StageInputAttributes);
    }

    public NSArray? VertexAttributes
    {
        get => GetProperty(ref field, MTLFunctionBindings.VertexAttributes);
    }

    public MTLArgumentEncoder? NewArgumentEncoder(nuint bufferIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionBindings.NewArgumentEncoder, bufferIndex);
        return ptr is not 0 ? new MTLArgumentEncoder(ptr) : null;
    }
}

file static class MTLFunctionBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionType = "functionType";

    public static readonly Selector Label = "label";

    public static readonly Selector Name = "name";

    public static readonly Selector NewArgumentEncoder = "newArgumentEncoderWithBufferIndex:";

    public static readonly Selector Options = "options";

    public static readonly Selector PatchControlPointCount = "patchControlPointCount";

    public static readonly Selector PatchType = "patchType";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector StageInputAttributes = "stageInputAttributes";

    public static readonly Selector VertexAttributes = "vertexAttributes";
}
