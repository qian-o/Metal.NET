namespace Metal.NET;

public class MTLFence(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFenceSelector.Device));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFenceSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFenceSelector.SetLabel, value?.NativePtr ?? 0);
    }
}

file static class MTLFenceSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
