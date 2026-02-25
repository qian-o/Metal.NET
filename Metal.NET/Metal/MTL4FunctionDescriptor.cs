namespace Metal.NET;

public class MTL4FunctionDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4FunctionDescriptor>
{
    public static MTL4FunctionDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4FunctionDescriptor Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTL4FunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4FunctionDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }
}

file static class MTL4FunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4FunctionDescriptor");
}
