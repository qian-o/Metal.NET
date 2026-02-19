namespace Metal.NET;

public class MTLBufferLayoutDescriptorArray(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLBufferLayoutDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLBufferLayoutDescriptorArrayBindings.Class), true)
    {
    }

    public MTLBufferLayoutDescriptor? Object(nuint index)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferLayoutDescriptorArrayBindings.Object, index);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public void SetObject(MTLBufferLayoutDescriptor bufferDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorArrayBindings.SetObject, bufferDesc.NativePtr, index);
    }
}

file static class MTLBufferLayoutDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBufferLayoutDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
