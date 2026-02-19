namespace Metal.NET;

public readonly struct MTL4CommitOptions(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4CommitOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CommitOptionsBindings.Class))
    {
    }
}

file static class MTL4CommitOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommitOptions");
}
