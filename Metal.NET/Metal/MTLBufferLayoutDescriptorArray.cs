namespace Metal.NET;

public class MTLBufferLayoutDescriptorArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLBufferLayoutDescriptorArray>
{
    public static MTLBufferLayoutDescriptorArray Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLBufferLayoutDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLBufferLayoutDescriptorArrayBindings.Class), true)
    {
    }

    public MTLBufferLayoutDescriptor this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferLayoutDescriptorArrayBindings.Object, index);

            return new(nativePtr, false);
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
