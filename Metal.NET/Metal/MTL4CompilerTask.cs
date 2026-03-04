namespace Metal.NET;

public class MTL4CompilerTask(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTL4CompilerTask>
{
    #region INativeObject
    public static MTL4CompilerTask Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4CompilerTask New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4Compiler Compiler
    {
        get => GetProperty(ref field, MTL4CompilerTaskBindings.Compiler);
    }

    public MTL4CompilerTaskStatus Status
    {
        get => (MTL4CompilerTaskStatus)ObjectiveC.MsgSendLong(NativePtr, MTL4CompilerTaskBindings.Status);
    }

    public void WaitUntilCompleted()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CompilerTaskBindings.WaitUntilCompleted);
    }
}

file static class MTL4CompilerTaskBindings
{
    public static readonly Selector Compiler = "compiler";

    public static readonly Selector Status = "status";

    public static readonly Selector WaitUntilCompleted = "waitUntilCompleted";
}
