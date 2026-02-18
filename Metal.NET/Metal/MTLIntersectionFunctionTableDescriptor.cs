namespace Metal.NET;

public class MTLIntersectionFunctionTableDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLIntersectionFunctionTableDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIntersectionFunctionTableDescriptorSelector.Class))
    {
    }

    public nuint FunctionCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIntersectionFunctionTableDescriptorSelector.FunctionCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableDescriptorSelector.SetFunctionCount, value);
    }

    public static MTLIntersectionFunctionTableDescriptor? IntersectionFunctionTableDescriptor()
    {
        return GetNullableObject<MTLIntersectionFunctionTableDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLIntersectionFunctionTableDescriptorSelector.Class, MTLIntersectionFunctionTableDescriptorSelector.IntersectionFunctionTableDescriptor));
    }
}

file static class MTLIntersectionFunctionTableDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionTableDescriptor");

    public static readonly Selector FunctionCount = Selector.Register("functionCount");

    public static readonly Selector IntersectionFunctionTableDescriptor = Selector.Register("intersectionFunctionTableDescriptor");

    public static readonly Selector SetFunctionCount = Selector.Register("setFunctionCount:");
}
