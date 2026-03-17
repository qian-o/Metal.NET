namespace Metal.NET;

public class MTLRenderPipelineFunctionsDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRenderPipelineFunctionsDescriptor>
{
    #region INativeObject
    public static new MTLRenderPipelineFunctionsDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPipelineFunctionsDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRenderPipelineFunctionsDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPipelineFunctionsDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }
}

file static class MTLRenderPipelineFunctionsDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPipelineFunctionsDescriptor");
}
