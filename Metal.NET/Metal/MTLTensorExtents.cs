namespace Metal.NET;

public readonly struct MTLTensorExtents(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLTensorExtents value) => new(value.NativePtr);

    public MTLTensorExtents() : this(ObjectiveC.AllocInit(MTLTensorExtentsBindings.Class))
    {
    }

    public MTLTensorExtents Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public nuint Rank
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTensorExtentsBindings.Rank);
    }

    public nint ExtentAtDimensionIndex(nuint dimensionIndex)
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLTensorExtentsBindings.ExtentAtDimensionIndex, dimensionIndex);
    }

    public static MTLTensorExtents InitWithRank(nuint rank, nint values)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(MTLTensorExtentsBindings.Class), MTLTensorExtentsBindings.InitWithRank_Values, rank, values);

        return new(nativePtr);
    }
}

file static class MTLTensorExtentsBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTensorExtents");

    public static readonly Selector ExtentAtDimensionIndex = "extentAtDimensionIndex:";

    public static readonly Selector InitWithRank_Values = "initWithRank:values:";

    public static readonly Selector Rank = "rank";
}
