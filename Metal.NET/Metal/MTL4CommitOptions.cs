namespace Metal.NET;

public class MTL4CommitOptions(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTL4CommitOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CommitOptionsBindings.Class), true)
    {
    }
}

file static class MTL4CommitOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommitOptions");
}
