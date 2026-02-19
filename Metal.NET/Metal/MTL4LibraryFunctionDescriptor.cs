namespace Metal.NET;

public readonly struct MTL4LibraryFunctionDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4LibraryFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4LibraryFunctionDescriptorBindings.Class))
    {
    }

    public MTLLibrary? Library
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryFunctionDescriptorBindings.Library);
            return ptr is not 0 ? new MTLLibrary(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryFunctionDescriptorBindings.SetLibrary, value?.NativePtr ?? 0);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryFunctionDescriptorBindings.Name);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryFunctionDescriptorBindings.SetName, value?.NativePtr ?? 0);
    }
}

file static class MTL4LibraryFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4LibraryFunctionDescriptor");

    public static readonly Selector Library = Selector.Register("library");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector SetLibrary = Selector.Register("setLibrary:");

    public static readonly Selector SetName = Selector.Register("setName:");
}
