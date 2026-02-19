namespace Metal.NET;

public class MTLComputePipelineReflection(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLComputePipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTLComputePipelineReflectionBindings.Class))
    {
    }

    public NSArray? Arguments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineReflectionBindings.Arguments);

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
    }

    public NSArray? Bindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineReflectionBindings.Bindings);

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
    }
}

file static class MTLComputePipelineReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePipelineReflection");

    public static readonly Selector Arguments = Selector.Register("arguments");

    public static readonly Selector Bindings = Selector.Register("bindings");
}
