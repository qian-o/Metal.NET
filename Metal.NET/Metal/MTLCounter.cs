namespace Metal.NET;

public class MTLCounter(nint nativePtr) : NativeObject(nativePtr)
{

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSelector.Name));
    }
}

file static class MTLCounterSelector
{
    public static readonly Selector Name = Selector.Register("name");
}
