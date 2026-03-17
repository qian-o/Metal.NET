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

    public NSString Label
    {
        get => GetProperty(ref field, MTLFunctionBindings.Label);
        set => SetProperty(ref field, MTLFunctionBindings.SetLabel, value);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLFunctionBindings.Device);
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

    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionBindings.Name);
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionBindings.Options);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLFunctionBindings.Label);
        set => SetProperty(ref field, MTLFunctionBindings.SetLabel, value);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLFunctionBindings.Device);
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

    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionBindings.Name);
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionBindings.Options);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionBindings.SetLabel, label.NativePtr);
    }

    public MTLArgumentEncoder NewArgumentEncoderWithBufferIndex(nuint bufferIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionBindings.NewArgumentEncoderWithBufferIndex, bufferIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Deprecated: Use MTLDevice's newArgumentEncoderWithBufferBinding: instead
    /// </summary>
    [Obsolete("Use MTLDevice's newArgumentEncoderWithBufferBinding: instead")]
    public MTLArgumentEncoder NewArgumentEncoderWithBufferIndex(nuint bufferIndex, out MTLArgument reflection)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionBindings.NewArgumentEncoderWithBufferIndexreflection, bufferIndex, out nint reflectionPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLFunctionBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionType = "functionType";

    public static readonly Selector Label = "label";

    public static readonly Selector Name = "name";

    public static readonly Selector NewArgumentEncoderWithBufferIndex = "newArgumentEncoderWithBufferIndex:";

    public static readonly Selector NewArgumentEncoderWithBufferIndexreflection = "newArgumentEncoderWithBufferIndex:reflection:";

    public static readonly Selector Options = "options";

    public static readonly Selector PatchControlPointCount = "patchControlPointCount";

    public static readonly Selector PatchType = "patchType";

    public static readonly Selector SetLabel = "setLabel:";
}
