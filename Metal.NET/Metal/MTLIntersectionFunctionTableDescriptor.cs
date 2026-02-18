namespace Metal.NET;

public partial class MTLIntersectionFunctionTableDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionTableDescriptor");

    public MTLIntersectionFunctionTableDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint FunctionCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIntersectionFunctionTableDescriptorSelector.FunctionCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableDescriptorSelector.SetFunctionCount, value);
    }

    public static MTLIntersectionFunctionTableDescriptor? IntersectionFunctionTableDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLIntersectionFunctionTableDescriptorSelector.IntersectionFunctionTableDescriptor);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLIntersectionFunctionTableDescriptorSelector
{
    public static readonly Selector FunctionCount = Selector.Register("functionCount");

    public static readonly Selector IntersectionFunctionTableDescriptor = Selector.Register("intersectionFunctionTableDescriptor");

    public static readonly Selector SetFunctionCount = Selector.Register("setFunctionCount:");
}
