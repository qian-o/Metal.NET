namespace Metal.NET;

public class MTL4LibraryFunctionDescriptor(nint nativePtr) : MTL4FunctionDescriptor(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4LibraryFunctionDescriptor");

    public MTLLibrary Library
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryFunctionDescriptorSelector.Library));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryFunctionDescriptorSelector.SetLibrary, value.NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryFunctionDescriptorSelector.Name));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryFunctionDescriptorSelector.SetName, value.NativePtr);
    }

    public static implicit operator nint(MTL4LibraryFunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4LibraryFunctionDescriptor(nint value)
    {
        return new(value);
    }
}

file class MTL4LibraryFunctionDescriptorSelector
{
    public static readonly Selector Library = Selector.Register("library");

    public static readonly Selector SetLibrary = Selector.Register("setLibrary:");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector SetName = Selector.Register("setName:");
}
