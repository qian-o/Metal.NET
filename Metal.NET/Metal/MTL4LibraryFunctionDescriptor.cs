namespace Metal.NET;

public partial class MTL4LibraryFunctionDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4LibraryFunctionDescriptor");

    public MTL4LibraryFunctionDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLLibrary? Library
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryFunctionDescriptorSelector.Library);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryFunctionDescriptorSelector.SetLibrary, value?.NativePtr ?? 0);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryFunctionDescriptorSelector.Name);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryFunctionDescriptorSelector.SetName, value?.NativePtr ?? 0);
    }
}

file static class MTL4LibraryFunctionDescriptorSelector
{
    public static readonly Selector Library = Selector.Register("library");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector SetLibrary = Selector.Register("setLibrary:");

    public static readonly Selector SetName = Selector.Register("setName:");
}
