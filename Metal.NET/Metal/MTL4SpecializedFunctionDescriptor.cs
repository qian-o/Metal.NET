namespace Metal.NET;

public readonly struct MTL4SpecializedFunctionDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTL4FunctionDescriptor(MTL4SpecializedFunctionDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4SpecializedFunctionDescriptor value) => new(value.NativePtr);

    public MTL4SpecializedFunctionDescriptor() : this(ObjectiveC.AllocInit(MTL4SpecializedFunctionDescriptorBindings.Class))
    {
    }

    public MTL4SpecializedFunctionDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTL4FunctionDescriptor FunctionDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4SpecializedFunctionDescriptorBindings.FunctionDescriptor));
        set => ObjectiveC.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorBindings.SetFunctionDescriptor, value.NativePtr);
    }

    public NSString SpecializedName
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4SpecializedFunctionDescriptorBindings.SpecializedName));
        set => ObjectiveC.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorBindings.SetSpecializedName, value.NativePtr);
    }

    public MTLFunctionConstantValues ConstantValues
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4SpecializedFunctionDescriptorBindings.ConstantValues));
        set => ObjectiveC.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorBindings.SetConstantValues, value.NativePtr);
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
