namespace Metal.NET;

/// <summary>An array of buffer layout descriptor objects.</summary>
public class MTLBufferLayoutDescriptorArray(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLBufferLayoutDescriptorArray>
{
    #region INativeObject
    public static new MTLBufferLayoutDescriptorArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLBufferLayoutDescriptorArray New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLBufferLayoutDescriptorArray() : this(ObjectiveC.AllocInit(MTLBufferLayoutDescriptorArrayBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLBufferLayoutDescriptor this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLBufferLayoutDescriptorArrayBindings.Object, index);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLBufferLayoutDescriptorArrayBindings.SetObject, value.NativePtr, index);
        }
    }
}

file static class MTLBufferLayoutDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLBufferLayoutDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
