namespace Metal.NET;

public class MTL4BinaryFunctionDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4BinaryFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4BinaryFunctionDescriptorBindings.Class))
    {
    }

    public MTL4FunctionDescriptor? FunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4BinaryFunctionDescriptorBindings.FunctionDescriptor);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4FunctionDescriptor(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorBindings.SetFunctionDescriptor, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4BinaryFunctionDescriptorBindings.Name);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4BinaryFunctionDescriptorBindings.SetName, value?.NativePtr ?? 0);
            field = value;
        }
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
