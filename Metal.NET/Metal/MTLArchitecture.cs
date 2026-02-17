namespace Metal.NET;

public class MTLArchitecture : IDisposable
{
    public MTLArchitecture(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLArchitecture()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLArchitecture value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLArchitecture(nint value)
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

    public NSString Name
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArchitectureSelector.Name));
    }

}

file class MTLArchitectureSelector
{
    public static readonly Selector Name = Selector.Register("name");
}
