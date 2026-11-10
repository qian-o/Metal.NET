namespace Metal.NET;

public readonly struct MTLIntersectionFunctionTableDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLIntersectionFunctionTableDescriptor value) => new(value.NativePtr);

    public MTLIntersectionFunctionTableDescriptor() : this(ObjectiveC.AllocInit(MTLIntersectionFunctionTableDescriptorBindings.Class))
    {
    }

    public MTLIntersectionFunctionTableDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public nuint FunctionCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIntersectionFunctionTableDescriptorBindings.FunctionCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableDescriptorBindings.SetFunctionCount, value);
    }

    public static MTLIntersectionFunctionTableDescriptor IntersectionFunctionTableDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLIntersectionFunctionTableDescriptorBindings.Class, MTLIntersectionFunctionTableDescriptorBindings.IntersectionFunctionTableDescriptor);

        return new(nativePtr);
    }
}

file static class MTLIntersectionFunctionTableDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLIntersectionFunctionTableDescriptor");

    public static readonly Selector FunctionCount = "functionCount";

    public static readonly Selector IntersectionFunctionTableDescriptor = "intersectionFunctionTableDescriptor";

    public static readonly Selector SetFunctionCount = "setFunctionCount:";
}
