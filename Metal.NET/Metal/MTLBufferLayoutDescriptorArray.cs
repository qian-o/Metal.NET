namespace Metal.NET;

public partial class MTLBufferLayoutDescriptorArray : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBufferLayoutDescriptorArray");

    public MTLBufferLayoutDescriptorArray(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLBufferLayoutDescriptor? @object(nuint index)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferLayoutDescriptorArraySelector.Object, index);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void SetObject(MTLBufferLayoutDescriptor bufferDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorArraySelector.SetObject, bufferDesc.NativePtr, index);
    }
}

file static class MTLBufferLayoutDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObject = Selector.Register("setObject::");
}
