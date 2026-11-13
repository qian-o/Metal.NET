namespace Metal.NET;

public readonly struct MTL4CompilerDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4CompilerDescriptor value) => new(value.NativePtr);

    public MTL4CompilerDescriptor() : this(ObjectiveC.AllocInit(MTL4CompilerDescriptorBindings.Class))
    {
    }

    public MTL4CompilerDescriptor Retain()
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
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4CompilerDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTL4PipelineDataSetSerializer PipelineDataSetSerializer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerDescriptorBindings.PipelineDataSetSerializer));
        set => ObjectiveC.MsgSend(NativePtr, MTL4CompilerDescriptorBindings.SetPipelineDataSetSerializer, value.NativePtr);
    }
}

file static class MTL4CompilerDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CompilerDescriptor");

    public static readonly Selector Label = "label";

    public static readonly Selector PipelineDataSetSerializer = "pipelineDataSetSerializer";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetPipelineDataSetSerializer = "setPipelineDataSetSerializer:";
}
