namespace Metal.NET;

public class MTLLogicalToPhysicalColorAttachmentMap : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLLogicalToPhysicalColorAttachmentMap");

    public MTLLogicalToPhysicalColorAttachmentMap(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLLogicalToPhysicalColorAttachmentMap() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLLogicalToPhysicalColorAttachmentMap()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLLogicalToPhysicalColorAttachmentMap value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLLogicalToPhysicalColorAttachmentMap(nint value)
    {
        return new(value);
    }

    public nuint GetPhysicalIndex(nuint logicalIndex)
    {
        nuint result = ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLLogicalToPhysicalColorAttachmentMapSelector.GetPhysicalIndexForLogicalIndex, logicalIndex);

        return result;
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapSelector.Reset);
    }

    public void SetPhysicalIndex(nuint physicalIndex, nuint logicalIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMapSelector.SetPhysicalIndexForLogicalIndex, physicalIndex, logicalIndex);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLLogicalToPhysicalColorAttachmentMapSelector
{
    public static readonly Selector GetPhysicalIndexForLogicalIndex = Selector.Register("getPhysicalIndexForLogicalIndex:");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetPhysicalIndexForLogicalIndex = Selector.Register("setPhysicalIndex:forLogicalIndex:");
}
