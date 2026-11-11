namespace Metal.NET;

public readonly struct NSURL(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(NSURL value) => new(value.NativePtr);

    public NSURL(NSString filePath) : this(ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSURLBindings.Class), NSURLBindings.InitFileURLWithPath, filePath.NativePtr))
    {
    }

    public NSURL Retain()
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
}

file static class NSURLBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSURL");

    public static readonly Selector InitFileURLWithPath = "initFileURLWithPath:";
}
