using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTLCommandBuffer
{
    /// <summary>
    /// Registers a block to be called when the command buffer has completed execution.
    /// </summary>
    /// <param name="handler">The handler to invoke upon completion.</param>
    public unsafe void AddCompletedHandler(MTLCommandBufferHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&CommandBufferTrampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferHandlerBindings.AddCompletedHandler, (nint)(&block));
    }

    /// <summary>
    /// Registers a block to be called when the command buffer has been scheduled for execution.
    /// </summary>
    /// <param name="handler">The handler to invoke upon scheduling.</param>
    public unsafe void AddScheduledHandler(MTLCommandBufferHandler handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&CommandBufferTrampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferHandlerBindings.AddScheduledHandler, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static void CommandBufferTrampoline(nint blockPtr, nint commandBufferPtr)
    {
        unsafe
        {
            BlockLiteral* block = (BlockLiteral*)blockPtr;
            GCHandle gch = GCHandle.FromIntPtr(block->Context);
            MTLCommandBufferHandler handler = (MTLCommandBufferHandler)gch.Target!;

            handler(new MTLCommandBuffer(commandBufferPtr, NativeObjectOwnership.Borrowed));

            gch.Free();
        }
    }
}

file static class MTLCommandBufferHandlerBindings
{
    public static readonly Selector AddCompletedHandler = "addCompletedHandler:";

    public static readonly Selector AddScheduledHandler = "addScheduledHandler:";
}

