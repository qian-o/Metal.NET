namespace Metal.NET;

/// <summary>An array of length matching the rank, holding the dimensions of a tensor.</summary>
public class MTLTensorExtents(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLTensorExtents>
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

    #region Instance Properties - Properties

    /// <summary>Obtains the rank of the tensor.</summary>
    public nuint Rank
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTensorExtentsBindings.Rank);
    }
    #endregion

    public nint ExtentAtDimensionIndex(nuint dimensionIndex)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLTensorExtentsBindings.ExtentAtDimensionIndex, dimensionIndex);
    }
}

file static class MTLTensorExtentsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTensorExtents");

    public static readonly Selector ExtentAtDimensionIndex = "extentAtDimensionIndex:";

    public static readonly Selector Rank = "rank";
}
