namespace Metal.NET;

public readonly struct MTL4SpecializedFunctionDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4SpecializedFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4SpecializedFunctionDescriptorBindings.Class))
    {
    }

    public MTLFunctionConstantValues? ConstantValues
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4SpecializedFunctionDescriptorBindings.ConstantValues);
            return ptr is not 0 ? new MTLFunctionConstantValues(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorBindings.SetConstantValues, value?.NativePtr ?? 0);
    }

    public MTL4FunctionDescriptor? FunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4SpecializedFunctionDescriptorBindings.FunctionDescriptor);
            return ptr is not 0 ? new MTL4FunctionDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorBindings.SetFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public NSString? SpecializedName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4SpecializedFunctionDescriptorBindings.SpecializedName);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorBindings.SetSpecializedName, value?.NativePtr ?? 0);
    }
}

file static class MTL4SpecializedFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4SpecializedFunctionDescriptor");

    public static readonly Selector ConstantValues = Selector.Register("constantValues");

    public static readonly Selector FunctionDescriptor = Selector.Register("functionDescriptor");

    public static readonly Selector SetConstantValues = Selector.Register("setConstantValues:");

    public static readonly Selector SetFunctionDescriptor = Selector.Register("setFunctionDescriptor:");

    public static readonly Selector SetSpecializedName = Selector.Register("setSpecializedName:");

    public static readonly Selector SpecializedName = Selector.Register("specializedName");
}
