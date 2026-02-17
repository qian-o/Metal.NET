namespace Metal.NET;

public class MTLResidencySetDescriptor : IDisposable
{
    public MTLResidencySetDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLResidencySetDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLResidencySetDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLResidencySetDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLResidencySetDescriptor");

    public MTLResidencySetDescriptor() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public nuint InitialCapacity
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResidencySetDescriptorSelector.InitialCapacity);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetDescriptorSelector.SetInitialCapacity, (nuint)value);
    }

    public NSString Label
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResidencySetDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetDescriptorSelector.SetLabel, value.NativePtr);
    }

}

file class MTLResidencySetDescriptorSelector
{
    public static readonly Selector InitialCapacity = Selector.Register("initialCapacity");

    public static readonly Selector SetInitialCapacity = Selector.Register("setInitialCapacity:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
