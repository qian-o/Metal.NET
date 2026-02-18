namespace Metal.NET;

public class MTL4LibraryFunctionDescriptor(nint nativePtr) : MTL4FunctionDescriptor(nativePtr)
{
    public MTL4LibraryFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4LibraryFunctionDescriptorSelector.Class))
    {
    }

    public MTLLibrary? Library
    {
        get => GetNullableObject<MTLLibrary>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryFunctionDescriptorSelector.Library));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryFunctionDescriptorSelector.SetLibrary, value?.NativePtr ?? 0);
    }

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryFunctionDescriptorSelector.Name));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryFunctionDescriptorSelector.SetName, value?.NativePtr ?? 0);
    }
}

file static class MTL4LibraryFunctionDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4LibraryFunctionDescriptor");

    public static readonly Selector Library = Selector.Register("library");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector SetLibrary = Selector.Register("setLibrary:");

    public static readonly Selector SetName = Selector.Register("setName:");
}
