namespace Metal.NET;

public class MTL4LibraryDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4LibraryDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4LibraryDescriptorBindings.Class))
    {
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryDescriptorBindings.Name);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryDescriptorBindings.SetName, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLCompileOptions? Options
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryDescriptorBindings.Options);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLCompileOptions(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryDescriptorBindings.SetOptions, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSString? Source
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4LibraryDescriptorBindings.Source);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4LibraryDescriptorBindings.SetSource, value?.NativePtr ?? 0);
            field = value;
        }
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
