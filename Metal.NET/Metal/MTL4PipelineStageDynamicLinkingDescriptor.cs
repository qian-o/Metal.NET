namespace Metal.NET;

public class MTL4PipelineStageDynamicLinkingDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4PipelineStageDynamicLinkingDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4PipelineStageDynamicLinkingDescriptorSelector.Class))
    {
    }

    public NSArray? BinaryLinkedFunctions
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.BinaryLinkedFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.SetBinaryLinkedFunctions, value?.NativePtr ?? 0);
    }

    public nuint MaxCallStackDepth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.MaxCallStackDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.SetMaxCallStackDepth, value);
    }

    public NSArray? PreloadedLibraries
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.PreloadedLibraries));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.SetPreloadedLibraries, value?.NativePtr ?? 0);
    }
}

file static class MTL4PipelineStageDynamicLinkingDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4PipelineStageDynamicLinkingDescriptor");

    public static readonly Selector BinaryLinkedFunctions = Selector.Register("binaryLinkedFunctions");

    public static readonly Selector MaxCallStackDepth = Selector.Register("maxCallStackDepth");

    public static readonly Selector PreloadedLibraries = Selector.Register("preloadedLibraries");

    public static readonly Selector SetBinaryLinkedFunctions = Selector.Register("setBinaryLinkedFunctions:");

    public static readonly Selector SetMaxCallStackDepth = Selector.Register("setMaxCallStackDepth:");

    public static readonly Selector SetPreloadedLibraries = Selector.Register("setPreloadedLibraries:");
}
