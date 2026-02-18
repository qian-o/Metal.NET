namespace Metal.NET;

public class MTLFunction : IDisposable
{
    public MTLFunction(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLFunction()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.Device));
    }

    public nint FunctionConstantsDictionary
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.FunctionConstantsDictionary);
    }

    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionSelector.FunctionType));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionSelector.SetLabel, value.NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.Name));
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionSelector.Options));
    }

    public nint PatchControlPointCount
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.PatchControlPointCount);
    }

    public MTLPatchType PatchType
    {
        get => (MTLPatchType)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionSelector.PatchType));
    }

    public NSArray StageInputAttributes
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.StageInputAttributes));
    }

    public NSArray VertexAttributes
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.VertexAttributes));
    }

    public MTLArgumentEncoder NewArgumentEncoder(nuint bufferIndex)
    {
        MTLArgumentEncoder result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.NewArgumentEncoder, bufferIndex));

        return result;
    }

    public MTLArgumentEncoder NewArgumentEncoder(nuint bufferIndex, nint reflection)
    {
        MTLArgumentEncoder result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionSelector.NewArgumentEncoderReflection, bufferIndex, reflection));

        return result;
    }

    public static implicit operator nint(MTLFunction value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunction(nint value)
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
}

file class MTLFunctionSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector FunctionConstantsDictionary = Selector.Register("functionConstantsDictionary");

    public static readonly Selector FunctionType = Selector.Register("functionType");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector PatchControlPointCount = Selector.Register("patchControlPointCount");

    public static readonly Selector PatchType = Selector.Register("patchType");

    public static readonly Selector StageInputAttributes = Selector.Register("stageInputAttributes");

    public static readonly Selector VertexAttributes = Selector.Register("vertexAttributes");

    public static readonly Selector NewArgumentEncoder = Selector.Register("newArgumentEncoder:");

    public static readonly Selector NewArgumentEncoderReflection = Selector.Register("newArgumentEncoder:reflection:");
}
