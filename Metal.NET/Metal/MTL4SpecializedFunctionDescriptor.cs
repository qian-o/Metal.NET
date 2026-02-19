namespace Metal.NET;

public class MTL4SpecializedFunctionDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4SpecializedFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4SpecializedFunctionDescriptorBindings.Class))
    {
    }

    public MTLFunctionConstantValues? ConstantValues
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4SpecializedFunctionDescriptorBindings.ConstantValues);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLFunctionConstantValues(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorBindings.SetConstantValues, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTL4FunctionDescriptor? FunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4SpecializedFunctionDescriptorBindings.FunctionDescriptor);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorBindings.SetFunctionDescriptor, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSString? SpecializedName
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4SpecializedFunctionDescriptorBindings.SpecializedName);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4SpecializedFunctionDescriptorBindings.SetSpecializedName, value?.NativePtr ?? 0);
            field = value;
        }
    }
}

file static class MTL4SpecializedFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4SpecializedFunctionDescriptor");

    public static readonly Selector ConstantValues = Selector.Register("constantValues");

    public static readonly Selector FunctionDescriptor = Selector.Register("functionDescriptor");

    public static readonly Selector SetConstantValues = Selector.Register("setConstantValues:");

    public static readonly Selector SetFunctionDescriptor = Selector.Register("setFunctionDescriptor:");

    public static readonly Selector SetSpecializedName = Selector.Register("setSpecializedName:");

    public static readonly Selector SpecializedName = Selector.Register("specializedName");
}
