namespace Metal.NET;

file class MTLBlitPassDescriptorSelector
{
    public static readonly Selector BlitPassDescriptor = Selector.Register("blitPassDescriptor");
}

public class MTLBlitPassDescriptor : IDisposable
{
    public MTLBlitPassDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLBlitPassDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLBlitPassDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLBlitPassDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLBlitPassDescriptor");

    public static MTLBlitPassDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLBlitPassDescriptor(ptr);
    }

    public static MTLBlitPassDescriptor BlitPassDescriptor()
    {
        var result = new MTLBlitPassDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLBlitPassDescriptorSelector.BlitPassDescriptor));

        return result;
    }

}
