namespace Metal.NET;

public partial class MTLIntersectionFunctionDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionDescriptor");

    public MTLIntersectionFunctionDescriptor(nint nativePtr) : base(nativePtr)
    {
    }
}

file static class MTLIntersectionFunctionDescriptorSelector
{
}
