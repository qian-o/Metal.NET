namespace Metal.NET;

/// <summary>
/// Groups together properties to drive a static linking process.
/// </summary>
public class MTL4StaticLinkingDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4StaticLinkingDescriptor>
{
    #region INativeObject
    public static new MTL4StaticLinkingDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4StaticLinkingDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4StaticLinkingDescriptor() : this(ObjectiveC.AllocInit(MTL4StaticLinkingDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// Provides an array of functions to link at the Metal IR level.
    /// </summary>
    public MTL4FunctionDescriptor[] FunctionDescriptors
    {
        get => GetArrayProperty<MTL4FunctionDescriptor>(MTL4StaticLinkingDescriptorBindings.FunctionDescriptors);
        set => SetArrayProperty(MTL4StaticLinkingDescriptorBindings.SetFunctionDescriptors, value);
    }

    /// <summary>
    /// Assigns groups of functions to match call-site attributes in shader code.
    /// </summary>
    public NSDictionary Groups
    {
        get => GetProperty(ref field, MTL4StaticLinkingDescriptorBindings.Groups);
        set => SetProperty(ref field, MTL4StaticLinkingDescriptorBindings.SetGroups, value);
    }

    /// <summary>
    /// Provides an array of private functions to link at the Metal IR level.
    /// </summary>
    public MTL4FunctionDescriptor[] PrivateFunctionDescriptors
    {
        get => GetArrayProperty<MTL4FunctionDescriptor>(MTL4StaticLinkingDescriptorBindings.PrivateFunctionDescriptors);
        set => SetArrayProperty(MTL4StaticLinkingDescriptorBindings.SetPrivateFunctionDescriptors, value);
    }
    #endregion
}

file static class MTL4StaticLinkingDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4StaticLinkingDescriptor");

    public static readonly Selector FunctionDescriptors = "functionDescriptors";

    public static readonly Selector Groups = "groups";

    public static readonly Selector PrivateFunctionDescriptors = "privateFunctionDescriptors";

    public static readonly Selector SetFunctionDescriptors = "setFunctionDescriptors:";

    public static readonly Selector SetGroups = "setGroups:";

    public static readonly Selector SetPrivateFunctionDescriptors = "setPrivateFunctionDescriptors:";
}
