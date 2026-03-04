namespace Metal.NET;

public class MTLTensorExtents(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLTensorExtents>
{
    public static MTLTensorExtents Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLTensorExtents Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLTensorExtents() : this(ObjectiveC.AllocInit(MTLTensorExtentsBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint Rank
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTensorExtentsBindings.Rank);
    }

    public nint ExtentAtDimensionIndex(nuint dimensionIndex)
    {
        return ObjectiveC.MsgSendPtr(NativePtr, MTLTensorExtentsBindings.ExtentAtDimensionIndex, dimensionIndex);
    }
}

file static class MTLTensorExtentsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTensorExtents");

    public static readonly Selector ExtentAtDimensionIndex = "extentAtDimensionIndex:";

    public static readonly Selector Rank = "rank";
}
