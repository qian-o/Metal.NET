namespace Metal.NET;

public class MTLFunctionStitchingFunctionNode : IDisposable
{
    public MTLFunctionStitchingFunctionNode(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFunctionStitchingFunctionNode()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFunctionStitchingFunctionNode value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFunctionStitchingFunctionNode(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingFunctionNode");

    public MTLFunctionStitchingFunctionNode() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public NSArray Arguments
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeSelector.Arguments));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetArguments, value.NativePtr);
    }

    public NSArray ControlDependencies
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeSelector.ControlDependencies));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetControlDependencies, value.NativePtr);
    }

    public NSString Name
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionStitchingFunctionNodeSelector.Name));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeSelector.SetName, value.NativePtr);
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
