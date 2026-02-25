namespace Metal.NET;

public class MTLType(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLType>
{
    public static MTLType Null { get; } = new(0, false);

    public static MTLType Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLType() : this(ObjectiveCRuntime.AllocInit(MTLTypeBindings.Class), true, true)
    {
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTypeBindings.DataType);
    }
}

file static class MTLTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLType");

    public static readonly Selector DataType = "dataType";
}
