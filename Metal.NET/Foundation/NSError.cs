namespace Metal.NET;

public class NSError : IDisposable
{
    public NSError(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~NSError()
    {
        Release();
    }

    public nint NativePtr { get; }

    public string LocalizedDescription => (NSString)ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorSelector.LocalizedDescription);

    public nint Code => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorSelector.Code);

    public string Domain => (NSString)ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorSelector.Domain);

    public static implicit operator nint(NSError value)
    {
        return value.NativePtr;
    }

    public static implicit operator NSError(nint value)
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

file class NSErrorSelector
{
    public static readonly Selector LocalizedDescription = Selector.Register("localizedDescription");

    public static readonly Selector Code = Selector.Register("code");

    public static readonly Selector Domain = Selector.Register("domain");
}
