namespace Metal.NET;

public class MTL4PipelineStageDynamicLinkingDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4PipelineStageDynamicLinkingDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4PipelineStageDynamicLinkingDescriptorBindings.Class))
    {
    }

    public NSArray? BinaryLinkedFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.BinaryLinkedFunctions);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.SetBinaryLinkedFunctions, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public nuint MaxCallStackDepth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.MaxCallStackDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.SetMaxCallStackDepth, value);
    }

    public NSArray? PreloadedLibraries
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.PreloadedLibraries);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorBindings.SetPreloadedLibraries, value?.NativePtr ?? 0);
            field = value;
        }
    }
}

file static class MTL4PipelineStageDynamicLinkingDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4PipelineStageDynamicLinkingDescriptor");

    public static readonly Selector BinaryLinkedFunctions = Selector.Register("binaryLinkedFunctions");

    public static readonly Selector MaxCallStackDepth = Selector.Register("maxCallStackDepth");

    public static readonly Selector PreloadedLibraries = Selector.Register("preloadedLibraries");

    public static readonly Selector SetBinaryLinkedFunctions = Selector.Register("setBinaryLinkedFunctions:");

    public static readonly Selector SetMaxCallStackDepth = Selector.Register("setMaxCallStackDepth:");

    public static readonly Selector SetPreloadedLibraries = Selector.Register("setPreloadedLibraries:");
}
