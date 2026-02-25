namespace Metal.NET;

public class MTL4CommitOptions(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4CommitOptions>
{
    public static MTL4CommitOptions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4CommitOptions Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTL4CommitOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CommitOptionsBindings.Class), NativeObjectOwnership.Managed)
    {
    }
}

file static class MTL4CommitOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommitOptions");
}
