namespace Metal.NET;

/// <summary>
/// Groups together properties to drive the dynamic linking process of a pipeline stage.
/// </summary>
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

    #region Instance Properties - Properties

    /// <summary>
    /// Provides the array of binary functions to link.
    /// </summary>
    public MTL4BinaryFunction[] BinaryLinkedFunctions
    {
        get => GetArrayProperty<MTL4BinaryFunction>(MTL4PipelineStageDynamicLinkingDescriptorBindings.BinaryLinkedFunctions);
        set => SetArrayProperty(MTL4PipelineStageDynamicLinkingDescriptorBindings.SetBinaryLinkedFunctions, value);
    }

    /// <summary>
    /// Limits the maximum depth of the call stack for indirect function calls in the pipeline stage function.
    /// </summary>
    public nuint MaxCallStackDepth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.MaxCallStackDepth);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.SetMaxCallStackDepth, value);
    }

    /// <summary>
    /// Provides an array of dynamic libraries the compiler loads when it builds the pipeline.
    /// </summary>
    public MTLDynamicLibrary[] PreloadedLibraries
    {
        get => GetArrayProperty<MTLDynamicLibrary>(MTL4PipelineStageDynamicLinkingDescriptorBindings.PreloadedLibraries);
        set => SetArrayProperty(MTL4PipelineStageDynamicLinkingDescriptorBindings.SetPreloadedLibraries, value);
    }
    #endregion
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
