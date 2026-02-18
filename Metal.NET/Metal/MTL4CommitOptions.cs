namespace Metal.NET;

public partial class MTL4CommitOptions : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommitOptions");

    public MTL4CommitOptions(nint nativePtr) : base(nativePtr)
    {
    }
}

file static class MTL4CommitOptionsSelector
{
}
