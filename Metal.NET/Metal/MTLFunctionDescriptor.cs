namespace Metal.NET;

public class MTLFunctionDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLFunctionDescriptorSelector.Class))
    {
    }

    public NSArray? BinaryArchives
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorSelector.BinaryArchives));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetBinaryArchives, value?.NativePtr ?? 0);
    }

    public MTLFunctionConstantValues? ConstantValues
    {
        get => GetNullableObject<MTLFunctionConstantValues>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorSelector.ConstantValues));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetConstantValues, value?.NativePtr ?? 0);
    }

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorSelector.Name));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetName, value?.NativePtr ?? 0);
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionDescriptorSelector.Options);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetOptions, (nuint)value);
    }

    public NSString? SpecializedName
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionDescriptorSelector.SpecializedName));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorSelector.SetSpecializedName, value?.NativePtr ?? 0);
    }

    public static MTLFunctionDescriptor? FunctionDescriptor()
    {
        return GetNullableObject<MTLFunctionDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLFunctionDescriptorSelector.Class, MTLFunctionDescriptorSelector.FunctionDescriptor));
    }
}

file static class MTLFunctionDescriptorSelector
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
