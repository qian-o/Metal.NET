namespace Metal.NET;

public partial class MTLTensorExtents : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTensorExtents");

    public MTLTensorExtents(nint nativePtr) : base(nativePtr)
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
    public static readonly Selector ExtentAtDimensionIndex = Selector.Register("extentAtDimensionIndex:");

    public static readonly Selector Rank = Selector.Register("rank");
}
