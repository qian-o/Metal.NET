namespace Metal.NET;

public class MTLResourceViewPoolDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLResourceViewPoolDescriptor>
{
    public static MTLResourceViewPoolDescriptor Null => Create(0, false);
    public static MTLResourceViewPoolDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLResourceViewPoolDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLResourceViewPoolDescriptorBindings.Class), true)
    {
    }

    public NSString Label
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
