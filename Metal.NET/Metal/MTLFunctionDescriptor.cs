namespace Metal.NET;

public readonly struct MTLFunctionDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLFunctionDescriptor value) => new(value.NativePtr);

    public MTLFunctionDescriptor() : this(ObjectiveC.AllocInit(MTLFunctionDescriptorBindings.Class))
    {
    }

    public MTLFunctionDescriptor Retain()
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

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionDescriptorBindings.Name));
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetName, value.NativePtr);
    }

    public NSString SpecializedName
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionDescriptorBindings.SpecializedName));
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetSpecializedName, value.NativePtr);
    }

    public MTLFunctionConstantValues ConstantValues
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionDescriptorBindings.ConstantValues));
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetConstantValues, value.NativePtr);
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveC.MsgSendULong(NativePtr, MTLFunctionDescriptorBindings.Options);
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetOptions, (nuint)value);
    }

    public NSArray<MTLBinaryArchive> BinaryArchives
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionDescriptorBindings.BinaryArchives));
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionDescriptorBindings.SetBinaryArchives, value.NativePtr);
    }

    public static MTLFunctionDescriptor FunctionDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLFunctionDescriptorBindings.Class, MTLFunctionDescriptorBindings.FunctionDescriptor);

        return new(nativePtr);
    }
}

file static class MTLFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionDescriptor");

    public static readonly Selector BinaryArchives = "binaryArchives";

    public static readonly Selector ConstantValues = "constantValues";

    public static readonly Selector FunctionDescriptor = "functionDescriptor";

    public static readonly Selector Name = "name";

    public static readonly Selector Options = "options";

    public static readonly Selector SetBinaryArchives = "setBinaryArchives:";

    public static readonly Selector SetConstantValues = "setConstantValues:";

    public static readonly Selector SetName = "setName:";

    public static readonly Selector SetOptions = "setOptions:";

    public static readonly Selector SetSpecializedName = "setSpecializedName:";

    public static readonly Selector SpecializedName = "specializedName";
}
