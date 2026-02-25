namespace Metal.NET;

public class MTLBufferLayoutDescriptorArray(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLBufferLayoutDescriptorArray>
{
    public static MTLBufferLayoutDescriptorArray Create(nint nativePtr) => new(nativePtr);

    public static MTLBufferLayoutDescriptorArray CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLBufferLayoutDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLBufferLayoutDescriptorArrayBindings.Class))
    {
    }

    public MTLBufferLayoutDescriptor Object(nuint index)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferLayoutDescriptorArrayBindings.Object, index);

        return new(nativePtr);
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
