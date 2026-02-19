namespace Metal.NET;

public class MTLBinaryArchiveDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLBinaryArchiveDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBinaryArchiveDescriptorBindings.Class))
    {
    }

    public NSURL? Url
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveDescriptorBindings.Url);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSURL(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLBinaryArchiveDescriptorBindings.SetUrl, value?.NativePtr ?? 0);
            field = value;
        }
    }
}

file static class MTLBinaryArchiveDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBinaryArchiveDescriptor");

    public static readonly Selector SetUrl = Selector.Register("setUrl:");

    public static readonly Selector Url = Selector.Register("url");
}
