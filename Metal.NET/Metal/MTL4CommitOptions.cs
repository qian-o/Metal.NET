namespace Metal.NET;

public class MTL4CommitOptions(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public MTL4CommitOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CommitOptionsBindings.Class), false)
    {
    }
}

file static class MTL4CommitOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommitOptions");
}
