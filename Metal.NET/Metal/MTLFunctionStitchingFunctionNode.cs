namespace Metal.NET;

public partial class MTLFunctionStitchingFunctionNode : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingFunctionNode");

    public MTLFunctionStitchingFunctionNode(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? Arguments
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeSelector.Arguments);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetArguments, value?.NativePtr ?? 0);
    }

    public NSArray? ControlDependencies
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeSelector.ControlDependencies);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetControlDependencies, value?.NativePtr ?? 0);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeSelector.Name);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetName, value?.NativePtr ?? 0);
    }
}

file static class MTLFunctionStitchingFunctionNodeSelector
{
    public static readonly Selector Arguments = Selector.Register("arguments");

    public static readonly Selector ControlDependencies = Selector.Register("controlDependencies");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector SetArguments = Selector.Register("setArguments:");

    public static readonly Selector SetControlDependencies = Selector.Register("setControlDependencies:");

    public static readonly Selector SetName = Selector.Register("setName:");
}
