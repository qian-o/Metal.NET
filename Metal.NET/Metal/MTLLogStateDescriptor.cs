namespace Metal.NET;

public class MTLLogStateDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLLogStateDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLLogStateDescriptorSelector.Class))
    {
    }

    public nint BufferSize
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLogStateDescriptorSelector.BufferSize);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLogStateDescriptorSelector.SetBufferSize, value);
    }

    public MTLLogLevel Level
    {
        get => (MTLLogLevel)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLLogStateDescriptorSelector.Level);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLLogStateDescriptorSelector.SetLevel, (nint)value);
    }
}

file static class MTLLogStateDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLLogStateDescriptor");

    public static readonly Selector BufferSize = Selector.Register("bufferSize");

    public static readonly Selector Level = Selector.Register("level");

    public static readonly Selector SetBufferSize = Selector.Register("setBufferSize:");

    public static readonly Selector SetLevel = Selector.Register("setLevel:");
}
