namespace Metal.NET;

public class MTLTensorExtents(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLTensorExtents>
{
    #region INativeObject
    public static new MTLTensorExtents Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTensorExtents New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public nuint Rank
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTensorExtentsBindings.Rank);
    }

    public nint InitWithRankValues(nuint rank, nint values)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLTensorExtentsBindings.InitWithRank, rank, values);
    }

    public nint Init(nuint rank, nint values)
    {
        return InitWithRankValues(rank, values);
    }

    public nint ExtentAtDimensionIndex(nuint dimensionIndex)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLTensorExtentsBindings.ExtentAtDimensionIndex, dimensionIndex);
    }
}

file static class MTLTensorExtentsBindings
{
    public static readonly Selector ExtentAtDimensionIndex = "extentAtDimensionIndex:";

    public static readonly Selector InitWithRank = "initWithRank:values:";

    public static readonly Selector Rank = "rank";
}
