namespace Metal.NET;

public readonly struct MTLCounter(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterBindings.Name);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }
}

file static class MTLCounterBindings
{
    public static readonly Selector Name = Selector.Register("name");
}
