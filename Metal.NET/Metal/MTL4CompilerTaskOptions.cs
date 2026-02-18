namespace Metal.NET;

public partial class MTL4CompilerTaskOptions : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CompilerTaskOptions");

    public MTL4CompilerTaskOptions(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? LookupArchives
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerTaskOptionsSelector.LookupArchives);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerTaskOptionsSelector.SetLookupArchives, value?.NativePtr ?? 0);
    }
}

file static class MTL4CompilerTaskOptionsSelector
{
    public static readonly Selector LookupArchives = Selector.Register("lookupArchives");

    public static readonly Selector SetLookupArchives = Selector.Register("setLookupArchives:");
}
