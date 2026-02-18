namespace Metal.NET;

public class MTLSharedEventHandle(nint nativePtr) : NativeObject(nativePtr)
{
    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventHandleSelector.Label));
    }
}

file static class MTLSharedEventHandleSelector
{
    public static readonly Selector Label = Selector.Register("label");
}
