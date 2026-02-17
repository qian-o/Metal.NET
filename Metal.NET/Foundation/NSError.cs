namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSError pointer.
/// </summary>
public class NSError : IDisposable
{
    public nint NativePtr { get; }

    public NSError(nint ptr) => NativePtr = ptr;

    public static implicit operator nint(NSError e) => e.NativePtr;
    public static implicit operator NSError(nint ptr) => new(ptr);

    public bool IsNull => NativePtr == 0;

    private static readonly Selector s_localizedDescription = Selector.Register("localizedDescription");
    private static readonly Selector s_code = Selector.Register("code");
    private static readonly Selector s_domain = Selector.Register("domain");

    public string LocalizedDescription
    {
        get
        {
            var nsStr = new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, s_localizedDescription));
            return nsStr.GetValue();
        }
    }

    public long Code => (long)ObjectiveCRuntime.MsgSendNUInt(NativePtr, s_code);

    public string Domain
    {
        get
        {
            var nsStr = new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, s_domain));
            return nsStr.GetValue();
        }
    }

    ~NSError() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }
}
