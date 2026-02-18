namespace Metal.NET;

public class MTL4BinaryFunctionDescriptor : IDisposable
{
    public MTL4BinaryFunctionDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTL4BinaryFunctionDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTL4FunctionDescriptor FunctionDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4BinaryFunctionDescriptorSelector.FunctionDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorSelector.SetFunctionDescriptor, value.NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4BinaryFunctionDescriptorSelector.Name));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorSelector.SetName, value.NativePtr);
    }

    public MTL4BinaryFunctionOptions Options
    {
        get => (MTL4BinaryFunctionOptions)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4BinaryFunctionDescriptorSelector.Options));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorSelector.SetOptions, (nuint)value);
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
    public static readonly Selector FunctionDescriptor = Selector.Register("functionDescriptor");

    public static readonly Selector SetFunctionDescriptor = Selector.Register("setFunctionDescriptor:");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector SetName = Selector.Register("setName:");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");
}
