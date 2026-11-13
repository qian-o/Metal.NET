namespace Metal.NET;

public readonly struct MTL4PipelineDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4PipelineDescriptor value) => new(value.NativePtr);

    public MTL4PipelineDescriptor() : this(ObjectiveC.AllocInit(MTL4PipelineDescriptorBindings.Class))
    {
    }

    public MTL4PipelineDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4PipelineDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTL4PipelineOptions Options
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4PipelineDescriptorBindings.Options));
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineDescriptorBindings.SetOptions, value.NativePtr);
    }
}

file static class MTL4PipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4PipelineDescriptor");

    public static readonly Selector Label = "label";

    public static readonly Selector Options = "options";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOptions = "setOptions:";
}
