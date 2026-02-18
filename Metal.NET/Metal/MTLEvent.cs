namespace Metal.NET;

public class MTLEvent(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLEventSelector.Device));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLEventSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLEventSelector.SetLabel, value?.NativePtr ?? 0);
    }
}

file static class MTLEventSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
