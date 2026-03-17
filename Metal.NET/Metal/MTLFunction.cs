namespace Metal.NET;

/// <summary>
/// A interface that represents a public shader function in a Metal library.
/// </summary>
public class MTLFunction(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunction>
{
    #region INativeObject
    public static new MTLFunction Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunction New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying shader functions - Properties

    /// <summary>
    /// The device object that created the shader function.
    /// </summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLFunctionBindings.Device);
    }

    /// <summary>
    /// A string that identifies the shader function.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLFunctionBindings.Label);
        set => SetProperty(ref field, MTLFunctionBindings.SetLabel, value);
    }

    /// <summary>
    /// The shader function’s type.
    /// </summary>
    public MTLFunctionType FunctionType
    {
        get => (MTLFunctionType)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionBindings.FunctionType);
    }

    /// <summary>
    /// The function’s name.
    /// </summary>
    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionBindings.Name);
    }

    /// <summary>
    /// The options that Metal used to compile this function.
    /// </summary>
    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionBindings.Options);
    }
    #endregion

    #region Identifying the tessellation patch - Properties

    /// <summary>
    /// The tessellation patch type of a post-tessellation vertex function.
    /// </summary>
    public MTLPatchType PatchType
    {
        get => (MTLPatchType)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionBindings.PatchType);
    }

    /// <summary>
    /// The number of patch control points in the post-tessellation vertex function.
    /// </summary>
    public nint PatchControlPointCount
    {
        get => ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionBindings.PatchControlPointCount);
    }
    #endregion

    #region Retrieving function attributes - Properties

    /// <summary>
    /// An array that describes the vertex input attributes to a vertex function.
    /// </summary>
    public MTLVertexAttribute[] VertexAttributes
    {
        get => GetArrayProperty<MTLVertexAttribute>(MTLFunctionBindings.VertexAttributes);
    }

    /// <summary>
    /// An array that describes the input attributes to the function.
    /// </summary>
    public MTLAttribute[] StageInputAttributes
    {
        get => GetArrayProperty<MTLAttribute>(MTLFunctionBindings.StageInputAttributes);
    }
    #endregion

    #region Retrieving function constants - Properties

    /// <summary>
    /// A dictionary of function constants for a specialized function.
    /// </summary>
    public NSDictionary FunctionConstantsDictionary
    {
        get => GetProperty(ref field, MTLFunctionBindings.FunctionConstantsDictionary);
    }
    #endregion

    #region Creating argument encoders - Methods

    /// <summary>
    /// Creates an argument encoder for an argument buffer that’s one of this function’s arguments.
    /// </summary>
    public MTLArgumentEncoder NewArgumentEncoder(nuint bufferIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionBindings.NewArgumentEncoder, bufferIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates an argument encoder for an argument buffer that’s one of this function’s arguments.
    /// </summary>
    public MTLArgumentEncoder NewArgumentEncoder(nuint bufferIndex, out MTLArgument reflection)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionBindings.NewArgumentEncoderWithBufferIndexreflection, bufferIndex, out nint reflectionPtr);

        reflection = new(reflectionPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion
}

file static class MTLFunctionBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector FunctionConstantsDictionary = "functionConstantsDictionary";

    public static readonly Selector FunctionType = "functionType";

    public static readonly Selector Label = "label";

    public static readonly Selector Name = "name";

    public static readonly Selector NewArgumentEncoder = "newArgumentEncoderWithBufferIndex:";

    public static readonly Selector NewArgumentEncoderWithBufferIndexreflection = "newArgumentEncoderWithBufferIndex:reflection:";

    public static readonly Selector Options = "options";

    public static readonly Selector PatchControlPointCount = "patchControlPointCount";

    public static readonly Selector PatchType = "patchType";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector StageInputAttributes = "stageInputAttributes";

    public static readonly Selector VertexAttributes = "vertexAttributes";
}
