namespace Metal.NET;

/// <summary>A specification of how to create an intersection function table.</summary>
public class MTLIntersectionFunctionTableDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLIntersectionFunctionTableDescriptor>
{
    #region INativeObject
    public static new MTLIntersectionFunctionTableDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIntersectionFunctionTableDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLIntersectionFunctionTableDescriptor() : this(ObjectiveC.AllocInit(MTLIntersectionFunctionTableDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring the table’s size - Properties

    /// <summary>The number of entries in the intersection function table.</summary>
    public nuint FunctionCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIntersectionFunctionTableDescriptorBindings.FunctionCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableDescriptorBindings.SetFunctionCount, value);
    }
    #endregion

    public static MTLIntersectionFunctionTableDescriptor IntersectionFunctionTableDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLIntersectionFunctionTableDescriptorBindings.Class, MTLIntersectionFunctionTableDescriptorBindings.IntersectionFunctionTableDescriptor);

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
