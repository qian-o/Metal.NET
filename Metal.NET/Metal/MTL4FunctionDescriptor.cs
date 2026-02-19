namespace Metal.NET;

public class MTL4FunctionDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4FunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4FunctionDescriptorBindings.Class))
    {
    }
}

file static class MTL4FunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4FunctionDescriptor");
}
