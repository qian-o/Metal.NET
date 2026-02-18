namespace Metal.NET;

public class MTL4SpecializedFunctionDescriptor(nint nativePtr) : MTL4FunctionDescriptor(nativePtr)
{
    public MTL4SpecializedFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4SpecializedFunctionDescriptorSelector.Class))
    {
    }

    public MTLFunctionConstantValues? ConstantValues
    {
        get => GetNullableObject<MTLFunctionConstantValues>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4SpecializedFunctionDescriptorSelector.ConstantValues));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorSelector.SetConstantValues, value?.NativePtr ?? 0);
    }

    public MTL4FunctionDescriptor? FunctionDescriptor
    {
        get => GetNullableObject<MTL4FunctionDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4SpecializedFunctionDescriptorSelector.FunctionDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorSelector.SetFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public NSString? SpecializedName
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4SpecializedFunctionDescriptorSelector.SpecializedName));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorSelector.SetSpecializedName, value?.NativePtr ?? 0);
    }
}

file static class MTL4SpecializedFunctionDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4SpecializedFunctionDescriptor");

    public static readonly Selector ConstantValues = Selector.Register("constantValues");

    public static readonly Selector FunctionDescriptor = Selector.Register("functionDescriptor");

    public static readonly Selector SetConstantValues = Selector.Register("setConstantValues:");

    public static readonly Selector SetFunctionDescriptor = Selector.Register("setFunctionDescriptor:");

    public static readonly Selector SetSpecializedName = Selector.Register("setSpecializedName:");

    public static readonly Selector SpecializedName = Selector.Register("specializedName");
}
