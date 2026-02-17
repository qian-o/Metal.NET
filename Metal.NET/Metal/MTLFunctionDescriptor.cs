namespace Metal.NET;

public class MTLFunctionDescriptor : IDisposable
{
    public MTLFunctionDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFunctionDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionDescriptor");

    public NSArray BinaryArchives
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorSelector.BinaryArchives));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetBinaryArchives, value.NativePtr);
    }

    public MTLFunctionConstantValues ConstantValues
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorSelector.ConstantValues));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetConstantValues, value.NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorSelector.Name));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetName, value.NativePtr);
    }

    public nuint Options
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionDescriptorSelector.Options);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetOptions, value);
    }

    public NSString SpecializedName
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorSelector.SpecializedName));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetSpecializedName, value.NativePtr);
    }

    public static implicit operator nint(MTLFunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionDescriptor(nint value)
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

    public static MTLFunctionDescriptor FunctionDescriptor()
    {
        MTLFunctionDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLFunctionDescriptorSelector.FunctionDescriptor));

        return result;
    }
}

file class MTLFunctionDescriptorSelector
{
    public static readonly Selector BinaryArchives = Selector.Register("binaryArchives");

    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector ConstantValues = Selector.Register("constantValues");

    public static readonly Selector SetConstantValues = Selector.Register("setConstantValues:");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector SetName = Selector.Register("setName:");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");

    public static readonly Selector SpecializedName = Selector.Register("specializedName");

    public static readonly Selector SetSpecializedName = Selector.Register("setSpecializedName:");

    public static readonly Selector FunctionDescriptor = Selector.Register("functionDescriptor");
}
