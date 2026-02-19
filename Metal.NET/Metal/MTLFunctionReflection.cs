namespace Metal.NET;

public class MTLFunctionReflection(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFunctionReflection() : this(ObjectiveCRuntime.AllocInit(MTLFunctionReflectionBindings.Class))
    {
    }

    public NSArray? Bindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionReflectionBindings.Bindings);

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

file static class MTLFunctionReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionReflection");

    public static readonly Selector Bindings = Selector.Register("bindings");
}
