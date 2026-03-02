using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTLDrawable
{
    /// <summary>
    /// Registers a block to be called after the drawable is presented.
    /// </summary>
    /// <param name="handler">The handler to invoke after presentation.</param>
    public unsafe void AddPresentedHandler(MTLDrawablePresentedHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&DrawablePresentedTrampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLDrawableHandlerBindings.AddPresentedHandler, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static void DrawablePresentedTrampoline(nint blockPtr, nint drawablePtr)
    {
        unsafe
        {
            BlockLiteral* block = (BlockLiteral*)blockPtr;
            GCHandle gch = GCHandle.FromIntPtr(block->Context);
            MTLDrawablePresentedHandler handler = (MTLDrawablePresentedHandler)gch.Target!;

            handler(new MTLDrawable(drawablePtr, NativeObjectOwnership.Borrowed));

            gch.Free();
        }
    }
}

file static class MTLDrawableHandlerBindings
{
    public static readonly Selector AddPresentedHandler = "addPresentedHandler:";
}
