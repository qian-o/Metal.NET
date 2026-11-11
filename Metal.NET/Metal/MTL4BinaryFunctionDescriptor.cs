namespace Metal.NET;

public readonly struct MTL4BinaryFunctionDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4BinaryFunctionDescriptor value) => new(value.NativePtr);

    public MTL4BinaryFunctionDescriptor() : this(ObjectiveC.AllocInit(MTL4BinaryFunctionDescriptorBindings.Class))
    {
    }

    public MTL4BinaryFunctionDescriptor Retain()
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
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4BinaryFunctionDescriptorBindings.Name));
        set => ObjectiveC.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorBindings.SetName, value.NativePtr);
    }

    public MTL4FunctionDescriptor FunctionDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4BinaryFunctionDescriptorBindings.FunctionDescriptor));
        set => ObjectiveC.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorBindings.SetFunctionDescriptor, value.NativePtr);
    }

    public MTL4BinaryFunctionOptions Options
    {
        get => (MTL4BinaryFunctionOptions)ObjectiveC.MsgSendULong(NativePtr, MTL4BinaryFunctionDescriptorBindings.Options);
        set => ObjectiveC.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorBindings.SetOptions, (nuint)value);
    }
}

file static class MTL4BinaryFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4BinaryFunctionDescriptor");

    public static readonly Selector FunctionDescriptor = "functionDescriptor";

    public static readonly Selector Name = "name";

    public static readonly Selector Options = "options";

    public static readonly Selector SetFunctionDescriptor = "setFunctionDescriptor:";

    public static readonly Selector SetName = "setName:";

    public static readonly Selector SetOptions = "setOptions:";
}
