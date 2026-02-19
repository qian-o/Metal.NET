namespace Metal.NET;

public class MTL4CompilerTask(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4Compiler? Compiler
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerTaskBindings.Compiler);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTL4Compiler(ptr);
            }

            return field;
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
