namespace Metal.NET;

public readonly struct MTLResourceViewPool(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLResourceViewPool value) => new(value.NativePtr);

    public MTLResourceViewPool Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLResourceID BaseResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLResourceViewPoolBindings.BaseResourceID);
    }

    public nuint ResourceViewCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResourceViewPoolBindings.ResourceViewCount);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLResourceViewPoolBindings.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLResourceViewPoolBindings.Label));
    }

    public MTLResourceID CopyResourceViewsFromPool(MTLResourceViewPool sourcePool, NSRange sourceRange, nuint destinationIndex)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLResourceViewPoolBindings.CopyResourceViewsFromPool_SourceRange_DestinationIndex, sourcePool.NativePtr, sourceRange, destinationIndex);
    }
}

file static class MTLResourceViewPoolBindings
{
    public static readonly Selector BaseResourceID = "baseResourceID";

    public static readonly Selector CopyResourceViewsFromPool_SourceRange_DestinationIndex = "copyResourceViewsFromPool:sourceRange:destinationIndex:";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector ResourceViewCount = "resourceViewCount";
}
