namespace Metal.NET;

public readonly struct MTLResourceViewPoolDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLResourceViewPoolDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLResourceViewPoolDescriptorBindings.Class))
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceViewPoolDescriptorBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceViewPoolDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public nuint ResourceViewCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceViewPoolDescriptorBindings.ResourceViewCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceViewPoolDescriptorBindings.SetResourceViewCount, value);
    }
}

file static class MTLResourceViewPoolDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceViewPoolDescriptor");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector ResourceViewCount = Selector.Register("resourceViewCount");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetResourceViewCount = Selector.Register("setResourceViewCount:");
}
