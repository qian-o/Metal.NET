namespace Metal.NET;

public class MTL4CommitOptions(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4CommitOptions>
{
    public static MTL4CommitOptions Create(nint nativePtr) => new(nativePtr, true);

    public static MTL4CommitOptions CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTL4CommitOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CommitOptionsBindings.Class), true)
    {
    }
}

file static class MTL4CommitOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommitOptions");
}
