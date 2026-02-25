namespace Metal.NET;

public class MTL4CommitOptions(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4CommitOptions>
{
    public static MTL4CommitOptions Null { get; } = new(0, false);

    public static MTL4CommitOptions Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTL4CommitOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CommitOptionsBindings.Class), true)
    {
        GC.ReRegisterForFinalize(this);
    }
}

file static class MTL4CommitOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommitOptions");
}
