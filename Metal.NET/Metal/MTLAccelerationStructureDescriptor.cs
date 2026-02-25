namespace Metal.NET;

public class MTLAccelerationStructureDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLAccelerationStructureDescriptor>
{
    public static MTLAccelerationStructureDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLAccelerationStructureDescriptor Null => new(0, false);

    public MTLAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureDescriptorBindings.Class), true)
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

    public static readonly Selector SetUsage = "setUsage:";

    public static readonly Selector Usage = "usage";
}
