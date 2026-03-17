namespace Metal.NET;

/// <summary>
/// An interface that represents a log state configuration.
/// </summary>
public class MTLLogStateDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLLogStateDescriptor>
{
    #region INativeObject
    public static new MTLLogStateDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLLogStateDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLLogStateDescriptor() : this(ObjectiveC.AllocInit(MTLLogStateDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance properties - Properties

    /// <summary>
    /// The size of the internal buffer the log state uses, specified in bytes.
    /// </summary>
    public nint BufferSize
    {
        get => ObjectiveC.MsgSendNInt(NativePtr, MTLLogStateDescriptorBindings.BufferSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLLogStateDescriptorBindings.SetBufferSize, value);
    }

    /// <summary>
    /// The minimum level of messages that the shader can log.
    /// </summary>
    public MTLLogLevel Level
    {
        get => (MTLLogLevel)ObjectiveC.MsgSendLong(NativePtr, MTLLogStateDescriptorBindings.Level);
        set => ObjectiveC.MsgSend(NativePtr, MTLLogStateDescriptorBindings.SetLevel, (nint)value);
    }
    #endregion
}

file static class MTLLogStateDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLLogStateDescriptor");

    public static readonly Selector BufferSize = "bufferSize";

    public static readonly Selector Level = "level";

    public static readonly Selector SetBufferSize = "setBufferSize:";

    public static readonly Selector SetLevel = "setLevel:";
}
