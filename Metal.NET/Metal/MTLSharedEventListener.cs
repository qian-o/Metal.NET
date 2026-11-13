namespace Metal.NET;

public readonly struct MTLSharedEventListener(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLSharedEventListener value) => new(value.NativePtr);

    public MTLSharedEventListener() : this(ObjectiveC.AllocInit(MTLSharedEventListenerBindings.Class))
    {
    }

    public MTLSharedEventListener Retain()
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

    public DispatchQueue DispatchQueue
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLSharedEventListenerBindings.DispatchQueue));
    }

    public static MTLSharedEventListener Shared()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLSharedEventListenerBindings.Class, MTLSharedEventListenerBindings.SharedListener);

        return new(nativePtr);
    }

    public static MTLSharedEventListener InitWithDispatchQueue(DispatchQueue dispatchQueue)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(MTLSharedEventListenerBindings.Class), MTLSharedEventListenerBindings.InitWithDispatchQueue, dispatchQueue.NativePtr);

        return new(nativePtr);
    }
}

file static class MTLSharedEventListenerBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLSharedEventListener");

    public static readonly Selector DispatchQueue = "dispatchQueue";

    public static readonly Selector InitWithDispatchQueue = "initWithDispatchQueue:";

    public static readonly Selector SharedListener = "sharedListener";
}
