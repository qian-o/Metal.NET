namespace Metal.NET;

public readonly struct MTLFunctionStitchingFunctionNode(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLFunctionStitchingFunctionNode() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingFunctionNodeBindings.Class))
    {
    }

    public NSArray? Arguments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeBindings.Arguments);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeBindings.SetArguments, value?.NativePtr ?? 0);
    }

    public NSArray? ControlDependencies
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeBindings.ControlDependencies);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeBindings.SetControlDependencies, value?.NativePtr ?? 0);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeBindings.Name);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeBindings.SetName, value?.NativePtr ?? 0);
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
