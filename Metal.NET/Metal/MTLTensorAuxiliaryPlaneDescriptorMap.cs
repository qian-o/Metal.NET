namespace Metal.NET;

public class MTLTensorAuxiliaryPlaneDescriptorMap(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLTensorAuxiliaryPlaneDescriptorMap>
{
    #region INativeObject
    public static new MTLTensorAuxiliaryPlaneDescriptorMap Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTensorAuxiliaryPlaneDescriptorMap New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public void SetDescriptor(MTLTensorAuxiliaryPlaneDescriptor descriptor, MTLTensorPlaneType plane)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorAuxiliaryPlaneDescriptorMapBindings.SetDescriptor_ForPlane, descriptor.NativePtr, (nint)plane);
    }

    public MTLTensorAuxiliaryPlaneDescriptor Descriptor(MTLTensorPlaneType plane)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLTensorAuxiliaryPlaneDescriptorMapBindings.DescriptorForPlane, (nint)plane);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorAuxiliaryPlaneDescriptorMapBindings.Reset);
    }
}

file static class MTLTensorAuxiliaryPlaneDescriptorMapBindings
{
    public static readonly Selector DescriptorForPlane = "descriptorForPlane:";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetDescriptor_ForPlane = "setDescriptor:forPlane:";
}
