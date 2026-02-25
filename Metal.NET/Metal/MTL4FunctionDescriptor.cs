namespace Metal.NET;

public class MTL4FunctionDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4FunctionDescriptor>
{
    public static MTL4FunctionDescriptor Null { get; } = new(0, false);

    public static MTL4FunctionDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTL4FunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4FunctionDescriptorBindings.Class), true)
    {
        IsFullyManaged = true;
    }
}

file static class MTL4FunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4FunctionDescriptor");
}
