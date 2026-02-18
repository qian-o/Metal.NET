namespace Metal.NET;

public partial class MTL4FunctionDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4FunctionDescriptor");

    public MTL4FunctionDescriptor(nint nativePtr) : base(nativePtr)
    {
    }
}

file static class MTL4FunctionDescriptorSelector
{
}
