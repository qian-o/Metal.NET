namespace Metal.NET;

public readonly struct MTLBinaryArchiveDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLBinaryArchiveDescriptor value) => new(value.NativePtr);

    public MTLBinaryArchiveDescriptor() : this(ObjectiveC.AllocInit(MTLBinaryArchiveDescriptorBindings.Class))
    {
    }

    public MTLBinaryArchiveDescriptor Retain()
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

    public NSURL Url
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLBinaryArchiveDescriptorBindings.Url));
        set => ObjectiveC.MsgSend(NativePtr, MTLBinaryArchiveDescriptorBindings.SetUrl, value.NativePtr);
    }
}

file static class MTLBinaryArchiveDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLBinaryArchiveDescriptor");

    public static readonly Selector SetUrl = "setUrl:";

    public static readonly Selector Url = "url";
}
