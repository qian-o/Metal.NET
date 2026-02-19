namespace Metal.NET;

public readonly struct MTL4CompilerTask(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4Compiler? Compiler
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerTaskBindings.Compiler);
            return ptr is not 0 ? new MTL4Compiler(ptr) : default;
        }
    }

    public MTL4CompilerTaskStatus Status
    {
        get => (MTL4CompilerTaskStatus)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerTaskBindings.Status);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerTaskBindings.WaitUntilCompleted);
    }
}

file static class MTL4CompilerTaskBindings
{
    public static readonly Selector Compiler = Selector.Register("compiler");

    public static readonly Selector Status = Selector.Register("status");

    public static readonly Selector WaitUntilCompleted = Selector.Register("waitUntilCompleted");
}
