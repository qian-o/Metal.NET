namespace Metal.NET;

public partial class MTL4SpecializedFunctionDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4FunctionDescriptor(nativePtr, ownership), INativeObject<MTL4SpecializedFunctionDescriptor>
{
    #region INativeObject
    public static new MTL4SpecializedFunctionDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4SpecializedFunctionDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4SpecializedFunctionDescriptor() : this(ObjectiveC.AllocInit(MTL4SpecializedFunctionDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTL4FunctionDescriptor FunctionDescriptor
    {
        get => GetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.FunctionDescriptor);
        set => SetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.SetFunctionDescriptor, value);
    }

    public NSString SpecializedName
    {
        get => GetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.SpecializedName);
        set => SetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.SetSpecializedName, value);
    }

    public MTLFunctionConstantValues ConstantValues
    {
        get => GetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.ConstantValues);
        set => SetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.SetConstantValues, value);
    }
}

file static class MTL4SpecializedFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4SpecializedFunctionDescriptor");

    public static readonly Selector ConstantValues = "constantValues";

    public static readonly Selector FunctionDescriptor = "functionDescriptor";

    public static readonly Selector SetConstantValues = "setConstantValues:";

    public static readonly Selector SetFunctionDescriptor = "setFunctionDescriptor:";

    public static readonly Selector SetSpecializedName = "setSpecializedName:";

    public static readonly Selector SpecializedName = "specializedName";
}
