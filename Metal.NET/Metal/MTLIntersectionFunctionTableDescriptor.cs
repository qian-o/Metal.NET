namespace Metal.NET;

public readonly struct MTLIntersectionFunctionTableDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLIntersectionFunctionTableDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIntersectionFunctionTableDescriptorBindings.Class))
    {
    }

    public nuint FunctionCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIntersectionFunctionTableDescriptorBindings.FunctionCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableDescriptorBindings.SetFunctionCount, value);
    }

    public static MTLIntersectionFunctionTableDescriptor? IntersectionFunctionTableDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLIntersectionFunctionTableDescriptorBindings.Class, MTLIntersectionFunctionTableDescriptorBindings.IntersectionFunctionTableDescriptor);
        return ptr is not 0 ? new MTLIntersectionFunctionTableDescriptor(ptr) : default;
    }
}

file static class MTLIntersectionFunctionTableDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionTableDescriptor");

    public static readonly Selector FunctionCount = Selector.Register("functionCount");

    public static readonly Selector IntersectionFunctionTableDescriptor = Selector.Register("intersectionFunctionTableDescriptor");

    public static readonly Selector SetFunctionCount = Selector.Register("setFunctionCount:");
}
