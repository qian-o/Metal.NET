namespace Metal.NET;

public class MTL4StitchedFunctionDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4StitchedFunctionDescriptor");

    public MTL4StitchedFunctionDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTL4StitchedFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTL4StitchedFunctionDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray FunctionDescriptors
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StitchedFunctionDescriptorSelector.FunctionDescriptors));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4StitchedFunctionDescriptorSelector.SetFunctionDescriptors, value.NativePtr);
    }

    public static implicit operator nint(MTL4StitchedFunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4StitchedFunctionDescriptor(nint value)
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

file class MTL4StitchedFunctionDescriptorSelector
{
    public static readonly Selector FunctionDescriptors = Selector.Register("functionDescriptors");

    public static readonly Selector SetFunctionDescriptors = Selector.Register("setFunctionDescriptors:");
}
