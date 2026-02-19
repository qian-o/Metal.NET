namespace Metal.NET;

public class MTL4CommandAllocator(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public ulong AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4CommandAllocatorBindings.AllocatedSize);
    }

    public MTLDevice? Device
    {
        get => GetProperty(ref field, MTL4CommandAllocatorBindings.Device);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTL4CommandAllocatorBindings.Label);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandAllocatorBindings.Reset);
    }
}

file static class MTL4CommandAllocatorBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector Reset = "reset";
}
