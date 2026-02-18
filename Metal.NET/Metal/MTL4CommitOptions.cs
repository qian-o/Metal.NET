namespace Metal.NET;

public class MTL4CommitOptions(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4CommitOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CommitOptionsSelector.Class))
    {
    }
}

file static class MTL4CommitOptionsSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommitOptions");
}
