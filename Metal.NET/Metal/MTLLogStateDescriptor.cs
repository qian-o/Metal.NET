namespace Metal.NET;

public readonly struct MTLLogStateDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLLogStateDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLLogStateDescriptorBindings.Class))
    {
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

    public static readonly Selector BufferSize = Selector.Register("bufferSize");

    public static readonly Selector Level = Selector.Register("level");

    public static readonly Selector SetBufferSize = Selector.Register("setBufferSize:");

    public static readonly Selector SetLevel = Selector.Register("setLevel:");
}
