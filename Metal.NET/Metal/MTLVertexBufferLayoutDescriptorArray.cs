namespace Metal.NET;

public class MTLVertexBufferLayoutDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLVertexBufferLayoutDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLVertexBufferLayoutDescriptorArrayBindings.Class))
    {
    }

    public MTLVertexBufferLayoutDescriptor? Object(nuint index)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexBufferLayoutDescriptorArrayBindings.Object, index);

        if (nativePtr is 0)
        {
            return null;
        }

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr);
    }

    public void SetObject(MTLVertexBufferLayoutDescriptor bufferDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorArrayBindings.SetObject, bufferDesc.NativePtr, index);
    }
}

file static class MTLVertexBufferLayoutDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexBufferLayoutDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
