namespace Metal.NET;

public partial class MTLAccelerationStructureDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureDescriptor");

    public MTLAccelerationStructureDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint Usage
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureDescriptorSelector.Usage);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureDescriptorSelector.SetUsage, value);
    }
}

file static class MTLAccelerationStructureDescriptorSelector
{
    public static readonly Selector SetUsage = Selector.Register("setUsage:");

    public static readonly Selector Usage = Selector.Register("usage");
}
