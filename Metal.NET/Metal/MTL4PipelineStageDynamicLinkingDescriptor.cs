namespace Metal.NET;

public class MTL4PipelineStageDynamicLinkingDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4PipelineStageDynamicLinkingDescriptor>
{
    #region INativeObject
    public static new MTL4PipelineStageDynamicLinkingDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4PipelineStageDynamicLinkingDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4PipelineStageDynamicLinkingDescriptor() : this(ObjectiveC.AllocInit(MTL4PipelineStageDynamicLinkingDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint MaxCallStackDepth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.MaxCallStackDepth);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.SetMaxCallStackDepth, value);
    }

    public MTL4BinaryFunction[] BinaryLinkedFunctions
    {
        get => GetArrayProperty<MTL4BinaryFunction>(MTL4PipelineStageDynamicLinkingDescriptorBindings.BinaryLinkedFunctions);
        set => SetArrayProperty(MTL4PipelineStageDynamicLinkingDescriptorBindings.SetBinaryLinkedFunctions, value);
    }

    public MTLDynamicLibrary[] PreloadedLibraries
    {
        get => GetArrayProperty<MTLDynamicLibrary>(MTL4PipelineStageDynamicLinkingDescriptorBindings.PreloadedLibraries);
        set => SetArrayProperty(MTL4PipelineStageDynamicLinkingDescriptorBindings.SetPreloadedLibraries, value);
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
