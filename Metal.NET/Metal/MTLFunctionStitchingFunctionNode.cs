namespace Metal.NET;

public class MTLFunctionStitchingFunctionNode(nint nativePtr) : MTLFunctionStitchingNode(nativePtr)
{
    public NSArray Arguments
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeSelector.Arguments));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetArguments, value.NativePtr);
    }

    public NSArray ControlDependencies
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeSelector.ControlDependencies));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetControlDependencies, value.NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeSelector.Name));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetName, value.NativePtr);
    }

    public static implicit operator nint(MTLFunctionStitchingFunctionNode value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionStitchingFunctionNode(nint value)
    {
        return new(value);
    }
}

file class MTLFunctionStitchingFunctionNodeSelector
{
    public static readonly Selector Arguments = Selector.Register("arguments");

    public static readonly Selector SetArguments = Selector.Register("setArguments:");

    public static readonly Selector ControlDependencies = Selector.Register("controlDependencies");

    public static readonly Selector SetControlDependencies = Selector.Register("setControlDependencies:");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector SetName = Selector.Register("setName:");
}
