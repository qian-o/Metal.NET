namespace Metal.NET;

public readonly struct MTLIntersectionFunctionDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLFunctionDescriptor(MTLIntersectionFunctionDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLIntersectionFunctionDescriptor value) => new(value.NativePtr);

    public MTLIntersectionFunctionDescriptor() : this(ObjectiveC.AllocInit(MTLIntersectionFunctionDescriptorBindings.Class))
    {
    }

    public MTLIntersectionFunctionDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIntersectionFunctionDescriptorBindings.Name));
        set => ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionDescriptorBindings.SetName, value.NativePtr);
    }

    public NSString SpecializedName
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIntersectionFunctionDescriptorBindings.SpecializedName));
        set => ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionDescriptorBindings.SetSpecializedName, value.NativePtr);
    }

    public MTLFunctionConstantValues ConstantValues
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIntersectionFunctionDescriptorBindings.ConstantValues));
        set => ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionDescriptorBindings.SetConstantValues, value.NativePtr);
    }

    public MTLFunctionOptions Options
    {
        get => (MTLFunctionOptions)ObjectiveC.MsgSendULong(NativePtr, MTLIntersectionFunctionDescriptorBindings.Options);
        set => ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionDescriptorBindings.SetOptions, (nuint)value);
    }

    public NSArray<MTLBinaryArchive> BinaryArchives
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIntersectionFunctionDescriptorBindings.BinaryArchives));
        set => ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionDescriptorBindings.SetBinaryArchives, value.NativePtr);
    }

    public static MTLFunctionDescriptor FunctionDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLIntersectionFunctionDescriptorBindings.Class, MTLIntersectionFunctionDescriptorBindings.FunctionDescriptor);

        return new(nativePtr);
    }
}

file static class MTLIntersectionFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLIntersectionFunctionDescriptor");

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
