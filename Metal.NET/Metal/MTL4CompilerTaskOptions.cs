namespace Metal.NET;

public readonly struct MTL4CompilerTaskOptions(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4CompilerTaskOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CompilerTaskOptionsBindings.Class))
    {
    }

    public NSArray? LookupArchives
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerTaskOptionsBindings.LookupArchives);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerTaskOptionsBindings.SetLookupArchives, value?.NativePtr ?? 0);
    }
}

file static class MTL4CompilerTaskOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CompilerTaskOptions");

    public static readonly Selector LookupArchives = Selector.Register("lookupArchives");

    public static readonly Selector SetLookupArchives = Selector.Register("setLookupArchives:");
}
