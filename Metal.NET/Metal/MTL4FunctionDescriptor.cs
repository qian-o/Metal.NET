namespace Metal.NET;

public class MTL4FunctionDescriptor(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTL4FunctionDescriptor>
{
    #region INativeObject
    public static MTL4FunctionDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4FunctionDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4FunctionDescriptor() : this(ObjectiveC.AllocInit(MTL4FunctionDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }
}

file static class MTL4FunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4FunctionDescriptor");
}
