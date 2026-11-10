namespace Metal.NET;

public readonly struct MTLResourceViewPoolDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLResourceViewPoolDescriptor value) => new(value.NativePtr);

    public MTLResourceViewPoolDescriptor() : this(ObjectiveC.AllocInit(MTLResourceViewPoolDescriptorBindings.Class))
    {
    }

    public MTLResourceViewPoolDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public nuint ResourceViewCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResourceViewPoolDescriptorBindings.ResourceViewCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLResourceViewPoolDescriptorBindings.SetResourceViewCount, value);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLResourceViewPoolDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLResourceViewPoolDescriptorBindings.SetLabel, value.NativePtr);
    }
}

file static class MTLResourceViewPoolDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLResourceViewPoolDescriptor");

    public static readonly Selector Label = "label";

    public static readonly Selector ResourceViewCount = "resourceViewCount";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetResourceViewCount = "setResourceViewCount:";
}
