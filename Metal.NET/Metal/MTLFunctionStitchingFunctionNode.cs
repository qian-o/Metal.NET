namespace Metal.NET;

public class MTLFunctionStitchingFunctionNode(nint nativePtr) : MTLFunctionStitchingNode(nativePtr)
{
    public MTLFunctionStitchingFunctionNode() : this(ObjectiveCRuntime.AllocInit(MTLFunctionStitchingFunctionNodeSelector.Class))
    {
    }

    public NSArray? Arguments
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeSelector.Arguments));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetArguments, value?.NativePtr ?? 0);
    }

    public NSArray? ControlDependencies
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeSelector.ControlDependencies));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetControlDependencies, value?.NativePtr ?? 0);
    }

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeSelector.Name));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetName, value?.NativePtr ?? 0);
    }
}

file static class MTLFunctionStitchingFunctionNodeSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingFunctionNode");

    public static readonly Selector Arguments = Selector.Register("arguments");

    public static readonly Selector ControlDependencies = Selector.Register("controlDependencies");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector SetArguments = Selector.Register("setArguments:");

    public static readonly Selector SetControlDependencies = Selector.Register("setControlDependencies:");

    public static readonly Selector SetName = Selector.Register("setName:");
}
