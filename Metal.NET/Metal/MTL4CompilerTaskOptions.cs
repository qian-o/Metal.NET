namespace Metal.NET;

public class MTL4CompilerTaskOptions : IDisposable
{
    public MTL4CompilerTaskOptions(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4CompilerTaskOptions()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray LookupArchives
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerTaskOptionsSelector.LookupArchives));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerTaskOptionsSelector.SetLookupArchives, value.NativePtr);
    }

    public static implicit operator nint(MTL4CompilerTaskOptions value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CompilerTaskOptions(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTL4CompilerTaskOptionsSelector
{
    public static readonly Selector LookupArchives = Selector.Register("lookupArchives");

    public static readonly Selector SetLookupArchives = Selector.Register("setLookupArchives:");
}
