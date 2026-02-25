namespace Metal.NET;

public class MTL4FunctionDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4FunctionDescriptor>
{
    public static MTL4FunctionDescriptor Create(nint nativePtr) => new(nativePtr, true);

    public static MTL4FunctionDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTL4FunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4FunctionDescriptorBindings.Class), true)
    {
    }
}

file static class MTL4FunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4FunctionDescriptor");
}
