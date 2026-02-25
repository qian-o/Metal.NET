namespace Metal.NET;

public class MTL4CommandAllocator(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4CommandAllocator>
{
    public static MTL4CommandAllocator Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTL4CommandAllocatorBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandAllocatorBindings.Label);
    }

    public ulong AllocatedSize()
    {
        return ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4CommandAllocatorBindings.AllocatedSize);
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
