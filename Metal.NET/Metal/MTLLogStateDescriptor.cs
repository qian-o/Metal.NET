namespace Metal.NET;

public class MTLLogStateDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLLogStateDescriptor>
{
    public static MTLLogStateDescriptor Null { get; } = new(0, false);

    public static MTLLogStateDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLLogStateDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLLogStateDescriptorBindings.Class), true)
    {
        GC.ReRegisterForFinalize(this);
    }

    public nint BufferSize
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLogStateDescriptorBindings.BufferSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLogStateDescriptorBindings.SetBufferSize, value);
    }

    public MTLLogLevel Level
    {
        get => (MTLLogLevel)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLogStateDescriptorBindings.Level);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLogStateDescriptorBindings.SetLevel, (nint)value);
    }
}

file static class MTLLogStateDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLLogStateDescriptor");

    public static readonly Selector BufferSize = "bufferSize";

    public static readonly Selector Level = "level";

    public static readonly Selector SetBufferSize = "setBufferSize:";

    public static readonly Selector SetLevel = "setLevel:";
}
