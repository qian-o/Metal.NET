namespace Metal.NET;

public class MTL4SpecializedFunctionDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4SpecializedFunctionDescriptor");

    public MTL4SpecializedFunctionDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTL4SpecializedFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTL4SpecializedFunctionDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLFunctionConstantValues ConstantValues
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4SpecializedFunctionDescriptorSelector.ConstantValues));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorSelector.SetConstantValues, value.NativePtr);
    }

    public MTL4FunctionDescriptor FunctionDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4SpecializedFunctionDescriptorSelector.FunctionDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorSelector.SetFunctionDescriptor, value.NativePtr);
    }

    public NSString SpecializedName
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4SpecializedFunctionDescriptorSelector.SpecializedName));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorSelector.SetSpecializedName, value.NativePtr);
    }

    public static implicit operator nint(MTL4SpecializedFunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4SpecializedFunctionDescriptor(nint value)
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

file class MTL4SpecializedFunctionDescriptorSelector
{
    public static readonly Selector ConstantValues = Selector.Register("constantValues");

    public static readonly Selector SetConstantValues = Selector.Register("setConstantValues:");

    public static readonly Selector FunctionDescriptor = Selector.Register("functionDescriptor");

    public static readonly Selector SetFunctionDescriptor = Selector.Register("setFunctionDescriptor:");

    public static readonly Selector SpecializedName = Selector.Register("specializedName");

    public static readonly Selector SetSpecializedName = Selector.Register("setSpecializedName:");
}
