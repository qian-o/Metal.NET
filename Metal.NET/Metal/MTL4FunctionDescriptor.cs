namespace Metal.NET;

public class MTL4FunctionDescriptor(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public MTL4FunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4FunctionDescriptorBindings.Class), false)
    {
    }
}

file static class MTL4FunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4FunctionDescriptor");
}
