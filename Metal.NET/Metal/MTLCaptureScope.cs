namespace Metal.NET;

public class MTLCaptureScope(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLCommandQueue? CommandQueue
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureScopeBindings.CommandQueue);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLCommandQueue(ptr);
            }

            return field;
        }
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureScopeBindings.Device);

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

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCaptureScopeBindings.Label);

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
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureScopeBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public void BeginScope()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureScopeBindings.BeginScope);
    }

    public void EndScope()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCaptureScopeBindings.EndScope);
    }
}

file static class MTLCaptureScopeBindings
{
    public static readonly Selector BeginScope = Selector.Register("beginScope");

    public static readonly Selector CommandQueue = Selector.Register("commandQueue");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector EndScope = Selector.Register("endScope");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
