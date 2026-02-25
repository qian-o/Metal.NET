namespace Metal.NET;

public class MTLAccelerationStructureDescriptor(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLAccelerationStructureDescriptor>
{
    public static MTLAccelerationStructureDescriptor Create(nint nativePtr) => new(nativePtr);

    public static MTLAccelerationStructureDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

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

    public static readonly Selector SetUsage = "setUsage:";

    public static readonly Selector Usage = "usage";
}
