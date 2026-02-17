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

    public static MTLResidencySetDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLResidencySetDescriptor(ptr);
    }

    public void SetInitialCapacity(uint initialCapacity)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySetDescriptorSelector.SetInitialCapacity, (nint)initialCapacity);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySetDescriptorSelector.SetLabel, label.NativePtr);
    }

}

file class MTLResidencySetDescriptorSelector
{
    public static readonly Selector SetInitialCapacity = Selector.Register("setInitialCapacity:");
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
