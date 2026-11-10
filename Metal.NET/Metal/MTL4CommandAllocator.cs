namespace Metal.NET;

public readonly struct MTL4CommandAllocator(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4CommandAllocator value) => new(value.NativePtr);

    public MTL4CommandAllocator Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandAllocatorBindings.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandAllocatorBindings.Label));
    }

    public ulong AllocatedSize()
    {
        return ObjectiveC.MsgSendULong(NativePtr, MTL4CommandAllocatorBindings.AllocatedSize);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CommandAllocatorBindings.Reset);
    }
}

file static class MTL4CommandAllocatorBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector Reset = "reset";
}
