namespace Metal.NET;

public readonly struct MTLFunctionStitchingFunctionNode(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLFunctionStitchingNode(MTLFunctionStitchingFunctionNode value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLFunctionStitchingFunctionNode value) => new(value.NativePtr);

    public MTLFunctionStitchingFunctionNode() : this(ObjectiveC.AllocInit(MTLFunctionStitchingFunctionNodeBindings.Class))
    {
    }

    public MTLFunctionStitchingFunctionNode Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionStitchingFunctionNodeBindings.Name));
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeBindings.SetName, value.NativePtr);
    }

    public NSArray<MTLFunctionStitchingNode> Arguments
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionStitchingFunctionNodeBindings.Arguments));
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeBindings.SetArguments, value.NativePtr);
    }

    public NSArray<MTLFunctionStitchingFunctionNode> ControlDependencies
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionStitchingFunctionNodeBindings.ControlDependencies));
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionStitchingFunctionNodeBindings.SetControlDependencies, value.NativePtr);
    }

    public static MTLFunctionStitchingFunctionNode InitWithName(NSString name, NSArray<MTLFunctionStitchingNode> arguments, NSArray<MTLFunctionStitchingFunctionNode> controlDependencies)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(MTLFunctionStitchingFunctionNodeBindings.Class), MTLFunctionStitchingFunctionNodeBindings.InitWithName_Arguments_ControlDependencies, name.NativePtr, arguments.NativePtr, controlDependencies.NativePtr);

        return new(nativePtr);
    }
}

file static class MTLFunctionStitchingFunctionNodeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionStitchingFunctionNode");

    public static readonly Selector Arguments = "arguments";

    public static readonly Selector ControlDependencies = "controlDependencies";

    public static readonly Selector InitWithName_Arguments_ControlDependencies = "initWithName:arguments:controlDependencies:";

    public static readonly Selector Name = "name";

    public static readonly Selector SetArguments = "setArguments:";

    public static readonly Selector SetControlDependencies = "setControlDependencies:";

    public static readonly Selector SetName = "setName:";
}
