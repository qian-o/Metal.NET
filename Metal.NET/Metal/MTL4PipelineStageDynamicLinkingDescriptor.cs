namespace Metal.NET;

public class MTL4PipelineStageDynamicLinkingDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4PipelineStageDynamicLinkingDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4PipelineStageDynamicLinkingDescriptorBindings.Class))
    {
    }

    public NSArray? BinaryLinkedFunctions
    {
        get => GetProperty(ref field, MTL4PipelineStageDynamicLinkingDescriptorBindings.BinaryLinkedFunctions);
        set => SetProperty(ref field, MTL4PipelineStageDynamicLinkingDescriptorBindings.SetBinaryLinkedFunctions, value);
    }

    public nuint MaxCallStackDepth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.MaxCallStackDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.SetMaxCallStackDepth, value);
    }

    public NSArray? PreloadedLibraries
    {
        get => GetProperty(ref field, MTL4PipelineStageDynamicLinkingDescriptorBindings.PreloadedLibraries);
        set => SetProperty(ref field, MTL4PipelineStageDynamicLinkingDescriptorBindings.SetPreloadedLibraries, value);
    }
}

file static class MTL4PipelineStageDynamicLinkingDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4PipelineStageDynamicLinkingDescriptor");

    public static readonly Selector BinaryLinkedFunctions = "binaryLinkedFunctions";

    public static readonly Selector MaxCallStackDepth = "maxCallStackDepth";

    public static readonly Selector PreloadedLibraries = "preloadedLibraries";

    public static readonly Selector SetBinaryLinkedFunctions = "setBinaryLinkedFunctions:";

    public static readonly Selector SetMaxCallStackDepth = "setMaxCallStackDepth:";

    public static readonly Selector SetPreloadedLibraries = "setPreloadedLibraries:";
}
