namespace Metal.NET;

public class MTLResourceViewPoolDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLResourceViewPoolDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLResourceViewPoolDescriptorSelector.Class))
    {
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceViewPoolDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceViewPoolDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public nuint ResourceViewCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceViewPoolDescriptorSelector.ResourceViewCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceViewPoolDescriptorSelector.SetResourceViewCount, value);
    }
}

file static class MTLResourceViewPoolDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceViewPoolDescriptor");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector ResourceViewCount = Selector.Register("resourceViewCount");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetResourceViewCount = Selector.Register("setResourceViewCount:");
}
