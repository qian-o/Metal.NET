namespace Metal.NET;

public readonly struct MTL4LibraryDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4LibraryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4LibraryDescriptorBindings.Class))
    {
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryDescriptorBindings.Name);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryDescriptorBindings.SetName, value?.NativePtr ?? 0);
    }

    public MTLCompileOptions? Options
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryDescriptorBindings.Options);
            return ptr is not 0 ? new MTLCompileOptions(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryDescriptorBindings.SetOptions, value?.NativePtr ?? 0);
    }

    public NSString? Source
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryDescriptorBindings.Source);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryDescriptorBindings.SetSource, value?.NativePtr ?? 0);
    }
}

file static class MTL4LibraryDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4LibraryDescriptor");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetName = Selector.Register("setName:");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");

    public static readonly Selector SetSource = Selector.Register("setSource:");

    public static readonly Selector Source = Selector.Register("source");
}
