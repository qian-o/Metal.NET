namespace Metal.NET;

public class MTL4SpecializedFunctionDescriptor(nint nativePtr, bool retain) : MTL4FunctionDescriptor(nativePtr, retain)
{
    public MTL4SpecializedFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4SpecializedFunctionDescriptorBindings.Class), false)
    {
    }

    public MTLFunctionConstantValues? ConstantValues
    {
        get => GetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.ConstantValues);
        set => SetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.SetConstantValues, value);
    }

    public MTL4FunctionDescriptor? FunctionDescriptor
    {
        get => GetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.FunctionDescriptor);
        set => SetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.SetFunctionDescriptor, value);
    }

    public NSString? SpecializedName
    {
        get => GetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.SpecializedName);
        set => SetProperty(ref field, MTL4SpecializedFunctionDescriptorBindings.SetSpecializedName, value);
    }
}

file static class MTL4SpecializedFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4SpecializedFunctionDescriptor");

    public static readonly Selector ConstantValues = "constantValues";

    public static readonly Selector FunctionDescriptor = "functionDescriptor";

    public static readonly Selector SetConstantValues = "setConstantValues:";

    public static readonly Selector SetFunctionDescriptor = "setFunctionDescriptor:";

    public static readonly Selector SetSpecializedName = "setSpecializedName:";

    public static readonly Selector SpecializedName = "specializedName";
}
