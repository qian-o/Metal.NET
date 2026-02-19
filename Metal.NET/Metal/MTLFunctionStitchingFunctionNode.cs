namespace Metal.NET;

public class MTLFunctionStitchingFunctionNode(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFunctionStitchingFunctionNode() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingFunctionNodeBindings.Class))
    {
    }

    public NSArray? Arguments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeBindings.Arguments);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeBindings.SetArguments, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSArray? ControlDependencies
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeBindings.ControlDependencies);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeBindings.SetControlDependencies, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeBindings.Name);

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
            ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeBindings.SetName, value?.NativePtr ?? 0);
            field = value;
        }
    }
}

file static class MTLFunctionStitchingFunctionNodeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingFunctionNode");

    public static readonly Selector Arguments = Selector.Register("arguments");

    public static readonly Selector ControlDependencies = Selector.Register("controlDependencies");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector SetArguments = Selector.Register("setArguments:");

    public static readonly Selector SetControlDependencies = Selector.Register("setControlDependencies:");

    public static readonly Selector SetName = Selector.Register("setName:");
}
