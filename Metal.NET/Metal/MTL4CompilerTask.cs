namespace Metal.NET;

/// <summary>
/// A reference to an asynchronous compilation task that you initiate from a compiler instance.
/// </summary>
public class MTL4CompilerTask(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CompilerTask>
{
    #region INativeObject
    public static new MTL4CompilerTask Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CompilerTask New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>
    /// Returns the compiler instance that this asynchronous compiler task belongs to.
    /// </summary>
    public MTL4Compiler Compiler
    {
        get => GetProperty(ref field, MTL4CompilerTaskBindings.Compiler);
    }

    /// <summary>
    /// Returns the compiler task status.
    /// </summary>
    public MTL4CompilerTaskStatus Status
    {
        get => (MTL4CompilerTaskStatus)ObjectiveC.MsgSendLong(NativePtr, MTL4CompilerTaskBindings.Status);
    }
    #endregion

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
