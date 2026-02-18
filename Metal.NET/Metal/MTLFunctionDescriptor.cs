namespace Metal.NET;

public partial class MTLFunctionDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionDescriptor");

    public MTLFunctionDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? BinaryArchives
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorSelector.BinaryArchives);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetBinaryArchives, value?.NativePtr ?? 0);
    }

    public MTLFunctionConstantValues? ConstantValues
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorSelector.ConstantValues);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetConstantValues, value?.NativePtr ?? 0);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorSelector.Name);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetName, value?.NativePtr ?? 0);
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionDescriptorSelector.Options);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetOptions, (nuint)value);
    }

    public NSString? SpecializedName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorSelector.SpecializedName);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetSpecializedName, value?.NativePtr ?? 0);
    }

    public static MTLFunctionDescriptor? FunctionDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLFunctionDescriptorSelector.FunctionDescriptor);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLFunctionDescriptorSelector
{
    public static readonly Selector BinaryArchives = Selector.Register("binaryArchives");

    public static readonly Selector ConstantValues = Selector.Register("constantValues");

    public static readonly Selector FunctionDescriptor = Selector.Register("functionDescriptor");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector SetConstantValues = Selector.Register("setConstantValues:");

    public static readonly Selector SetName = Selector.Register("setName:");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");

    public static readonly Selector SetSpecializedName = Selector.Register("setSpecializedName:");

    public static readonly Selector SpecializedName = Selector.Register("specializedName");
}
