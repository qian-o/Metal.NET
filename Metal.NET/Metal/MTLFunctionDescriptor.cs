namespace Metal.NET;

public readonly struct MTLFunctionDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLFunctionDescriptorBindings.Class))
    {
    }

    public NSArray? BinaryArchives
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorBindings.BinaryArchives);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetBinaryArchives, value?.NativePtr ?? 0);
    }

    public MTLFunctionConstantValues? ConstantValues
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorBindings.ConstantValues);
            return ptr is not 0 ? new MTLFunctionConstantValues(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetConstantValues, value?.NativePtr ?? 0);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorBindings.Name);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetName, value?.NativePtr ?? 0);
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionDescriptorBindings.Options);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetOptions, (nuint)value);
    }

    public NSString? SpecializedName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorBindings.SpecializedName);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetSpecializedName, value?.NativePtr ?? 0);
    }

    public static MTLFunctionDescriptor? FunctionDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLFunctionDescriptorBindings.Class, MTLFunctionDescriptorBindings.FunctionDescriptor);
        return ptr is not 0 ? new MTLFunctionDescriptor(ptr) : default;
    }
}

file static class MTLFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionDescriptor");

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
