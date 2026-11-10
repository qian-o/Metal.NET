namespace Metal.NET;

public readonly struct MTLRasterizationRateSampleArray(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLRasterizationRateSampleArray value) => new(value.NativePtr);

    public MTLRasterizationRateSampleArray Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSNumber this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLRasterizationRateSampleArrayBindings.Object, index);

            return new(nativePtr);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLRasterizationRateSampleArrayBindings.SetObject, value.NativePtr, index);
        }
    }
}

file static class MTLRasterizationRateSampleArrayBindings
{
    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
