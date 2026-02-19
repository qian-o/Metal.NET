namespace Metal.NET;

public class MTLIOScratchBuffer(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLBuffer? Buffer
    {
        get => GetProperty(ref field, MTLIOScratchBufferBindings.Buffer);
    }
}

file static class MTLIOScratchBufferBindings
{
    public static readonly Selector Buffer = "buffer";
}
