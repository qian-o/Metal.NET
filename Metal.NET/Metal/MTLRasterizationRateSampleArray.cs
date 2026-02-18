namespace Metal.NET;

public partial class MTLRasterizationRateSampleArray : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateSampleArray");

    public MTLRasterizationRateSampleArray(nint nativePtr) : base(nativePtr)
    {
    }

    public nint @object(nuint index)
    {
        return ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateSampleArraySelector.Object, index);
    }

    public void SetObject(nint value, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateSampleArraySelector.SetObject, value, index);
    }
}

file static class MTLRasterizationRateSampleArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObject = Selector.Register("setObject::");
}
