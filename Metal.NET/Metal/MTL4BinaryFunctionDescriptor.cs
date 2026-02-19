namespace Metal.NET;

public readonly struct MTL4BinaryFunctionDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4BinaryFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4BinaryFunctionDescriptorBindings.Class))
    {
    }

    public MTL4FunctionDescriptor? FunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4BinaryFunctionDescriptorBindings.FunctionDescriptor);
            return ptr is not 0 ? new MTL4FunctionDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorBindings.SetFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4BinaryFunctionDescriptorBindings.Name);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorBindings.SetName, value?.NativePtr ?? 0);
    }

    public MTL4BinaryFunctionOptions Options
    {
        get => (MTL4BinaryFunctionOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4BinaryFunctionDescriptorBindings.Options);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorBindings.SetOptions, (nuint)value);
    }
}

file static class MTL4BinaryFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4BinaryFunctionDescriptor");

    public static readonly Selector FunctionDescriptor = Selector.Register("functionDescriptor");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetFunctionDescriptor = Selector.Register("setFunctionDescriptor:");

    public static readonly Selector SetName = Selector.Register("setName:");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");
}
