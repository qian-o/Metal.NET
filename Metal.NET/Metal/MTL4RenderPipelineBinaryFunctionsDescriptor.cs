namespace Metal.NET;

public class MTL4RenderPipelineBinaryFunctionsDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4RenderPipelineBinaryFunctionsDescriptor>
{
    #region INativeObject
    public static new MTL4RenderPipelineBinaryFunctionsDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4RenderPipelineBinaryFunctionsDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4RenderPipelineBinaryFunctionsDescriptor() : this(ObjectiveC.AllocInit(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.Reset);
    }
}

file static class MTL4RenderPipelineBinaryFunctionsDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4RenderPipelineBinaryFunctionsDescriptor");

    public static readonly Selector Reset = "reset";
}
