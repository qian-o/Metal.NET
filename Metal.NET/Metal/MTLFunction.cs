namespace Metal.NET;

public class MTLFunction(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunction>
{
    #region INativeObject
    public static new MTLFunction Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunction New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLFunctionBindings.Device);
    }

    public NSDictionary FunctionConstantsDictionary
    {
        get => GetProperty(ref field, MTLFunctionBindings.FunctionConstantsDictionary);
    }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionBindings.FunctionType);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLFunctionBindings.Label);
        set => SetProperty(ref field, MTLFunctionBindings.SetLabel, value);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionBindings.Name);
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionBindings.Options);
    }

    public nint PatchControlPointCount
    {
        get => ObjectiveC.MsgSendPtr(NativePtr, MTLFunctionBindings.PatchControlPointCount);
    }

    public MTLPatchType PatchType
    {
        get => (MTLPatchType)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionBindings.PatchType);
    }

    public MTLAttribute[] StageInputAttributes
    {
        get => GetArrayProperty<MTLAttribute>(MTLFunctionBindings.StageInputAttributes);
    }

    public MTLVertexAttribute[] VertexAttributes
    {
        get => GetArrayProperty<MTLVertexAttribute>(MTLFunctionBindings.VertexAttributes);
    }

    public MTLArgumentEncoder NewArgumentEncoder(nuint bufferIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLFunctionBindings.NewArgumentEncoder, bufferIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLFunctionBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionConstantsDictionary = "functionConstantsDictionary";

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
