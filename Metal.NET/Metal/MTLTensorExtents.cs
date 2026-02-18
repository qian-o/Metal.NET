namespace Metal.NET;

public class MTLTensorExtents(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLTensorExtents() : this(ObjectiveCRuntime.AllocInit(MTLTensorExtentsSelector.Class))
    {
    }

    public nuint Rank
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorExtentsSelector.Rank);
    }

    public nint ExtentAtDimensionIndex(nuint dimensionIndex)
    {
        return ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorExtentsSelector.ExtentAtDimensionIndex, dimensionIndex);
    }
}

file static class MTLTensorExtentsSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTensorExtents");

    public static readonly Selector ExtentAtDimensionIndex = Selector.Register("extentAtDimensionIndex:");

    public static readonly Selector Rank = Selector.Register("rank");
}
