namespace Metal.NET;

public class MTL4CommitOptions(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTL4CommitOptions>
{
    public static MTL4CommitOptions Create(nint nativePtr) => new(nativePtr);

    public MTL4CommitOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CommitOptionsBindings.Class))
    {
    }
}

file static class MTL4CommitOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommitOptions");
}
