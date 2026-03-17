namespace Metal.NET;

public class MTLFunctionDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFunctionDescriptor>
{
    #region INativeObject
    public static new MTLFunctionDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFunctionDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFunctionDescriptor() : this(ObjectiveC.AllocInit(MTLFunctionDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionDescriptorBindings.Name);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetName, value);
    }

    public NSString SpecializedName
    {
        get => GetProperty(ref field, MTLFunctionDescriptorBindings.SpecializedName);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetSpecializedName, value);
    }

    public MTLFunctionConstantValues ConstantValues
    {
        get => GetProperty(ref field, MTLFunctionDescriptorBindings.ConstantValues);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetConstantValues, value);
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionDescriptorBindings.Options);
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetOptions, (nuint)value);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLFunctionDescriptorBindings.Name);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetName, value);
    }

    public NSString SpecializedName
    {
        get => GetProperty(ref field, MTLFunctionDescriptorBindings.SpecializedName);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetSpecializedName, value);
    }

    public MTLFunctionConstantValues ConstantValues
    {
        get => GetProperty(ref field, MTLFunctionDescriptorBindings.ConstantValues);
        set => SetProperty(ref field, MTLFunctionDescriptorBindings.SetConstantValues, value);
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionDescriptorBindings.Options);
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetOptions, (nuint)value);
    }

    public void SetName(NSString name)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetName, name.NativePtr);
    }

    public void SetSpecializedName(NSString specializedName)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetSpecializedName, specializedName.NativePtr);
    }

    public void SetConstantValues(MTLFunctionConstantValues constantValues)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetConstantValues, constantValues.NativePtr);
    }

    public void SetOptions(MTLFunctionOptions options)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetOptions, (nuint)options);
    }

    public static MTLFunctionDescriptor FunctionDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLFunctionDescriptorBindings.Class, MTLFunctionDescriptorBindings.FunctionDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionDescriptor");

    public static readonly Selector ConstantValues = "constantValues";

    public static readonly Selector FunctionDescriptor = "functionDescriptor";

    public static readonly Selector Name = "name";

    public static readonly Selector Options = "options";

    public static readonly Selector SetConstantValues = "setConstantValues:";

    public static readonly Selector SetName = "setName:";

    public static readonly Selector SetOptions = "setOptions:";

    public static readonly Selector SetSpecializedName = "setSpecializedName:";

    public static readonly Selector SpecializedName = "specializedName";
}
