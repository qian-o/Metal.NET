namespace Metal.NET;

public class MTL4BinaryFunctionDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4BinaryFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4BinaryFunctionDescriptorSelector.Class))
    {
    }

    public MTL4FunctionDescriptor? FunctionDescriptor
    {
        get => GetNullableObject<MTL4FunctionDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4BinaryFunctionDescriptorSelector.FunctionDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorSelector.SetFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4BinaryFunctionDescriptorSelector.Name));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorSelector.SetName, value?.NativePtr ?? 0);
    }

    public MTL4BinaryFunctionOptions Options
    {
        get => (MTL4BinaryFunctionOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4BinaryFunctionDescriptorSelector.Options);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorSelector.SetOptions, (nuint)value);
    }
}

file static class MTL4BinaryFunctionDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4BinaryFunctionDescriptor");

    public static readonly Selector FunctionDescriptor = Selector.Register("functionDescriptor");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetFunctionDescriptor = Selector.Register("setFunctionDescriptor:");

    public static readonly Selector SetName = Selector.Register("setName:");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");
}
