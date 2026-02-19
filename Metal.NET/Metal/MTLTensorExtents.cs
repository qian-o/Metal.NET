namespace Metal.NET;

public class MTLTensorExtents(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLTensorExtents() : this(ObjectiveCRuntime.AllocInit(MTLTensorExtentsBindings.Class), true)
    {
    }

    public nuint Rank
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorExtentsBindings.Rank);
    }

    public nint ExtentAtDimensionIndex(nuint dimensionIndex)
    {
        return ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorExtentsBindings.ExtentAtDimensionIndex, dimensionIndex);
    }
}

file static class MTLTensorExtentsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTensorExtents");

    public static readonly Selector ExtentAtDimensionIndex = "extentAtDimensionIndex:";

    public static readonly Selector Rank = "rank";
}
