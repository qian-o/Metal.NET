namespace Metal.NET;

public class MTL4CompilerTaskOptions(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4CompilerTaskOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CompilerTaskOptionsSelector.Class))
    {
    }

    public NSArray? LookupArchives
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerTaskOptionsSelector.LookupArchives));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerTaskOptionsSelector.SetLookupArchives, value?.NativePtr ?? 0);
    }
}

file static class MTL4CompilerTaskOptionsSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CompilerTaskOptions");

    public static readonly Selector LookupArchives = Selector.Register("lookupArchives");

    public static readonly Selector SetLookupArchives = Selector.Register("setLookupArchives:");
}
