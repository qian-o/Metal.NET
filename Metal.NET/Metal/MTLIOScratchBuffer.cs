namespace Metal.NET;

public class MTLIOScratchBuffer(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLBuffer? Buffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOScratchBufferBindings.Buffer);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLBuffer(ptr);
            }

            return field;
        }
    }
}

file static class MTLIOScratchBufferBindings
{
    public static readonly Selector Buffer = Selector.Register("buffer");
}
