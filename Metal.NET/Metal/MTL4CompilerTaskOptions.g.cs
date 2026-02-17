namespace Metal.NET;

file class MTL4CompilerTaskOptionsSelector
{
    public static readonly Selector SetLookupArchives_ = Selector.Register("setLookupArchives:");
}

public class MTL4CompilerTaskOptions : IDisposable
{
    public MTL4CompilerTaskOptions(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4CompilerTaskOptions()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public void SetLookupArchives(NSArray lookupArchives)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CompilerTaskOptionsSelector.SetLookupArchives_, lookupArchives.NativePtr);
    }

}
