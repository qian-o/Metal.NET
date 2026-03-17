namespace Metal.NET;

/// <summary>
/// A description of the input and output data of a function.
/// </summary>
public class MTLStageInputOutputDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLStageInputOutputDescriptor>
{
    #region INativeObject
    public static new MTLStageInputOutputDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLStageInputOutputDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLStageInputOutputDescriptor() : this(ObjectiveC.AllocInit(MTLStageInputOutputDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Describing argument layouts - Properties

    /// <summary>
    /// An array that describes where and how to fetch data for the function.
    /// </summary>
    public MTLAttributeDescriptorArray Attributes
    {
        get => GetProperty(ref field, MTLStageInputOutputDescriptorBindings.Attributes);
    }

    /// <summary>
    /// An array that describes how the function fetches data.
    /// </summary>
    public MTLBufferLayoutDescriptorArray Layouts
    {
        get => GetProperty(ref field, MTLStageInputOutputDescriptorBindings.Layouts);
    }
    #endregion

    #region Declaring index buffers for indirect compute commands - Properties

    /// <summary>
    /// The location of the index buffer for a compute function using indexed thread addressing.
    /// </summary>
    public nuint IndexBufferIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLStageInputOutputDescriptorBindings.IndexBufferIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLStageInputOutputDescriptorBindings.SetIndexBufferIndex, value);
    }

    /// <summary>
    /// The data type of the indices stored in the index buffer.
    /// </summary>
    public MTLIndexType IndexType
    {
        get => (MTLIndexType)ObjectiveC.MsgSendULong(NativePtr, MTLStageInputOutputDescriptorBindings.IndexType);
        set => ObjectiveC.MsgSend(NativePtr, MTLStageInputOutputDescriptorBindings.SetIndexType, (nuint)value);
    }
    #endregion

    #region Resetting the descriptor - Methods

    /// <summary>
    /// Resets the default state for the descriptor.
    /// </summary>
    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLStageInputOutputDescriptorBindings.Reset);
    }
    #endregion

    public static MTLStageInputOutputDescriptor StageInputOutputDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLStageInputOutputDescriptorBindings.Class, MTLStageInputOutputDescriptorBindings.StageInputOutputDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLStageInputOutputDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLStageInputOutputDescriptor");

    public static readonly Selector Attributes = "attributes";

    public static readonly Selector IndexBufferIndex = "indexBufferIndex";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector Layouts = "layouts";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetIndexBufferIndex = "setIndexBufferIndex:";

    public static readonly Selector SetIndexType = "setIndexType:";

    public static readonly Selector StageInputOutputDescriptor = "stageInputOutputDescriptor";
}
