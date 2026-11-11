namespace Metal.NET;

public readonly struct MTL4StaticLinkingDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4StaticLinkingDescriptor value) => new(value.NativePtr);

    public MTL4StaticLinkingDescriptor() : this(ObjectiveC.AllocInit(MTL4StaticLinkingDescriptorBindings.Class))
    {
    }

    public MTL4StaticLinkingDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public NSArray<MTL4FunctionDescriptor> FunctionDescriptors
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4StaticLinkingDescriptorBindings.FunctionDescriptors));
        set => ObjectiveC.MsgSend(NativePtr, MTL4StaticLinkingDescriptorBindings.SetFunctionDescriptors, value.NativePtr);
    }

    public NSArray<MTL4FunctionDescriptor> PrivateFunctionDescriptors
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4StaticLinkingDescriptorBindings.PrivateFunctionDescriptors));
        set => ObjectiveC.MsgSend(NativePtr, MTL4StaticLinkingDescriptorBindings.SetPrivateFunctionDescriptors, value.NativePtr);
    }

    public NSDictionary Groups
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4StaticLinkingDescriptorBindings.Groups));
        set => ObjectiveC.MsgSend(NativePtr, MTL4StaticLinkingDescriptorBindings.SetGroups, value.NativePtr);
    }
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
