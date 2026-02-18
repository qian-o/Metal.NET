namespace Metal.NET;

public class MTL4BinaryFunctionDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4BinaryFunctionDescriptor");

    public MTL4BinaryFunctionDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTL4BinaryFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTL4BinaryFunctionDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSString Name
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4BinaryFunctionDescriptorSelector.Name));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorSelector.SetName, value.NativePtr);
    }

    public static implicit operator nint(MTL4BinaryFunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4BinaryFunctionDescriptor(nint value)
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
}

file class MTL4BinaryFunctionDescriptorSelector
{
    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector SetName = Selector.Register("setName:");
}
