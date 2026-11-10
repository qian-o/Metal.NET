namespace Metal.NET;

public readonly struct MTL4CompilerTaskOptions(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4CompilerTaskOptions value) => new(value.NativePtr);

    public MTL4CompilerTaskOptions() : this(ObjectiveC.AllocInit(MTL4CompilerTaskOptionsBindings.Class))
    {
    }

    public MTL4CompilerTaskOptions Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSArray<MTL4Archive> LookupArchives
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerTaskOptionsBindings.LookupArchives));
        set => ObjectiveC.MsgSend(NativePtr, MTL4CompilerTaskOptionsBindings.SetLookupArchives, value.NativePtr);
    }
}

file static class MTL4CompilerTaskOptionsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CompilerTaskOptions");

    public static readonly Selector LookupArchives = "lookupArchives";

    public static readonly Selector SetLookupArchives = "setLookupArchives:";
}
