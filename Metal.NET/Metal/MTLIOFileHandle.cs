namespace Metal.NET;

public class MTLIOFileHandle(nint nativePtr) : NativeObject(nativePtr)
{

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOFileHandleSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIOFileHandleSelector.SetLabel, value?.NativePtr ?? 0);
    }
}

file static class MTLIOFileHandleSelector
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
