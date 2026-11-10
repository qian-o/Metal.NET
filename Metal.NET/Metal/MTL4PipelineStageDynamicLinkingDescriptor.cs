namespace Metal.NET;

public readonly struct MTL4PipelineStageDynamicLinkingDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4PipelineStageDynamicLinkingDescriptor value) => new(value.NativePtr);

    public MTL4PipelineStageDynamicLinkingDescriptor() : this(ObjectiveC.AllocInit(MTL4PipelineStageDynamicLinkingDescriptorBindings.Class))
    {
    }

    public MTL4PipelineStageDynamicLinkingDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public nuint MaxCallStackDepth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.MaxCallStackDepth);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.SetMaxCallStackDepth, value);
    }

    public NSArray<MTL4BinaryFunction> BinaryLinkedFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.BinaryLinkedFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.SetBinaryLinkedFunctions, value.NativePtr);
    }

    public NSArray<MTLDynamicLibrary> PreloadedLibraries
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.PreloadedLibraries));
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.SetPreloadedLibraries, value.NativePtr);
    }
}

file static class MTL4PipelineStageDynamicLinkingDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4PipelineStageDynamicLinkingDescriptor");

    public static readonly Selector BinaryLinkedFunctions = "binaryLinkedFunctions";

    public static readonly Selector MaxCallStackDepth = "maxCallStackDepth";

    public static readonly Selector PreloadedLibraries = "preloadedLibraries";

    public static readonly Selector SetBinaryLinkedFunctions = "setBinaryLinkedFunctions:";

    public static readonly Selector SetMaxCallStackDepth = "setMaxCallStackDepth:";

    public static readonly Selector SetPreloadedLibraries = "setPreloadedLibraries:";
}
