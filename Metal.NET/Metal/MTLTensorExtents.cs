namespace Metal.NET;

public class MTLTensorExtents(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLTensorExtents>
{
    public static MTLTensorExtents Null { get; } = new(0, false);

    public static MTLTensorExtents Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLTensorExtents() : this(ObjectiveCRuntime.AllocInit(MTLTensorExtentsBindings.Class), true)
    {
        GC.ReRegisterForFinalize(this);
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
