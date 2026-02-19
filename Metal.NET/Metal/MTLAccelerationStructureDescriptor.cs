namespace Metal.NET;

public readonly struct MTLAccelerationStructureDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureDescriptorBindings.Class))
    {
    }

    public MTLAccelerationStructureUsage Usage
    {
        get => (MTLAccelerationStructureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureDescriptorBindings.Usage);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureDescriptorBindings.SetUsage, (nuint)value);
    }
}

file static class MTLAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureDescriptor");

    public static readonly Selector SetUsage = Selector.Register("setUsage:");

    public static readonly Selector Usage = Selector.Register("usage");
}
