namespace Metal.NET;

public class MTLIntersectionFunctionTableDescriptor(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public MTLIntersectionFunctionTableDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIntersectionFunctionTableDescriptorBindings.Class), false)
    {
    }

    public nuint FunctionCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIntersectionFunctionTableDescriptorBindings.FunctionCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableDescriptorBindings.SetFunctionCount, value);
    }

    public static MTLIntersectionFunctionTableDescriptor? IntersectionFunctionTableDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLIntersectionFunctionTableDescriptorBindings.Class, MTLIntersectionFunctionTableDescriptorBindings.IntersectionFunctionTableDescriptor);

        return nativePtr is not 0 ? new(nativePtr, true) : null;
    }
}

file static class MTLIntersectionFunctionTableDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionTableDescriptor");

    public static readonly Selector FunctionCount = "functionCount";

    public static readonly Selector IntersectionFunctionTableDescriptor = "intersectionFunctionTableDescriptor";

    public static readonly Selector SetFunctionCount = "setFunctionCount:";
}
