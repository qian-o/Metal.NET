namespace Metal.NET;

public readonly struct MTL4CompilerTask(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4CompilerTask value) => new(value.NativePtr);

    public MTL4CompilerTask Retain()
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

    public MTL4Compiler Compiler
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4CompilerTaskBindings.Compiler));
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
