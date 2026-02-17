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

    public string LocalizedDescription
    {
        get
        {
            NSString nsStr = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorSelector.LocalizedDescription));

            return nsStr.Value;
        }
    }

    public long Code => (long)ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSErrorSelector.Code);

    public string Domain
    {
        get
        {
            NSString nsStr = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorSelector.Domain));

            return nsStr.Value;
        }
    }

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
