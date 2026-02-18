namespace Metal.NET;

public class MTL4LibraryDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4LibraryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4LibraryDescriptorSelector.Class))
    {
    }

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryDescriptorSelector.Name));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryDescriptorSelector.SetName, value?.NativePtr ?? 0);
    }

    public MTLCompileOptions? Options
    {
        get => GetNullableObject<MTLCompileOptions>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryDescriptorSelector.Options));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryDescriptorSelector.SetOptions, value?.NativePtr ?? 0);
    }

    public NSString? Source
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryDescriptorSelector.Source));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryDescriptorSelector.SetSource, value?.NativePtr ?? 0);
    }
}

file static class MTL4LibraryDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4LibraryDescriptor");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetName = Selector.Register("setName:");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");

    public static readonly Selector SetSource = Selector.Register("setSource:");

    public static readonly Selector Source = Selector.Register("source");
}
