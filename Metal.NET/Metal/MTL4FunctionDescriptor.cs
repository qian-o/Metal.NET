namespace Metal.NET;

public class MTL4FunctionDescriptor(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4FunctionDescriptor>
{
    public static MTL4FunctionDescriptor Create(nint nativePtr) => new(nativePtr);

    public static MTL4FunctionDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTL4FunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4FunctionDescriptorBindings.Class))
    {
    }
}

file static class MTL4FunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4FunctionDescriptor");
}
