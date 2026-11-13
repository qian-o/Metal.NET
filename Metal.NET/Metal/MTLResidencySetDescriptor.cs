namespace Metal.NET;

public readonly struct MTLResidencySetDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLResidencySetDescriptor value) => new(value.NativePtr);

    public MTLResidencySetDescriptor() : this(ObjectiveC.AllocInit(MTLResidencySetDescriptorBindings.Class))
    {
    }

    public MTLResidencySetDescriptor Retain()
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

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLResidencySetDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLResidencySetDescriptorBindings.SetLabel, value.NativePtr);
    }

    public nuint InitialCapacity
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResidencySetDescriptorBindings.InitialCapacity);
        set => ObjectiveC.MsgSend(NativePtr, MTLResidencySetDescriptorBindings.SetInitialCapacity, value);
    }
}

file static class MTLResidencySetDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLResidencySetDescriptor");

    public static readonly Selector InitialCapacity = "initialCapacity";

    public static readonly Selector Label = "label";

    public static readonly Selector SetInitialCapacity = "setInitialCapacity:";

    public static readonly Selector SetLabel = "setLabel:";
}
