using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTL4CommitOptions(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4CommitOptions>
{
    public static MTL4CommitOptions Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4CommitOptions Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTL4CommitOptions() : this(ObjectiveCRuntime.AllocInit(MTL4CommitOptionsBindings.Class), NativeObjectOwnership.Managed)
    {
    }


    public delegate void MTL4CommitFeedbackHandler(MTL4CommitFeedback param0);

    public unsafe void AddFeedbackHandler(MTL4CommitFeedbackHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&CommitFeedbackHandler_Trampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommitOptionsBindings.AddFeedbackHandler, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static unsafe void CommitFeedbackHandler_Trampoline(nint blockPtr, nint arg0)
    {
        BlockLiteral* block = (BlockLiteral*)blockPtr;
        GCHandle gch = GCHandle.FromIntPtr(block->Context);
        MTL4CommitFeedbackHandler handler = (MTL4CommitFeedbackHandler)gch.Target!;

        handler(new MTL4CommitFeedback(arg0, NativeObjectOwnership.Borrowed));

        gch.Free();
    }
}

file static class MTL4CommitOptionsBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommitOptions");

    public static readonly Selector AddFeedbackHandler = "addFeedbackHandler:";
}
