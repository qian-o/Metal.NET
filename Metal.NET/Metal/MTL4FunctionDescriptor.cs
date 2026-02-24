namespace Metal.NET;

public class MTL4FunctionDescriptor(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTL4FunctionDescriptor>
{
    public static MTL4FunctionDescriptor Create(nint nativePtr) => new(nativePtr);
    public MTL4FunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4FunctionDescriptorBindings.Class))
    {
    }
}

file static class MTL4FunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4FunctionDescriptor");
}
