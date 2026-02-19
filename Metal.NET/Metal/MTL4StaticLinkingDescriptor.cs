namespace Metal.NET;

public class MTL4StaticLinkingDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4StaticLinkingDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4StaticLinkingDescriptorBindings.Class))
    {
    }

    public NSArray? FunctionDescriptors
    {
        get => GetProperty<NSArray>(ref field, MTL4StaticLinkingDescriptorBindings.FunctionDescriptors);
        set => SetProperty(ref field, MTL4StaticLinkingDescriptorBindings.SetFunctionDescriptors, value);
    }

    public NSArray? PrivateFunctionDescriptors
    {
        get => GetProperty<NSArray>(ref field, MTL4StaticLinkingDescriptorBindings.PrivateFunctionDescriptors);
        set => SetProperty(ref field, MTL4StaticLinkingDescriptorBindings.SetPrivateFunctionDescriptors, value);
    }
}

file static class MTL4StaticLinkingDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4StaticLinkingDescriptor");

    public static readonly Selector FunctionDescriptors = "functionDescriptors";

    public static readonly Selector PrivateFunctionDescriptors = "privateFunctionDescriptors";

    public static readonly Selector SetFunctionDescriptors = "setFunctionDescriptors:";

    public static readonly Selector SetPrivateFunctionDescriptors = "setPrivateFunctionDescriptors:";
}
