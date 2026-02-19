namespace Metal.NET;

public class MTLSamplerState(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSamplerStateBindings.Device);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLDevice(ptr);
            }

            return field;
        }
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLSamplerStateBindings.GpuResourceID);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSamplerStateBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
    }
}

file static class MTLSamplerStateBindings
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Label = Selector.Register("label");
}
