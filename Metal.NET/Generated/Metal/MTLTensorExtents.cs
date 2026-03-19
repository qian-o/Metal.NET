namespace Metal.NET;

public partial class MTLTensorExtents(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLTensorExtents>
{
    #region INativeObject
    public static new MTLTensorExtents Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTensorExtents New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLTensorExtents() : this(ObjectiveC.AllocInit(MTLTensorExtentsBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint Rank
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTensorExtentsBindings.Rank);
    }

    public nint ExtentAtDimensionIndex(nuint dimensionIndex)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLTensorExtentsBindings.ExtentAtDimensionIndex, dimensionIndex);
    }

    public static MTLTensorExtents InitWithRank_Values(nuint rank, nint values)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(MTLTensorExtentsBindings.Class), MTLTensorExtentsBindings.InitWithRank_Values, rank, values);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }
}

file static class MTLTensorExtentsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTensorExtents");

    public static readonly Selector ExtentAtDimensionIndex = "extentAtDimensionIndex:";

    public static readonly Selector InitWithRank_Values = "initWithRank:values:";

    public static readonly Selector Rank = "rank";
}
