namespace Metal.NET;

public readonly struct MTL4CommandAllocatorDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4CommandAllocatorDescriptor value) => new(value.NativePtr);

    public MTL4CommandAllocatorDescriptor() : this(ObjectiveC.AllocInit(MTL4CommandAllocatorDescriptorBindings.Class))
    {
    }

    public MTL4CommandAllocatorDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CommandAllocatorDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4CommandAllocatorDescriptorBindings.SetLabel, value.NativePtr);
    }
}

file static class MTL4CommandAllocatorDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CommandAllocatorDescriptor");

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
