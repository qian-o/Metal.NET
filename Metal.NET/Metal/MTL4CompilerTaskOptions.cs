namespace Metal.NET;

public class MTL4CompilerTaskOptions(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4CompilerTaskOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CompilerTaskOptionsBindings.Class))
    {
    }

    public NSArray? LookupArchives
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerTaskOptionsBindings.LookupArchives);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerTaskOptionsBindings.SetLookupArchives, value?.NativePtr ?? 0);
            field = value;
        }
    }
}

file static class MTL4CompilerTaskOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CompilerTaskOptions");

    public static readonly Selector LookupArchives = Selector.Register("lookupArchives");

    public static readonly Selector SetLookupArchives = Selector.Register("setLookupArchives:");
}
