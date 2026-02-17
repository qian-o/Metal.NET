namespace Metal.NET;

public class MTL4CompilerTask : IDisposable
{
    public MTL4CompilerTask(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4CompilerTask()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTL4Compiler Compiler => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerTaskSelector.Compiler));

    public MTL4CompilerTaskStatus Status => (MTL4CompilerTaskStatus)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4CompilerTaskSelector.Status));

    public void WaitUntilCompleted()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerTaskSelector.WaitUntilCompleted);
    }

    public static implicit operator nint(MTL4CompilerTask value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CompilerTask(nint value)
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
}

file class MTL4CompilerTaskSelector
{
    public static readonly Selector Compiler = Selector.Register("compiler");

    public static readonly Selector Status = Selector.Register("status");

    public static readonly Selector WaitUntilCompleted = Selector.Register("waitUntilCompleted");
}
