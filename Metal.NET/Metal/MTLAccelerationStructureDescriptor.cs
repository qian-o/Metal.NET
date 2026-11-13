namespace Metal.NET;

public readonly struct MTLAccelerationStructureDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLAccelerationStructureDescriptor value) => new(value.NativePtr);

    public MTLAccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructureDescriptorBindings.Class))
    {
    }

    public MTLAccelerationStructureDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLAccelerationStructureUsage Usage
    {
        get => (MTLAccelerationStructureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureDescriptorBindings.Usage);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureDescriptorBindings.SetUsage, (nuint)value);
    }
}

file static class MTLAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructureDescriptor");

    public static readonly Selector SetUsage = "setUsage:";

    public static readonly Selector Usage = "usage";
}
