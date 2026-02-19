namespace Metal.NET;

public class MTLFunctionDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLFunctionDescriptorBindings.Class))
    {
    }

    public NSArray? BinaryArchives
    {
        get => GetProperty<NSArray>(ref field, MTLFunctionDescriptorBindings.BinaryArchives);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetBinaryArchives, value);
    }

    public MTLFunctionConstantValues? ConstantValues
    {
        get => GetProperty<MTLFunctionConstantValues>(ref field, MTLFunctionDescriptorBindings.ConstantValues);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetConstantValues, value);
    }

    public NSString? Name
    {
        get => GetProperty<NSString>(ref field, MTLFunctionDescriptorBindings.Name);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetName, value);
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionDescriptorBindings.Options);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetOptions, (nuint)value);
    }

    public NSString? SpecializedName
    {
        get => GetProperty<NSString>(ref field, MTLFunctionDescriptorBindings.SpecializedName);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetSpecializedName, value);
    }

    public static MTLFunctionDescriptor? FunctionDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLFunctionDescriptorBindings.Class, MTLFunctionDescriptorBindings.FunctionDescriptor);
        return ptr is not 0 ? new MTLFunctionDescriptor(ptr) : null;
    }
}

file static class MTLFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionDescriptor");

    public static readonly Selector BinaryArchives = "binaryArchives";

    public static readonly Selector ConstantValues = "constantValues";

    public static readonly Selector FunctionDescriptor = "functionDescriptor";

    public static readonly Selector Name = "name";

    public static readonly Selector Options = "options";

    public static readonly Selector SetBinaryArchives = "setBinaryArchives:";

    public static readonly Selector SetConstantValues = "setConstantValues:";

    public static readonly Selector SetName = "setName:";

    public static readonly Selector SetOptions = "setOptions:";

    public static readonly Selector SetSpecializedName = "setSpecializedName:";

    public static readonly Selector SpecializedName = "specializedName";
}
