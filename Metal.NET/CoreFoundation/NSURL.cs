namespace Metal.NET;

public readonly struct NSURL(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(NSURL value) => new(value.NativePtr);

    public NSURL Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public static implicit operator NSURL(NSString value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSURLInteropBindings.Class), NSURLInteropBindings.InitFileURLWithPath, value.NativePtr);

        return new(nativePtr);
    }
}

file static class NSURLInteropBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSURL");

    public static readonly Selector InitFileURLWithPath = "initFileURLWithPath:";
}
