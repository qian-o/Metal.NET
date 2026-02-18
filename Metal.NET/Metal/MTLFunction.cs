namespace Metal.NET;

public class MTLFunction(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.Device));
    }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionSelector.FunctionType);
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.Name));
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
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.StageInputAttributes));
    }

    public NSArray? VertexAttributes
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.VertexAttributes));
    }

    public MTLArgumentEncoder? NewArgumentEncoder(nuint bufferIndex)
    {
        return GetNullableObject<MTLArgumentEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.NewArgumentEncoder, bufferIndex));
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
