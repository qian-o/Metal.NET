namespace Metal.NET;

public class MTL4StaticLinkingDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4StaticLinkingDescriptor>
{
    public static MTL4StaticLinkingDescriptor Null => Create(0, false);
    public static MTL4StaticLinkingDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTL4StaticLinkingDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4StaticLinkingDescriptorBindings.Class), true)
    {
    }

    public MTL4FunctionDescriptor[] FunctionDescriptors
    {
        get => GetArrayProperty<MTL4FunctionDescriptor>(MTL4StaticLinkingDescriptorBindings.FunctionDescriptors);
        set => SetArrayProperty(MTL4StaticLinkingDescriptorBindings.SetFunctionDescriptors, value);
    }

    public MTL4FunctionDescriptor[] PrivateFunctionDescriptors
    {
        get => GetArrayProperty<MTL4FunctionDescriptor>(MTL4StaticLinkingDescriptorBindings.PrivateFunctionDescriptors);
        set => SetArrayProperty(MTL4StaticLinkingDescriptorBindings.SetPrivateFunctionDescriptors, value);
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
