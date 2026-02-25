namespace Metal.NET;

public class MTLVertexBufferLayoutDescriptorArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLVertexBufferLayoutDescriptorArray>
{
    public static MTLVertexBufferLayoutDescriptorArray Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLVertexBufferLayoutDescriptorArray Null => new(0, false);

    public MTLVertexBufferLayoutDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLVertexBufferLayoutDescriptorArrayBindings.Class), true)
    {
    }

    public MTLVertexBufferLayoutDescriptor this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexBufferLayoutDescriptorArrayBindings.Object, index);

            return new(nativePtr, false);
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorArrayBindings.SetObject, value.NativePtr, index);
        }
    }
}

file static class MTLVertexBufferLayoutDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexBufferLayoutDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
