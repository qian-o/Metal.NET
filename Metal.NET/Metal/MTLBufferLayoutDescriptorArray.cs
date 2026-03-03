namespace Metal.NET;

public class MTLBufferLayoutDescriptorArray(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLBufferLayoutDescriptorArray>
{
    public static MTLBufferLayoutDescriptorArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLBufferLayoutDescriptorArray Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLBufferLayoutDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLBufferLayoutDescriptorArrayBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLBufferLayoutDescriptor this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferLayoutDescriptorArrayBindings.Object, index);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorArrayBindings.SetObject, value.NativePtr, index);
        }
    }
}

file static class MTLBufferLayoutDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBufferLayoutDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
