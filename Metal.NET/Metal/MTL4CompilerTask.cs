namespace Metal.NET;

public partial class MTL4CompilerTask : NativeObject
{
    public MTL4CompilerTask(nint nativePtr) : base(nativePtr)
    {
    }

    public MTL4Compiler? Compiler
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerTaskSelector.Compiler);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTL4CompilerTaskStatus Status
    {
        get => (MTL4CompilerTaskStatus)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerTaskSelector.Status);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerTaskSelector.WaitUntilCompleted);
    }
}

file static class MTL4CompilerTaskSelector
{
    public static readonly Selector Compiler = Selector.Register("compiler");

    public static readonly Selector Status = Selector.Register("status");

    public static readonly Selector WaitUntilCompleted = Selector.Register("waitUntilCompleted");
}
