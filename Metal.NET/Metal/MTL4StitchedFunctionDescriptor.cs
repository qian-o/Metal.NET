namespace Metal.NET;

public class MTL4StitchedFunctionDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4StitchedFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4StitchedFunctionDescriptorBindings.Class))
    {
    }

    public NSArray? FunctionDescriptors
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StitchedFunctionDescriptorBindings.FunctionDescriptors);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4StitchedFunctionDescriptorBindings.SetFunctionDescriptors, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLFunctionStitchingGraph? FunctionGraph
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4StitchedFunctionDescriptorBindings.FunctionGraph);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLFunctionStitchingGraph(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTL4StitchedFunctionDescriptorBindings.SetFunctionGraph, value?.NativePtr ?? 0);
            field = value;
        }
    }
}

file static class MTL4StitchedFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4StitchedFunctionDescriptor");

    public static readonly Selector FunctionDescriptors = Selector.Register("functionDescriptors");

    public static readonly Selector FunctionGraph = Selector.Register("functionGraph");

    public static readonly Selector SetFunctionDescriptors = Selector.Register("setFunctionDescriptors:");

    public static readonly Selector SetFunctionGraph = Selector.Register("setFunctionGraph:");
}
