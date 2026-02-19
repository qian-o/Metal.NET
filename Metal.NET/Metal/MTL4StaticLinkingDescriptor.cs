namespace Metal.NET;

public class MTL4StaticLinkingDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4StaticLinkingDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4StaticLinkingDescriptorBindings.Class))
    {
    }

    public NSArray? FunctionDescriptors
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StaticLinkingDescriptorBindings.FunctionDescriptors);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4StaticLinkingDescriptorBindings.SetFunctionDescriptors, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSArray? PrivateFunctionDescriptors
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StaticLinkingDescriptorBindings.PrivateFunctionDescriptors);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4StaticLinkingDescriptorBindings.SetPrivateFunctionDescriptors, value?.NativePtr ?? 0);
            field = value;
        }
    }
}

file static class MTL4StaticLinkingDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4StaticLinkingDescriptor");

    public static readonly Selector FunctionDescriptors = Selector.Register("functionDescriptors");

    public static readonly Selector PrivateFunctionDescriptors = Selector.Register("privateFunctionDescriptors");

    public static readonly Selector SetFunctionDescriptors = Selector.Register("setFunctionDescriptors:");

    public static readonly Selector SetPrivateFunctionDescriptors = Selector.Register("setPrivateFunctionDescriptors:");
}
