namespace Metal.NET;

public readonly struct MTL4AccelerationStructureDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLAccelerationStructureDescriptor(MTL4AccelerationStructureDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4AccelerationStructureDescriptor value) => new(value.NativePtr);

    public MTL4AccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTL4AccelerationStructureDescriptorBindings.Class))
    {
    }

    public MTL4AccelerationStructureDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLAccelerationStructureUsage Usage
    {
        get => (MTLAccelerationStructureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4AccelerationStructureDescriptorBindings.Usage);
        set => ObjectiveC.MsgSend(NativePtr, MTL4AccelerationStructureDescriptorBindings.SetUsage, (nuint)value);
    }
}

file static class MTL4AccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4AccelerationStructureDescriptor");

    public static readonly Selector SetUsage = "setUsage:";

    public static readonly Selector Usage = "usage";
}
