namespace Metal.NET;

public class MTL4CompilerTask(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4CompilerTask>
{
    public static MTL4CompilerTask Create(nint nativePtr) => new(nativePtr, true);

    public static MTL4CompilerTask CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTL4Compiler Compiler
    {
        get => GetProperty(ref field, MTL4CompilerTaskBindings.Compiler);
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
    public static readonly Selector Compiler = "compiler";

    public static readonly Selector Status = "status";

    public static readonly Selector WaitUntilCompleted = "waitUntilCompleted";
}
