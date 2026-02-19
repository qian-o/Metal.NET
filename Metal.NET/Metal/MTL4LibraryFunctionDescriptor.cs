namespace Metal.NET;

public class MTL4LibraryFunctionDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4LibraryFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4LibraryFunctionDescriptorBindings.Class))
    {
    }

    public MTLLibrary? Library
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryFunctionDescriptorBindings.Library);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLLibrary(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryFunctionDescriptorBindings.SetLibrary, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryFunctionDescriptorBindings.Name);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryFunctionDescriptorBindings.SetName, value?.NativePtr ?? 0);
            field = value;
        }
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
