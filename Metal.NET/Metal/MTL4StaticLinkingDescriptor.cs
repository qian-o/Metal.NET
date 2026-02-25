namespace Metal.NET;

public class MTL4StaticLinkingDescriptor(nint nativePtr, bool ownsReference, bool allowGCRelease) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTL4StaticLinkingDescriptor>
{
    public static MTL4StaticLinkingDescriptor Null { get; } = new(0, false, false);

    public static MTL4StaticLinkingDescriptor Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public MTL4StaticLinkingDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4StaticLinkingDescriptorBindings.Class), true, true)
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
