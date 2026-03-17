namespace Metal.NET;

/// <summary>
/// Groups together properties to configure and create a specialized function by passing it to a factory method.
/// </summary>
public class MTL4SpecializedFunctionDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4FunctionDescriptor(nativePtr, ownership), INativeObject<MTL4SpecializedFunctionDescriptor>
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

    #region Instance Properties - Properties

    /// <summary>
    /// Configures optional function constant values to associate with the function.
    /// </summary>
    public MTLFunctionConstantValues ConstantValues
    {
        get => GetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.ConstantValues);
        set => SetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.SetConstantValues, value);
    }

    /// <summary>
    /// Provides a descriptor that corresponds to a base function that the specialization applies to.
    /// </summary>
    public MTL4FunctionDescriptor FunctionDescriptor
    {
        get => GetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.FunctionDescriptor);
        set => SetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.SetFunctionDescriptor, value);
    }

    /// <summary>
    /// Assigns an optional name to the specialized function.
    /// </summary>
    public NSString SpecializedName
    {
        get => GetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.SpecializedName);
        set => SetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.SetSpecializedName, value);
    }
    #endregion
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
