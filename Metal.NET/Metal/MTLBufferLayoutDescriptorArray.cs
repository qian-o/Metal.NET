namespace Metal.NET;

public class MTLBufferLayoutDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLBufferLayoutDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLBufferLayoutDescriptorArraySelector.Class))
    {
    }

    public MTLBufferLayoutDescriptor? Object(nuint index)
    {
        return GetNullableObject<MTLBufferLayoutDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferLayoutDescriptorArraySelector.Object, index));
    }

    public void SetObject(MTLBufferLayoutDescriptor bufferDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorArraySelector.SetObject, bufferDesc.NativePtr, index);
    }
}

file static class MTLBufferLayoutDescriptorArraySelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBufferLayoutDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
