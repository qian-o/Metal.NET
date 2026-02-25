namespace Metal.NET;

public class MTLFunctionDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFunctionDescriptor>
{
    public static MTLFunctionDescriptor Null { get; } = new(0, false);

    public static MTLFunctionDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLFunctionDescriptorBindings.Class), true)
    {
        GC.ReRegisterForFinalize(this);
    }

    public MTLBinaryArchive[] BinaryArchives
    {
        get => GetArrayProperty<MTLBinaryArchive>(MTLFunctionDescriptorBindings.BinaryArchives);
        set => SetArrayProperty(MTLFunctionDescriptorBindings.SetBinaryArchives, value);
    }

    public MTLFunctionConstantValues ConstantValues
    {
        get => GetProperty(ref field, MTLFunctionDescriptorBindings.ConstantValues);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetConstantValues, value);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionDescriptorBindings.Name);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetName, value);
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFunctionDescriptorBindings.Options);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetOptions, (nuint)value);
    }

    public NSString SpecializedName
    {
        get => GetProperty(ref field, MTLFunctionDescriptorBindings.SpecializedName);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetSpecializedName, value);
    }

    public static MTLFunctionDescriptor FunctionDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLFunctionDescriptorBindings.Class, MTLFunctionDescriptorBindings.FunctionDescriptor);

        return new(nativePtr, true);
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
