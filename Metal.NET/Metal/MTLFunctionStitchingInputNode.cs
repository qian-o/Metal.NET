namespace Metal.NET;

public readonly struct MTLFunctionStitchingInputNode(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLFunctionStitchingNode(MTLFunctionStitchingInputNode value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLFunctionStitchingInputNode value) => new(value.NativePtr);

    public MTLFunctionStitchingInputNode() : this(ObjectiveC.AllocInit(MTLFunctionStitchingInputNodeBindings.Class))
    {
    }

    public MTLFunctionStitchingInputNode Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public nuint ArgumentIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFunctionStitchingInputNodeBindings.ArgumentIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLFunctionStitchingInputNodeBindings.SetArgumentIndex, value);
    }

    public static MTLFunctionStitchingInputNode InitWithArgumentIndex(nuint argument)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(MTLFunctionStitchingInputNodeBindings.Class), MTLFunctionStitchingInputNodeBindings.InitWithArgumentIndex, argument);

        return new(nativePtr);
    }
}

file static class MTLFunctionStitchingInputNodeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFunctionStitchingInputNode");

    public static readonly Selector ArgumentIndex = "argumentIndex";

    public static readonly Selector InitWithArgumentIndex = "initWithArgumentIndex:";

    public static readonly Selector SetArgumentIndex = "setArgumentIndex:";
}
