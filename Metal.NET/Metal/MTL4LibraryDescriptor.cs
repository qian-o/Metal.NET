namespace Metal.NET;

public class MTL4LibraryDescriptor : IDisposable
{
    public MTL4LibraryDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4LibraryDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSString Name
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryDescriptorSelector.Name));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryDescriptorSelector.SetName, value.NativePtr);
    }

    public MTLCompileOptions Options
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryDescriptorSelector.Options));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryDescriptorSelector.SetOptions, value.NativePtr);
    }

    public NSString Source
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryDescriptorSelector.Source));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryDescriptorSelector.SetSource, value.NativePtr);
    }

    public static implicit operator nint(MTL4LibraryDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4LibraryDescriptor(nint value)
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

file class MTL4LibraryDescriptorSelector
{
    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector SetName = Selector.Register("setName:");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");

    public static readonly Selector Source = Selector.Register("source");

    public static readonly Selector SetSource = Selector.Register("setSource:");
}
