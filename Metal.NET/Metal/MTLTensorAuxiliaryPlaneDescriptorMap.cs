namespace Metal.NET;

public readonly struct MTLTensorAuxiliaryPlaneDescriptorMap(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLTensorAuxiliaryPlaneDescriptorMap value) => new(value.NativePtr);

    public MTLTensorAuxiliaryPlaneDescriptorMap() : this(ObjectiveC.AllocInit(MTLTensorAuxiliaryPlaneDescriptorMapBindings.Class))
    {
    }

    public MTLTensorAuxiliaryPlaneDescriptorMap Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void SetDescriptor(MTLTensorAuxiliaryPlaneDescriptor descriptor, MTLTensorPlaneType plane)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorAuxiliaryPlaneDescriptorMapBindings.SetDescriptor_ForPlane, descriptor.NativePtr, (nint)plane);
    }

    public MTLTensorAuxiliaryPlaneDescriptor Descriptor(MTLTensorPlaneType plane)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTensorAuxiliaryPlaneDescriptorMapBindings.DescriptorForPlane, (nint)plane);

        return new(nativePtr);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorAuxiliaryPlaneDescriptorMapBindings.Reset);
    }
}

file static class MTLTensorAuxiliaryPlaneDescriptorMapBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTensorAuxiliaryPlaneDescriptorMap");

    public static readonly Selector DescriptorForPlane = "descriptorForPlane:";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetDescriptor_ForPlane = "setDescriptor:forPlane:";
}
