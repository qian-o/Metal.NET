namespace Metal.NET;

public class MTL4PipelineStageDynamicLinkingDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4PipelineStageDynamicLinkingDescriptor>
{
    public static MTL4PipelineStageDynamicLinkingDescriptor Null { get; } = new(0, false);

    public static MTL4PipelineStageDynamicLinkingDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTL4PipelineStageDynamicLinkingDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4PipelineStageDynamicLinkingDescriptorBindings.Class), true)
    {
        IsFullyManaged = true;
    }

    public MTL4BinaryFunction[] BinaryLinkedFunctions
    {
        get => GetArrayProperty<MTL4BinaryFunction>(MTL4PipelineStageDynamicLinkingDescriptorBindings.BinaryLinkedFunctions);
        set => SetArrayProperty(MTL4PipelineStageDynamicLinkingDescriptorBindings.SetBinaryLinkedFunctions, value);
    }

    public nuint MaxCallStackDepth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.MaxCallStackDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.SetMaxCallStackDepth, value);
    }

    public MTLDynamicLibrary[] PreloadedLibraries
    {
        get => GetArrayProperty<MTLDynamicLibrary>(MTL4PipelineStageDynamicLinkingDescriptorBindings.PreloadedLibraries);
        set => SetArrayProperty(MTL4PipelineStageDynamicLinkingDescriptorBindings.SetPreloadedLibraries, value);
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
