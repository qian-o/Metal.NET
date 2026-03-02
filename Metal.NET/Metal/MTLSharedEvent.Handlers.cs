using System.Runtime.InteropServices;

namespace Metal.NET;

public partial class MTLSharedEvent
{
    /// <summary>
    /// Registers a listener to be notified when the shared event's value equals or exceeds the specified value.
    /// </summary>
    /// <param name="listener">The shared event listener that specifies the dispatch queue for the notification.</param>
    /// <param name="value">The signal value that triggers the notification.</param>
    /// <param name="handler">The handler to invoke when the event reaches the specified value.</param>
    public unsafe void NotifyListener(MTLSharedEventListener listener, ulong value, MTLSharedEventNotificationBlock handler)
    {
        GCHandle gch = GCHandle.Alloc(handler);
        BlockLiteral block = BlockLiteral.Create((nint)(delegate* unmanaged[Cdecl]<nint, nint, ulong, void>)&SharedEventTrampoline, GCHandle.ToIntPtr(gch));

        ObjectiveCRuntime.MsgSend(NativePtr, MTLSharedEventHandlerBindings.NotifyListener, listener.NativePtr, value, (nint)(&block));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static void SharedEventTrampoline(nint blockPtr, nint sharedEventPtr, ulong value)
    {
        unsafe
        {
            BlockLiteral* block = (BlockLiteral*)blockPtr;
            GCHandle gch = GCHandle.FromIntPtr(block->Context);
            MTLSharedEventNotificationBlock handler = (MTLSharedEventNotificationBlock)gch.Target!;

            handler(new MTLSharedEvent(sharedEventPtr, NativeObjectOwnership.Borrowed), value);

            gch.Free();
        }
    }
}

file static class MTLSharedEventHandlerBindings
{
    public static readonly Selector NotifyListener = "notifyListener:atValue:block:";
}
