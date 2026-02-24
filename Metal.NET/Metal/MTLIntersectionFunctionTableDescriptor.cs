namespace Metal.NET;

public class MTLIntersectionFunctionTableDescriptor(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLIntersectionFunctionTableDescriptor>
{
    public static MTLIntersectionFunctionTableDescriptor Create(nint nativePtr) => new(nativePtr);
    public MTLIntersectionFunctionTableDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIntersectionFunctionTableDescriptorBindings.Class))
    {
    }

    public nuint FunctionCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIntersectionFunctionTableDescriptorBindings.FunctionCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableDescriptorBindings.SetFunctionCount, value);
    }

    public static MTLIntersectionFunctionTableDescriptor IntersectionFunctionTableDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLIntersectionFunctionTableDescriptorBindings.Class, MTLIntersectionFunctionTableDescriptorBindings.IntersectionFunctionTableDescriptor);

        return new(nativePtr);
    }
}

file static class MTLIntersectionFunctionTableDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionTableDescriptor");

    public static readonly Selector FunctionCount = "functionCount";

    public static readonly Selector IntersectionFunctionTableDescriptor = "intersectionFunctionTableDescriptor";

    public static readonly Selector SetFunctionCount = "setFunctionCount:";
}
