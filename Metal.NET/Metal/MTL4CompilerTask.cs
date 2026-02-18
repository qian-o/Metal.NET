namespace Metal.NET;

public class MTL4CompilerTask(nint nativePtr) : NativeObject(nativePtr)
{

    public MTL4Compiler? Compiler
    {
        get => GetNullableObject<MTL4Compiler>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerTaskSelector.Compiler));
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
