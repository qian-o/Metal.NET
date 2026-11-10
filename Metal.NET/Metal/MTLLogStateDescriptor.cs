namespace Metal.NET;

public readonly struct MTLLogStateDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLLogStateDescriptor value) => new(value.NativePtr);

    public MTLLogStateDescriptor() : this(ObjectiveC.AllocInit(MTLLogStateDescriptorBindings.Class))
    {
    }

    public MTLLogStateDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLLogLevel Level
    {
        get => (MTLLogLevel)ObjectiveC.MsgSendLong(NativePtr, MTLLogStateDescriptorBindings.Level);
        set => ObjectiveC.MsgSend(NativePtr, MTLLogStateDescriptorBindings.SetLevel, (nint)value);
    }

    public nint BufferSize
    {
        get => ObjectiveC.MsgSendNInt(NativePtr, MTLLogStateDescriptorBindings.BufferSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLLogStateDescriptorBindings.SetBufferSize, value);
    }
}

file static class MTLLogStateDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLLogStateDescriptor");

    public static readonly Selector BufferSize = "bufferSize";

    public static readonly Selector Level = "level";

    public static readonly Selector SetBufferSize = "setBufferSize:";

    public static readonly Selector SetLevel = "setLevel:";
}
