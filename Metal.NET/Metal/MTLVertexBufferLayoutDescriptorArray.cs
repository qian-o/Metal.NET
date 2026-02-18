namespace Metal.NET;

public class MTLVertexBufferLayoutDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLVertexBufferLayoutDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLVertexBufferLayoutDescriptorArraySelector.Class))
    {
    }

    public MTLVertexBufferLayoutDescriptor? Object(nuint index)
    {
        return GetNullableObject<MTLVertexBufferLayoutDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexBufferLayoutDescriptorArraySelector.Object, index));
    }

    public void SetObject(MTLVertexBufferLayoutDescriptor bufferDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorArraySelector.SetObject, bufferDesc.NativePtr, index);
    }
}

file static class MTLVertexBufferLayoutDescriptorArraySelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexBufferLayoutDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
