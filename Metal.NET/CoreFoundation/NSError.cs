namespace Metal.NET;

public readonly struct NSError(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(NSError value) => new(value.NativePtr);

    public NSError Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public int Code
    {
        get => ObjectiveC.MsgSendInt(NativePtr, NSErrorBindings.Code);
    }

    public NSString Domain
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, NSErrorBindings.Domain));
    }

    public NSString LocalizedDescription
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, NSErrorBindings.LocalizedDescription));
    }
}

file static class NSErrorBindings
{
    public static readonly Selector Code = "code";

    public static readonly Selector Domain = "domain";

    public static readonly Selector LocalizedDescription = "localizedDescription";
}
