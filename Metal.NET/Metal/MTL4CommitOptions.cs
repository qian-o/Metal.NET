namespace Metal.NET;

public class MTL4CommitOptions(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTL4CommitOptions>
{
    public static MTL4CommitOptions Null { get; } = new(0, false);

    public static MTL4CommitOptions Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTL4CommitOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CommitOptionsBindings.Class), true, true)
    {
    }
}

file static class MTL4CommitOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommitOptions");
}
