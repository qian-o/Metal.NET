namespace Metal.NET;

public partial class MTLVertexBufferLayoutDescriptorArray : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexBufferLayoutDescriptorArray");

    public MTLVertexBufferLayoutDescriptorArray(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLVertexBufferLayoutDescriptor? @object(nuint index)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexBufferLayoutDescriptorArraySelector.Object, index);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void SetObject(MTLVertexBufferLayoutDescriptor bufferDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorArraySelector.SetObject, bufferDesc.NativePtr, index);
    }
}

file static class MTLVertexBufferLayoutDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObject = Selector.Register("setObject::");
}
