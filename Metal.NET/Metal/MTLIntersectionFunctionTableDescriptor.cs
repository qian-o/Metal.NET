namespace Metal.NET;

public class MTLIntersectionFunctionTableDescriptor(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLIntersectionFunctionTableDescriptor>
{
    #region INativeObject
    public static MTLIntersectionFunctionTableDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLIntersectionFunctionTableDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLIntersectionFunctionTableDescriptor() : this(ObjectiveC.AllocInit(MTLIntersectionFunctionTableDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint FunctionCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIntersectionFunctionTableDescriptorBindings.FunctionCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableDescriptorBindings.SetFunctionCount, value);
    }

    public static MTLIntersectionFunctionTableDescriptor IntersectionFunctionTableDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(MTLIntersectionFunctionTableDescriptorBindings.Class, MTLIntersectionFunctionTableDescriptorBindings.IntersectionFunctionTableDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLIntersectionFunctionTableDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLIntersectionFunctionTableDescriptor");

    public static readonly Selector FunctionCount = "functionCount";

    public static readonly Selector IntersectionFunctionTableDescriptor = "intersectionFunctionTableDescriptor";

    public static readonly Selector SetFunctionCount = "setFunctionCount:";
}
