namespace Metal.NET;

public partial class MTLCounter : NativeObject
{
    public MTLCounter(nint nativePtr) : base(nativePtr)
    {
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSelector.Name);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTLCounterSelector
{
    public static readonly Selector Name = Selector.Register("name");
}
