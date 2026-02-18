namespace Metal.NET;

public partial class MTL4LibraryDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4LibraryDescriptor");

    public MTL4LibraryDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryDescriptorSelector.Name);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryDescriptorSelector.SetName, value?.NativePtr ?? 0);
    }

    public MTLCompileOptions? Options
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryDescriptorSelector.Options);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryDescriptorSelector.SetOptions, value?.NativePtr ?? 0);
    }

    public NSString? Source
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryDescriptorSelector.Source);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryDescriptorSelector.SetSource, value?.NativePtr ?? 0);
    }
}

file static class MTL4LibraryDescriptorSelector
{
    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetName = Selector.Register("setName:");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");

    public static readonly Selector SetSource = Selector.Register("setSource:");

    public static readonly Selector Source = Selector.Register("source");
}
