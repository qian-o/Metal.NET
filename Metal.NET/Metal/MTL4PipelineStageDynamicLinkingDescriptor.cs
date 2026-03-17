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
}

file static class MTL4PipelineStageDynamicLinkingDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4PipelineStageDynamicLinkingDescriptor");

    public static readonly Selector MaxCallStackDepth = "maxCallStackDepth";

    public static readonly Selector SetMaxCallStackDepth = "setMaxCallStackDepth:";
}
