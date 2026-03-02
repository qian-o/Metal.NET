using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTLIOCommandBuffer
{
    /// <summary>
    /// Registers a block to be called when the IO command buffer has completed execution.
    /// </summary>
    /// <param name="handler">The handler to invoke upon completion.</param>
    public unsafe void AddCompletedHandler(MTLIOCommandBufferHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&IOCommandBufferTrampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLIOCommandBufferHandlerBindings.AddCompletedHandler, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static void IOCommandBufferTrampoline(nint blockPtr, nint commandBufferPtr)
    {
        unsafe
        {
            BlockLiteral* block = (BlockLiteral*)blockPtr;
            GCHandle gch = GCHandle.FromIntPtr(block->Context);
            MTLIOCommandBufferHandler handler = (MTLIOCommandBufferHandler)gch.Target!;

            handler(new MTLIOCommandBuffer(commandBufferPtr, NativeObjectOwnership.Borrowed));

            gch.Free();
        }
    }
}

file static class MTLIOCommandBufferHandlerBindings
{
    public static readonly Selector AddCompletedHandler = "addCompletedHandler:";
}
