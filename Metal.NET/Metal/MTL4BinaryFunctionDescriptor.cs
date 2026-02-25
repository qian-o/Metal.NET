namespace Metal.NET;

public class MTL4BinaryFunctionDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4BinaryFunctionDescriptor>
{
    public static MTL4BinaryFunctionDescriptor Null { get; } = new(0, false);

    public static MTL4BinaryFunctionDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTL4BinaryFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4BinaryFunctionDescriptorBindings.Class), true)
    {
        IsFullyManaged = true;
    }

    public MTL4FunctionDescriptor FunctionDescriptor
    {
        get => GetProperty(ref field, MTL4BinaryFunctionDescriptorBindings.FunctionDescriptor);
        set => SetProperty(ref field, MTL4BinaryFunctionDescriptorBindings.SetFunctionDescriptor, value);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTL4BinaryFunctionDescriptorBindings.Name);
        set => SetProperty(ref field, MTL4BinaryFunctionDescriptorBindings.SetName, value);
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

    public static readonly Selector FunctionDescriptor = "functionDescriptor";

    public static readonly Selector Name = "name";

    public static readonly Selector Options = "options";

    public static readonly Selector SetFunctionDescriptor = "setFunctionDescriptor:";

    public static readonly Selector SetName = "setName:";

    public static readonly Selector SetOptions = "setOptions:";
}
