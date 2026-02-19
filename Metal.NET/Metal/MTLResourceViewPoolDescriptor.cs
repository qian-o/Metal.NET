namespace Metal.NET;

public class MTLResourceViewPoolDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLResourceViewPoolDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLResourceViewPoolDescriptorBindings.Class))
    {
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTLResourceViewPoolDescriptorBindings.Label);
        set => SetProperty(ref field, MTLResourceViewPoolDescriptorBindings.SetLabel, value);
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

    public static readonly Selector Label = "label";

    public static readonly Selector ResourceViewCount = "resourceViewCount";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetResourceViewCount = "setResourceViewCount:";
}
