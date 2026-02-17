namespace Metal.NET;

public class MTLResourceStatePassDescriptor : IDisposable
{
    public MTLResourceStatePassDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLResourceStatePassDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLResourceStatePassDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLResourceStatePassDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLResourceStatePassDescriptor");

    public static MTLResourceStatePassDescriptor ResourceStatePassDescriptor()
    {
        MTLResourceStatePassDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLResourceStatePassDescriptorSelector.ResourceStatePassDescriptor));

        return result;
    }

}

file class MTLResourceStatePassDescriptorSelector
{
    public static readonly Selector ResourceStatePassDescriptor = Selector.Register("resourceStatePassDescriptor");
}
