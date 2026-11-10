namespace Metal.NET;

public readonly struct MTLFunction(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLFunction value) => new(value.NativePtr);

    public MTLFunction Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionBindings.SetLabel, value.NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionBindings.Device));
    }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionBindings.FunctionType);
    }

    public MTLPatchType PatchType
    {
        get => (MTLPatchType)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionBindings.PatchType);
    }

    public nint PatchControlPointCount
    {
        get => ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionBindings.PatchControlPointCount);
    }

    public NSArray<MTLVertexAttribute> VertexAttributes
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionBindings.VertexAttributes));
    }

    public NSArray<MTLAttribute> StageInputAttributes
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionBindings.StageInputAttributes));
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionBindings.Name));
    }

    public NSDictionary FunctionConstantsDictionary
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionBindings.FunctionConstantsDictionary));
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionBindings.Options);
    }

    public MTLArgumentEncoder MakeArgumentEncoder(nuint bufferIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionBindings.NewArgumentEncoderWithBufferIndex, bufferIndex);

        return new(nativePtr);
    }

    /// <summary>
    /// Deprecated: Use MTLDevice's newArgumentEncoderWithBufferBinding: instead
    /// </summary>
    [Obsolete("Use MTLDevice's newArgumentEncoderWithBufferBinding: instead")]
    public MTLArgumentEncoder MakeArgumentEncoder(nuint bufferIndex, out MTLArgument reflection)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionBindings.NewArgumentEncoderWithBufferIndex_Reflection, bufferIndex, out nint reflectionPtr);

        reflection = new(reflectionPtr);

        return new(nativePtr);
    }
}

file static class MTLFunctionBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionConstantsDictionary = "functionConstantsDictionary";

    public static readonly Selector FunctionType = "functionType";

    public static readonly Selector Label = "label";

    public static readonly Selector Name = "name";

    public static readonly Selector NewArgumentEncoderWithBufferIndex = "newArgumentEncoderWithBufferIndex:";

    public static readonly Selector NewArgumentEncoderWithBufferIndex_Reflection = "newArgumentEncoderWithBufferIndex:reflection:";

    public static readonly Selector Options = "options";

    public static readonly Selector PatchControlPointCount = "patchControlPointCount";

    public static readonly Selector PatchType = "patchType";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector StageInputAttributes = "stageInputAttributes";

    public static readonly Selector VertexAttributes = "vertexAttributes";
}
